// developer mortaza ghahremani
// email: mortaza.ghahremani@gmail.com
// produced in august 2014
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ISE.Framework.Common.CommonBase
{
    public  class EntityHelper
    {
        public static Expression<Func<TDestination, bool>> ConvertExpression<TDestination>(string condition)
        {
            condition = condition.Replace("param.", "it.");
            var pars = Custom.Linq.Dynamic.DynamicExpression.ParseLambda<TDestination, bool>(condition);
            return pars;
        }       
    }
}
