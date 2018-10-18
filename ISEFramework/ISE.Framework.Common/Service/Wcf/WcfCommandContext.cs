using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ISE.Framework.Common.Service.Wcf
{
    public class WcfCommandContext
    {
        public static long ThreadId { get; set; }
        public static bool CurrentCommandHasError { get; set; }
    }
}
