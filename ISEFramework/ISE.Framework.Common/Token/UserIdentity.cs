// developer mortaza ghahremani
// email: mortaza.ghahremani@gmail.com
// produced in September 2014
using ISE.Framework.Common.CommonBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISE.Framework.Common.Token
{
    public class UserIdentity:BaseDto
    {     
        public UserIdentity() {
            UserName = "";
            NationalCode = "";
            EmailAddress = "";
            UserId = "";
            FirstName = "";
            LastName = "";
            SystemName = "";
            OrganisationalId = "";
            OrganisationName = "";    
        }     
        public string UserName { get; set; }
        public string NationalCode { get; set; }
        public string EmailAddress { get; set; }
        public string UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string SystemName { get; set; }
        public string OrganisationalId { get; set; }
        public string OrganisationName { get; set; }
        public string VerificationCode { get; set; }
        public string Token { get; set; }
    }
}
