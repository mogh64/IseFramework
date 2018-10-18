using ISE.Framework.Common.Token;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ISE.Framework.Common.Service.Security
{
    public interface IServiceAuthorize
    {
        bool Authorize(UserIdentity identity, string contractName, string operationName);
    }
}
