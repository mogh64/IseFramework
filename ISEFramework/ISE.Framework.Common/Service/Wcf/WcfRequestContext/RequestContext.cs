// developer mortaza ghahremani
// email: mortaza.ghahremani@gmail.com
// produced in august 2014
using ISE.Framework.Common.Service.Wcf.Request;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;

namespace ISE.Framework.Common.Service.Wcf.WcfRequestContext
{
    public class RequestContext
        : IRequestContext
    {
        public IBusinessNotifier Notifier
        {
            get
            {
                InstanceContext ic = OperationContext.Current.InstanceContext;
                InstanceCreationExtension extension = ic.Extensions.Find<InstanceCreationExtension>();
                return extension.Notifier;
            }
        }

        public IResponseManager ResponseManager
        {
            get { throw new NotImplementedException(); }
        }
    }
}
