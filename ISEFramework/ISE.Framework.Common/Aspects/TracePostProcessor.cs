using ISE.Framework.Common.Service;
using ISE.Framework.Common.Token;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;

namespace ISE.Framework.Common.Aspects
{
    public class TracePostProcessor : IPostProcessor
    {
        public TracePostProcessor()
        { }
        public void Process(IMethodCallMessage callMsg, ref IMethodReturnMessage retMsg)
        {
            string message = String.Format("Return:{0}", retMsg.ReturnValue);
            Trace.WriteLine(message);
            TraceMethod(retMsg.ReturnValue);
        }
        private void TraceMethod(object returnValue)
        {
            string returnValueString = string.Empty;
            if (returnValue != null)
            {
                returnValueString = returnValue.ToString();
            }
            UserIdentity currentUser = WcfCurrentContext.CurrentUser;
            var perId = currentUser.UserId;
            string message = String.Format("UserId:{0} --Token:{1}--{2}--PostProcessing: Return: {2}", perId, currentUser.Token, RemoteCallInfo.RequestId, returnValueString);
          //  Trace.WriteLine(message);
            LogManager.GetLogger().Info(message);
        } 
    }
}
