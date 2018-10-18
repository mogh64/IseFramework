using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;

namespace ISE.Framework.Common.Aspects
{
    public abstract class ExceptionHandlingProcessor : IPostProcessor
    {

        public ExceptionHandlingProcessor()
        {
        }

        public void Process(IMethodCallMessage callMsg, ref IMethodReturnMessage retMsg)
        {
            Exception e = retMsg.Exception;
            if (e != null)
            {
                this.HandleException(e);

                Exception newException = this.GetNewException(e);
                if (!object.ReferenceEquals(e, newException))
                    retMsg = new ReturnMessage(newException, callMsg);
            }
        }

        public abstract void HandleException(Exception e);

        public virtual Exception GetNewException(Exception oldException)
        {
            return oldException;
        }
    }
}
