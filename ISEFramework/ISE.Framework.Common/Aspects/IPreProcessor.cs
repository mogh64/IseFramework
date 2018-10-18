using ISE.Framework.Common.Service.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;

namespace ISE.Framework.Common.Aspects
{
    public interface IPreProcessor
    {
        bool CanAuthorize { get; set; }
        void Process(ref IMethodCallMessage msg);
        void AddAuthorization(IServiceAuthorize authorization);
    }
}
