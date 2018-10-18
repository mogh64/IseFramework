// developer mortaza ghahremani
// email: mortaza.ghahremani@gmail.com
// produced in august 2014
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel.Description;
using System.Text;

namespace ISE.Framework.Common.Token
{
    public class CustomClientCredentials : ClientCredentials
    {
        public CustomClientCredentials()
            : base()
        {
        }
        protected CustomClientCredentials(ClientCredentials other)
            : base(other)
        {
        }
        protected override ClientCredentials CloneCore()
        {
            return new CustomClientCredentials(this);
        }
        /// <summary>
        /// Returns a custom security token manager
        /// </summary>
        /// <returns></returns>
        public override System.IdentityModel.Selectors.SecurityTokenManager CreateSecurityTokenManager()
        {
            return new CustomClientCredentialsSecurityTokenManager(this);
        }
    }
}
