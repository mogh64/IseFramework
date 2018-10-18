// developer mortaza ghahremani
// email: mortaza.ghahremani@gmail.com
// produced in august 2014
using ISE.Framework.Common.Service.Message;
using ISE.Framework.Common.Service.Wcf;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISE.Framework.Common.Service
{
    public class ClientServiceLocator
    {
        static readonly Object LocatorLock = new object();
        private static ClientServiceLocator InternalInstance;

        private ClientServiceLocator() {
            CommandDispatcher = new WcfCommandDispatcher();
        }

        public static ClientServiceLocator Instance()
        {
            if (InternalInstance == null)
            {
                lock (LocatorLock)
                {
                    // in case of a race scenario ... check again
                    if (InternalInstance == null)
                    {
                        InternalInstance = new ClientServiceLocator();
                    }
                }
            }
            return InternalInstance;
        }

        #region IClientServices Members

        public IBusinessExceptionManager ExceptionManager { get; set; }
        public IBusinessWarningManager WarningManager { get; set; }
        public ICommandDispatcher CommandDispatcher { get; set; }

        #endregion

    }
}
