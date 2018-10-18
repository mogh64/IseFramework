// developer mortaza ghahremani
// email: mortaza.ghahremani@gmail.com
// produced in september 2014

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Security.Cryptography.X509Certificates;
using System.IdentityModel.Tokens;
using System.IdentityModel.Configuration;
using System.IO;
using System.Xml.Linq;
using System.IdentityModel.Protocols.WSTrust;
using System.IdentityModel.Metadata;
using System.Security.Claims;
using System.Xml;


namespace STS
{
    public class CustomSecurityTokenServiceConfiguration : SecurityTokenServiceConfiguration
    {
        public CustomSecurityTokenServiceConfiguration()
            : base("localhost", true)
        {            
            X509Certificate2 signignCert = CertificateUtil.GetCertificate(StoreName.My, StoreLocation.LocalMachine, "CN=localhost");
            this.SigningCredentials = new X509SigningCredentials(signignCert);
            this.ServiceCertificate = signignCert;
          
            this.SecurityTokenService = typeof(CustomSecurityTokenService);
        }

    }
}
