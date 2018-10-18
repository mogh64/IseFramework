// developer mortaza ghahremani
// email: mortaza.ghahremani@gmail.com
// produced in august 2014
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ISE.Framework.Utility.Utils
{
    public static class AssemblyReflector
    {
        public static object GetValue(object entity, string propertyName)
        {
            PropertyInfo property = entity.GetType().GetProperty(propertyName);
            object value = property.GetValue(entity, null);
            return value;           
        }
        public static void SetValue(object entity, string propertyName,object value,bool passThrough=true)
        {
           
            try
            {
                PropertyInfo property = entity.GetType().GetProperty(propertyName);
                property.SetValue(entity, value, null);       
            }
            catch(Exception ex)
            {
                if (passThrough)
                {
                    return;
                }
                throw ex;
            } 
        }
        public static string GetMemberName<T, TValue>(Expression<Func<T, TValue>> memberAccess)
        {
            return ((MemberExpression)memberAccess.Body).Member.Name;
        }
    }
}
