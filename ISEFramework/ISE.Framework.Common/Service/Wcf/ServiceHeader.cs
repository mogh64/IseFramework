using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace ISE.Framework.Common.Service.Wcf
{
    [DataContract]
    public class ServiceHeader
    {
        [DataMember]
        public string UserID { get; set; }
        [DataMember]
        public string VerificationCode { get; set; }

        [DataMember]
        public string WindowsLogonID { get; set; }

        [DataMember]
        public string KerberosID { get; set; }

        [DataMember]
        public string SiteminderToken { get; set; }
        [DataMember]
        public UserHeaderToken UserToken { get; set; }
    }
}
