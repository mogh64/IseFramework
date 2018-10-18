
using ISE.Framework.Common.Service.Wcf;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ISE.Framework.Client.Win.Viewer
{
    public class IseWinBussinessExceptionViewer : IBussinessExceptionViewer
    {
        public static string ErrorMessage { get; set; }
        public IseWinBussinessExceptionViewer()
        { }
        public void ShowMessage(string errorMessage)
        {
            MessageBox.Show(errorMessage, "خطا", MessageBoxButtons.OK, MessageBoxIcon.Error,MessageBoxDefaultButton.Button1,MessageBoxOptions.RightAlign);
        }

        public static bool HasError
        {
            get
            {
                return ISE.Framework.Common.Service.Wcf.WcfCommandContext.CurrentCommandHasError;
            }
        }
    }
}
