using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ISE.Framework.Common.Service.Wcf
{
    public interface IBussinessExceptionViewer
    {      
        void ShowMessage(string errorMessage);
    }
}
