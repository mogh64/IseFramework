// developer mortaza ghahremani
// email: mortaza.ghahremani@gmail.com
// produced in september 2014

using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

using System.Security.Cryptography.X509Certificates;
using WCFClaims = System.IdentityModel.Claims;
using System.IdentityModel.Configuration;
using System.IdentityModel.Protocols.WSTrust;
using System.Security.Claims;
using System.IdentityModel.Tokens;
using System.Threading;
using System.IdentityModel;


namespace STS
{
    public class CustomSecurityTokenService : SecurityTokenService
    {
        public CustomSecurityTokenService(SecurityTokenServiceConfiguration configuration)
            : base(configuration)
        {
        }

        protected override Scope GetScope(ClaimsPrincipal principal, RequestSecurityToken request)
        {
            this.ValidateAppliesTo(request.AppliesTo);
            Scope scope = new Scope(request.AppliesTo.Uri.OriginalString, SecurityTokenServiceConfiguration.SigningCredentials);

            scope.TokenEncryptionRequired = false;
            scope.SymmetricKeyEncryptionRequired = false;

            if (string.IsNullOrEmpty(request.ReplyTo))
            {
                scope.ReplyToAddress = scope.AppliesToAddress;
            }
            else
            {
                scope.ReplyToAddress = request.ReplyTo;
            }

            return scope;
        }
        protected override ClaimsIdentity GetOutputClaimsIdentity(ClaimsPrincipal principal, RequestSecurityToken request, Scope scope)
        {
            if (principal == null)
            {
                throw new InvalidRequestException("The caller's principal is null.");
            }

            ClaimsIdentity outputIdentity = (ClaimsIdentity)principal.Identity;

            //outputIdentity.AddClaim(new Claim(ClaimTypes.Email, "terry@contoso.com"));
            //outputIdentity.AddClaim(new Claim(ClaimTypes.Surname, "Adams"));
            //outputIdentity.AddClaim(new Claim(ClaimTypes.Name, "Terry"));
            //outputIdentity.AddClaim(new Claim(ClaimTypes.Role, "developer"));
            //outputIdentity.AddClaim(new Claim("http://schemas.xmlsoap.org/claims/Group", "Sales"));
            //outputIdentity.AddClaim(new Claim("http://schemas.xmlsoap.org/claims/Group", "Marketing"));
            //   return (ClaimsIdentity)principal.Identity;

            return outputIdentity;
        }

        private void ValidateAppliesTo(EndpointReference appliesTo)
        {
            if (appliesTo == null)
            {
                throw new InvalidRequestException("The AppliesTo is null.");
            }
        }

    }
}
