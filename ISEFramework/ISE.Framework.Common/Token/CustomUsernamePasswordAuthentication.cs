// developer mortaza ghahremani
// email: mortaza.ghahremani@gmail.com
// produced in September 2014
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ISE.Framework.Common.Token
{
    public class CustomUsernamePasswordAuthentication : System.IdentityModel.Selectors.UserNamePasswordValidator
    {
        public CustomUsernamePasswordAuthentication()
        { }
        public override void Validate(string userName, string password)
        {

            if (userName != "a" || password != "a")
                throw new Exception("ivalid username and password;");
        }
    }
}
