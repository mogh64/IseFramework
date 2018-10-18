using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace ISE.Framework.Common.Aspects
{
    public class ConsoleTraceListener : TextWriterTraceListener
    {
        public ConsoleTraceListener()
            : base()
        {
            this.Writer = Console.Out;
        }
    }
}
