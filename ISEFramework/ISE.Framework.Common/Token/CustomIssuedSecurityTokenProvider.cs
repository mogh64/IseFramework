// developer mortaza ghahremani
// email: mortaza.ghahremani@gmail.com
// produced in august 2014
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Description;
using System.ServiceModel.Security.Tokens;
using System.Text;
using System.Threading;
using System.Xml;

namespace ISE.Framework.Common.Token
{
    public class CustomIssuedSecurityTokenProvider : IssuedSecurityTokenProvider
    {
        private IssuedSecurityTokenProvider innerProvider;
        /// <summary>
        /// Constructor
        /// </summary>
        public CustomIssuedSecurityTokenProvider(IssuedSecurityTokenProvider innerProvider)
            : base()
        {
            this.innerProvider = innerProvider;
            this.CacheIssuedTokens = innerProvider.CacheIssuedTokens;
            this.IdentityVerifier = innerProvider.IdentityVerifier;
            this.IssuedTokenRenewalThresholdPercentage = innerProvider.IssuedTokenRenewalThresholdPercentage;
            this.IssuerAddress = innerProvider.IssuerAddress;
            this.IssuerBinding = innerProvider.IssuerBinding;
            foreach (IEndpointBehavior behavior in innerProvider.IssuerChannelBehaviors)
            {
                this.IssuerChannelBehaviors.Add(behavior);
            }
            this.KeyEntropyMode = innerProvider.KeyEntropyMode;
            this.MaxIssuedTokenCachingTime = innerProvider.MaxIssuedTokenCachingTime;
            this.MessageSecurityVersion = innerProvider.MessageSecurityVersion;
            this.SecurityAlgorithmSuite = innerProvider.SecurityAlgorithmSuite;
            this.SecurityTokenSerializer = innerProvider.SecurityTokenSerializer;
            this.TargetAddress = innerProvider.TargetAddress;
            foreach (XmlElement parameter in innerProvider.TokenRequestParameters)
            {
                this.TokenRequestParameters.Add(parameter);
            }
            this.innerProvider.Open();
        }
        protected override System.IdentityModel.Tokens.SecurityToken GetTokenCore(TimeSpan timeout)
        {
            SecurityToken securityToken = null;
            if (this.CacheIssuedTokens)
            {
                securityToken = TokenCache.GetToken(this.innerProvider.IssuerAddress.Uri);
                if (securityToken == null || !IsServiceTokenTimeValid(securityToken))
                {
                    securityToken = innerProvider.GetToken(timeout);
                    TokenCache.AddToken(this.innerProvider.IssuerAddress.Uri, securityToken);
                }
            }
            else
            {
                securityToken = innerProvider.GetToken(timeout);
            }
            return securityToken;
        }

        /// <summary>
        /// Checks the token expiration.
        /// A more complex algorithm can be used here to determine whether the token is valid or not.
        /// </summary>
        private bool IsServiceTokenTimeValid(SecurityToken serviceToken)
        {
            return (DateTime.UtcNow <= serviceToken.ValidTo.ToUniversalTime());
        }

        ~CustomIssuedSecurityTokenProvider()
        {
            this.innerProvider.Close();
        }
    }
}
