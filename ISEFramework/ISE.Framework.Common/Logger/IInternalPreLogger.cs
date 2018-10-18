using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ISE.Framework.Common.Logger
{
    public interface IInternalPreLogger
    {
        void PreLog(string requestId, string contrat, string serviceType, string method,string inParams);
    }
}
