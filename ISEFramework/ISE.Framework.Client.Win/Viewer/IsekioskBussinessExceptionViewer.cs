using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ISE.Framework.Common.Service.Wcf;

namespace ISE.Framework.Client.Win.Viewer
{
    public class IsekioskBussinessExceptionViewer : IBussinessExceptionViewer
    {
         public static string ErrorMessage { get; set; }
        public IsekioskBussinessExceptionViewer()
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
