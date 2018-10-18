// developer mortaza ghahremani
// email: mortaza.ghahremani@gmail.com
// produced in august 2014
using System;
using System.Linq;
using System.IdentityModel.Selectors;


/// <summary>
/// Summary description for CustomValidator
/// </summary>
/// 
namespace ISE.Framework.Server.Common.Security
{
    public class CustomValidator : UserNamePasswordValidator
    {
        public override void Validate(string userName, string password)
        {
            // validate arguments
            if (string.IsNullOrEmpty(userName))
                throw new ArgumentNullException("userName");
            if (string.IsNullOrEmpty(password))
                throw new ArgumentNullException("password");

            // check the user credentials from database
            //int userid = 0;
            //CheckUserNameAndPassword(userName, password, out userid);
            //if (0 == userid)
            //    throw new SecurityTokenException("Unknown username or password");
        }
    }
}

