// developer mortaza ghahremani
// email: mortaza.ghahremani@gmail.com
// produced in august 2014
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISE.Framework.Common.Service.Message
{
    public class BusinessException
             : ApplicationException
    {
        public BusinessException(BusinessExceptionEnum businessExceptionType, string message)
            : base(message)
        {
            ExceptionType = businessExceptionType;
        }

        public BusinessExceptionEnum ExceptionType { get; set; }
    }
}
