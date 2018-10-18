using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ISE.Framework.Common.Aspects
{
    public class ChangeExceptionProcessor : ExceptionHandlingProcessor
    {
        public ChangeExceptionProcessor()
            : base()
        { }

        public override void HandleException(Exception e)
        {
        }

        public override Exception GetNewException(Exception oldException)
        {
            return new ApplicationException("Different");
        }


    }
}
