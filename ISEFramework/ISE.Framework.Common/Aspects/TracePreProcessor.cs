using ISE.Framework.Common.Dependency;
using ISE.Framework.Common.Service;
using ISE.Framework.Common.Token;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.ServiceModel;
using System.Text;

namespace ISE.Framework.Common.Aspects
{
    public class TracePreProcessor : IPreProcessor
    {
        Service.Security.IServiceAuthorize authorization;

        public TracePreProcessor()
        {
            CanAuthorize = false;
        }
        #region IPreProcessor Members

        public void Process(ref IMethodCallMessage msg)
        {
            string contractName = RemoteCallInfo.ContractName;
            try
            {

                contractName = msg.TypeName.Split(',')[0];
            }
            catch
            {

            }
            this.TraceMethod(RemoteCallInfo.ServiceType, contractName, msg.GetType().ToString(), msg.MethodName, msg.Args);
        }

        #endregion
        
        private void TraceMethod(string method)
        {
            UserIdentity currentUser = WcfCurrentContext.CurrentUser;
            var perId = currentUser.UserId;
            string message = String.Format("UserId:{0} --PreProcessing:{1}", perId, method);
            Trace.WriteLine(message);
            LogManager.GetLogger().Info(message);
        }
        private void TraceMethod(string serviceType, string contrat,string type, string method, object[] argumants)
        {
            string args = "";
            for (int i = 0; i < argumants.Count(); i++)
            {
                args += argumants[i];
                if (i < argumants.Count() - 1)
                {
                    args += ",";
                }
            }
            UserIdentity currentUser = WcfCurrentContext.CurrentUser;
            var perId = currentUser.UserId;
            string message = "";
            if (string.IsNullOrWhiteSpace(serviceType) && string.IsNullOrWhiteSpace(contrat))
            {
                message = String.Format("UserId:{0}--Token:{1} --PreProcessing:{2}: {3} : {4}", perId, currentUser.Token, type, method, args);
            }
            else
            {
                message = String.Format("UserId:{0} --Token:{1}-- {2}--PreProcessing: {3} : {4} : {5} : {6}", perId, currentUser.Token, RemoteCallInfo.RequestId, contrat, serviceType, method, args);
            }
            if (DependencyContainer.CustomPreLogger != null)
            {
                var customLogger = DependencyContainer.CustomPreLogger;
                customLogger.PreLog(RemoteCallInfo.RequestId, contrat, serviceType, method, args);
            }
           // Trace.WriteLine(message);
            LogManager.GetLogger().Info(message);
            if (this.authorization != null && CanAuthorize)
            {
                if (!this.authorization.Authorize(currentUser, contrat, method))
                    throw new FaultException("Authorization fault!");
            }
        }


        public void AddAuthorization(Service.Security.IServiceAuthorize authorization)
        {
            this.authorization = authorization;
        }

        public bool CanAuthorize
        {
            get;
            set;
        }
    }
}
