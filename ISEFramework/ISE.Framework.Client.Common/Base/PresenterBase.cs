using ISE.Framework.Client.Common.ExceptionManager;
using ISE.Framework.Common.CommonBase;
using ISE.Framework.Common.Service;
using ISE.Framework.Common.Service.Wcf;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ISE.Framework.Client.Common.Base
{
    public class PresenterBase<T,TService>:IPresenterBase<T> where T:BaseDto
        where TService :class, IServiceContract
    {
        public PresenterBase()
        {
            IseBussinessExceptionManager exceptionManager = new IseBussinessExceptionManager();
            ServiceAdapter = new ServiceAdapter<TService>(exceptionManager);
            
        }

        protected ServiceAdapter<TService> ServiceAdapter = new ServiceAdapter<TService>();
       
        public ClientContext ClientContext
        {
            get { return ServiceAdapter.ClientContext; }
            set { ServiceAdapter.ClientContext = value;}
        }
    }
}
