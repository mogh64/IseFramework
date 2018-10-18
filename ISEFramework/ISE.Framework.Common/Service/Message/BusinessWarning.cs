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
    [DataContract]
    public class BusinessWarning
    {
        public BusinessWarning() { }
        public BusinessWarning(BusinessWarningEnum warningType, string message)
        {
            ExceptionType = warningType;
            Message = message;
        }

        [DataMember]
        public BusinessWarningEnum ExceptionType { get;  set; }
        [DataMember]
        public string Message { get;  set; }
    }
}
