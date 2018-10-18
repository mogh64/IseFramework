// developer mortaza ghahremani
// email: mortaza.ghahremani@gmail.com
// produced in august 2014
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Description;
using System.ServiceModel.Security.Tokens;
using System.Text;

namespace ISE.Framework.Common.Token
{
    public class CustomClientCredentialsSecurityTokenManager : ClientCredentialsSecurityTokenManager
    {
        private static Dictionary<Uri, CustomIssuedSecurityTokenProvider> providers = new Dictionary<Uri, CustomIssuedSecurityTokenProvider>();
        public CustomClientCredentialsSecurityTokenManager(ClientCredentials credentials)
            : base(credentials)
        {
        }
        /// <summary>
        /// Returns a custom token provider when a issued token is required
        /// </summary>
        public override System.IdentityModel.Selectors.SecurityTokenProvider CreateSecurityTokenProvider(System.IdentityModel.Selectors.SecurityTokenRequirement tokenRequirement)
        {
            if (this.IsIssuedSecurityTokenRequirement(tokenRequirement))
            {
                IssuedSecurityTokenProvider baseProvider = (IssuedSecurityTokenProvider)base.CreateSecurityTokenProvider(tokenRequirement);
                CustomIssuedSecurityTokenProvider provider = new CustomIssuedSecurityTokenProvider(baseProvider);
                return provider;
            }
            else
            {
                return base.CreateSecurityTokenProvider(tokenRequirement);
            }
        }
    }
}
