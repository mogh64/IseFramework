using ISE.Framework.Common.Service;
using ISE.Framework.Common.Token;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace ISE.Framework.Common.Aspects
{
    public class TraceExceptionProcessor : ExceptionHandlingProcessor
    {
        public TraceExceptionProcessor()
        { }

        public override void HandleException(Exception e)
        {
            UserIdentity currentUser = WcfCurrentContext.CurrentUser;
            var perId = currentUser.UserId;
            string message = String.Format("UserId:{0},{1}--Exception: {2}", perId, RemoteCallInfo.RequestId, e.ToString());
        
          Console.WriteLine(message);
          LogManager.GetLogger().Error(message);
          
        }
        public override Exception GetNewException(Exception oldException)
        {
            
            if (oldException.Data["type"] != null)
            {
                string exType = oldException.Data["type"].ToString();
                if (exType == "db")
                {
                    return new ApplicationException("خطای در عملیات پایگاه داده ای رخ داده است");
                }
            }
            return base.GetNewException(oldException);
        }
    }
}
