using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ISE.Framework.Common.Aspects
{
    public class CodeTimer
    {
        private DateTime start;
        private string op;
        public CodeTimer()
        {
        }

        public void Start(string op)
        {
            this.op = op;
            this.start = DateTime.Now;
        }

        public void Finish()
        {
            TimeSpan ts = DateTime.Now.Subtract(start);
            Console.WriteLine("Total time for {0}:{1}ms", this.op, ts.TotalMilliseconds);
        }
    }
}
