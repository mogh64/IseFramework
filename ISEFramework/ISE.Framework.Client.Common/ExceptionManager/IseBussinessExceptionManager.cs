
using ISE.Framework.Client.Common.Environment;
using ISE.Framework.Common.Service.Message;
using ISE.Framework.Common.Service.Wcf;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISE.Framework.Client.Common.ExceptionManager
{
    public class IseBussinessExceptionManager : IBusinessExceptionManager
    {
        public IseBussinessExceptionManager()
        {
            Viewer = EnvironmentVariables.GetCurrentViewer;
        }
        public IBussinessExceptionViewer Viewer { get; set; }
        public void HandleBusinessException(List<BusinessExceptionDto> exceptionDto)
        {
            throw new NotImplementedException();
        }

        public void HandleBusinessException(BusinessExceptionDto exceptionDto)
        {
            Viewer.ShowMessage(exceptionDto.Message);
        }
    }
}
