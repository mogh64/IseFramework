// developer mortaza ghahremani
// email: mortaza.ghahremani@gmail.com
// produced in september 2014
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Security;
using System.IdentityModel.Tokens;
using System.Security.Claims;
using System.ServiceModel;
using System.Threading;
using STS.IdentityServer;
using ISE.Framework.Common.Token;

namespace STS
{
    public class CustomUserNameSecurityTokenHandler : System.IdentityModel.Tokens.UserNameSecurityTokenHandler
    {

        public override System.Collections.ObjectModel.ReadOnlyCollection<ClaimsIdentity> ValidateToken(SecurityToken token)
        {
            UserNameSecurityToken userNameToken = token as UserNameSecurityToken;
            IdentityFinder finder = new IdentityFinder();
            string userName = userNameToken.UserName.Split(':')[0];
            string systemName =userNameToken.UserName.Split(':')[1];
            UserIdentity identity = finder.FindIdentity(userName, userNameToken.Password, systemName);          
            if (identity==null)
                throw new SecurityException("The username or password is invalid.");
            Console.WriteLine("\t user {0}  authenticated..", identity.UserName);
            var claims = GetClaims(identity);
            IList<ClaimsIdentity> claimIdentities = new List<ClaimsIdentity>() { new ClaimsIdentity(claims, "CustomuserNameSecurityTokenHandler") };

            return new System.Collections.ObjectModel.ReadOnlyCollection<ClaimsIdentity>(claimIdentities);
        }
        public override bool CanValidateToken
        {
            get
            {
                return true;
            }
        }
        private Claim[] GetClaims(UserIdentity identity)
        {
            List<Claim> claims = new List<Claim>();
            claims.Add(new Claim(System.IdentityModel.Claims.ClaimTypes.Name, identity.UserName??""));
            claims.Add(new Claim(System.IdentityModel.Claims.ClaimTypes.GivenName, identity.FirstName??""));
            claims.Add(new Claim(System.IdentityModel.Claims.ClaimTypes.Surname, identity.LastName??""));
            claims.Add(new Claim(System.IdentityModel.Claims.ClaimTypes.System, identity.SystemName??""));
            claims.Add(new Claim(Constants.ClaimTypes.UserId, identity.UserId??""));
            claims.Add(new Claim(Constants.ClaimTypes.NationalCode, identity.NationalCode ?? ""));
            claims.Add(new Claim(System.IdentityModel.Claims.ClaimTypes.Email, identity.EmailAddress??""));
            claims.Add(new Claim(Constants.ClaimTypes.OrganisationalId, identity.OrganisationalId ?? ""));
            claims.Add(new Claim(Constants.ClaimTypes.Organisation, identity.OrganisationName ?? ""));
            claims.Add(new Claim(System.IdentityModel.Claims.ClaimTypes.Authentication, "True"));
            return claims.ToArray();
        }
    }
}
