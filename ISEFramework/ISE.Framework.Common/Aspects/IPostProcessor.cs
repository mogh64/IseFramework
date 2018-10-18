using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;

namespace ISE.Framework.Common.Aspects
{
    public interface IPostProcessor
    {
        void Process(IMethodCallMessage callMsg, ref IMethodReturnMessage retMsg);
    }
}
