// developer mortaza ghahremani
// email: mortaza.ghahremani@gmail.com
// produced in august 2014
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Runtime.CompilerServices;


namespace ISE.Framework.Utility.Utils
{
    public static class ExpressionHelper
    {
        public static LambdaExpression ChangeInputType<T, TResult>(Expression<Func<T, TResult>> expression, Type newInputType)
        {
            if (!typeof(T).IsAssignableFrom(newInputType))
                throw new Exception(string.Format("{0} is not assignable from {1}.", typeof(T), newInputType));
            var beforeParameter = expression.Parameters.Single();
            var afterParameter = Expression.Parameter(newInputType, beforeParameter.Name);
            var visitor = new SubstitutionExpressionVisitor(beforeParameter, afterParameter);
            return Expression.Lambda(visitor.Visit(expression.Body), afterParameter);
        }

        public static Expression<Func<T2, TResult>> ChangeInputType<T1, T2, TResult>(Expression<Func<T1, TResult>> expression)
        {
            if (!typeof(T1).IsAssignableFrom(typeof(T2)))
                throw new Exception(string.Format("{0} is not assignable from {1}.", typeof(T1), typeof(T2)));
            var beforeParameter = expression.Parameters.Single();
            var afterParameter = Expression.Parameter(typeof(T2), beforeParameter.Name);
            var visitor = new SubstitutionExpressionVisitor(beforeParameter, afterParameter);
            return Expression.Lambda<Func<T2, TResult>>(visitor.Visit(expression.Body), afterParameter);
        }

        public class SubstitutionExpressionVisitor : ExpressionVisitor
        {
            private Expression before, after;
            public SubstitutionExpressionVisitor(Expression before, Expression after)
            {
                this.before = before;
                this.after = after;
            }
            public override Expression Visit(Expression node)
            {
                return node == before ? after : base.Visit(node);
            }
        }
        public static string PredicateToDynamicString<T>(Expression<Func<T, bool>> prediacate) 
        {
            string condition = prediacate.Body.ToString();
            var compiled = prediacate.Compile();
            if (((System.Runtime.CompilerServices.Closure)(compiled.Target)).Constants != null && ((System.Runtime.CompilerServices.Closure)(compiled.Target)).Constants.Count() > 0)
            {
                object closure = ((System.Runtime.CompilerServices.Closure)(compiled.Target)).Constants[0];
                var fields = closure.GetType().GetFields();
                foreach (var field in fields)
                {
                    try
                    {
                        string replacement = string.Format("value({0}).{1}", closure.ToString(), field.Name);
                        
                        if (condition.Contains(replacement))
                        {
                            string value = string.Empty;
                            if (field.FieldType == typeof(string))
                            {
                                value = "\""+closure.GetType().GetField(field.Name).GetValue(closure).ToString()+"\"";
                            }
                            else
                            {
                                value = closure.GetType().GetField(field.Name).GetValue(closure).ToString();
                            }
                            
                            condition = condition.Replace(replacement, value);
                        }                        
                    }
                    catch(Exception e)
                    {

                    }
                }
            }
            
            Dictionary<string, string> Operators = new Dictionary<string, string>() { 
            {"And","&&"},{"Or","||"},{"ExclusiveOr",""},{"LeftShift","<<"},{"RightShift",">>"},{"AndAlso","&&"},
            {"OrElse","||"},{"Equal","=="},{"NotEqual","!="},{"GreaterThanOrEqual",">="},{"GreaterThan",">"},{"LessThan","<"},
            {"LessThanOrEqual","<="},{"Add","+"},{"Divide","/"},{"Multiply","*"},{"Power",""},{"Subtract","-"}
            };
            condition = condition.Replace("Convert(", "(");
            string[] strs = condition.Split(' ');
            string result = string.Empty;
            foreach (var str in strs)
            {
                string trimed = str.Trim();
                if (Operators.ContainsKey(trimed))
                {
                    result += Operators[trimed] + " ";
                }
                else
                {
                    result += str + " ";
                }
            }
            result = result.Replace("Dto.", ".");
            return result;
        }
        public static string PredicateToDynamicString<T>(Expression<Func<T, bool>> prediacate,params object[] args)
        {
            var com = prediacate.Compile();

            string condition = prediacate.Body.ToString();

            Dictionary<string, string> Operators = new Dictionary<string, string>() { 
            {"And","&&"},{"Or","||"},{"ExclusiveOr",""},{"LeftShift","<<"},{"RightShift",">>"},{"AndAlso","&&"},
            {"OrElse","||"},{"Equal","=="},{"NotEqual","!="},{"GreaterThanOrEqual",">="},{"GreaterThan",">"},{"LessThan","<"},
            {"LessThanOrEqual","<="},{"Add","+"},{"Divide","/"},{"Multiply","*"},{"Power",""},{"Subtract","-"}
            };
            string[] strs = condition.Split(' ');
            string result = string.Empty;
            foreach (var str in strs)
            {
                string trimed = str.Trim();
                if (Operators.ContainsKey(trimed))
                {
                    result += Operators[trimed] + " ";
                }
                else
                {
                    result += str + " ";
                }
            }

            return result;
        }
       public static Expression<Func<T, bool>> AndAlso<T>(
        this Expression<Func<T, bool>> expr1,
        Expression<Func<T, bool>> expr2)
        {
            // need to detect whether they use the same
            // parameter instance; if not, they need fixing
            ParameterExpression param = expr1.Parameters[0];
            if (ReferenceEquals(param, expr2.Parameters[0]))
            {
                // simple version
                return Expression.Lambda<Func<T, bool>>(
                    Expression.AndAlso(expr1.Body, expr2.Body), param);
            }
            // otherwise, keep expr1 "as is" and invoke expr2
            return Expression.Lambda<Func<T, bool>>(
                Expression.AndAlso(
                    expr1.Body,
                    Expression.Invoke(expr2, param)), param);
        }

    }
}
