using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;

namespace ISE.Framework.Common.Aspects
{
    public class CodeTimerProcessor : IPreProcessor, IPostProcessor
    {
        private CodeTimer _timer;

        public CodeTimerProcessor()
        {
            CanAuthorize = false;
        }

        #region IPreProcessor Members

        void IPreProcessor.Process(ref IMethodCallMessage msg)
        {
            _timer = new CodeTimer();
            msg.Properties.Add("codeTimer", _timer);
            _timer.Start(msg.MethodName);
        }

        #endregion

        #region IPostProcessor Members

        void IPostProcessor.Process(IMethodCallMessage callMsg, ref IMethodReturnMessage retMsg)
        {
            _timer = (CodeTimer)callMsg.Properties["codeTimer"];
            _timer.Finish();
        }

        #endregion


        public void AddAuthorization(Service.Security.IServiceAuthorize authorization)
        {
            throw new NotImplementedException();
        }

        public bool CanAuthorize
        {
            get;
            set;
        }
    }
}
