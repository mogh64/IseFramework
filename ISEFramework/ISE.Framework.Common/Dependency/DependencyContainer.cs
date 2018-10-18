using ISE.Framework.Common.Logger;
using ISE.Framework.Common.Service.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ISE.Framework.Common.Dependency
{
    public class DependencyContainer
    {
        public static IServiceAuthorize ServiceAuthorization { get; set; }
        public static IInternalPreLogger CustomPreLogger { get; set; }
    }
}
