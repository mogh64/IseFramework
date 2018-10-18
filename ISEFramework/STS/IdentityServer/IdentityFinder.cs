// developer mortaza ghahremani
// email: mortaza.ghahremani@gmail.com
// produced in september 2014
using ISE.Food.Identity;
using ISE.Framework.Common.Service;
using ISE.Framework.Common.Token;
using ISE.Framework.Server.Common.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace STS.IdentityServer
{
    public class IdentityFinder
    {
        
        public ISE.Framework.Common.Token.UserIdentity FindIdentity(string userName,string password,string systemName)
        {
            if (systemName == "IseFood")
            {
                ServiceAdapter<IIdentity> iseFoodIdentityService = new ServiceAdapter<IIdentity>();
                UserIdentity identity = (UserIdentity)iseFoodIdentityService.Execute(s => s.GetUserIdentity(userName, password));
                return identity;
            }
            return null;
        }
    }
}
