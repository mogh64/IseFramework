// developer mortaza ghahremani
// email: mortaza.ghahremani@gmail.com
// produced in august 2014
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace ISE.Framework.Common.Service.Message
{
    public class BusinessExceptionDto
    {
        protected BusinessExceptionDto() { }

        public BusinessExceptionDto(BusinessExceptionEnum type, string message, string stackTrace)
        {
            ExceptionType = type;
            Message = message;
            StackTrace = stackTrace;
        }
        public BusinessExceptionDto(BusinessExceptionEnum type, string message,string error, string stackTrace)
        {
            ExceptionType = type;
            Message = message;
            StackTrace = stackTrace;
            Error = error;
        }
        [DataMember]
        public BusinessExceptionEnum ExceptionType { get;  set; }
        [DataMember]
        public string Message { get;  set; }
        [DataMember]
        public string StackTrace { get;  set; }
        [DataMember]
        public string Error { get; set; }
    }
}
