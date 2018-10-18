
using ISE.Framework.Common.Service.Wcf;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ISE.Framework.Client.Web.Viewer
{
    public class IseWebBussinessExceptionViewer: IBussinessExceptionViewer
    {
        public static string ErrorMessage { get; set; }
        public IseWebBussinessExceptionViewer()
        { }
        public void ShowMessage(string errorMessage)
        {
            if(ISE.Framework.Common.Service.Wcf.WcfCommandContext.CurrentCommandHasError)
               ErrorMessage = errorMessage;
            else
            {
                ErrorMessage = string.Empty;
            }
        }
        public static bool HasError
        {
            get{
                return ISE.Framework.Common.Service.Wcf.WcfCommandContext.CurrentCommandHasError;
            }            
        }
    }
}