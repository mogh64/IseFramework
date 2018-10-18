// developer mortaza ghahremani
// email: mortaza.ghahremani@gmail.com
// produced in September 2014
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel.Security;
using System.Text;
using System.Threading.Tasks;

namespace STSHost
{
    public class CustomWsServiceHost : WSTrustServiceHost
    {
       
        public CustomWsServiceHost(WSTrustServiceContract serviceType, params Uri[] baseAddresses)
            : base(serviceType, baseAddresses)
        {
        }
        public CustomWsServiceHost(System.IdentityModel.Configuration.SecurityTokenServiceConfiguration securityTokenServiceConfiguration, params Uri[] baseAddresses)
            : base(securityTokenServiceConfiguration, baseAddresses)
        {

        }
        protected override void OnOpening()
        {

            // FederatedServiceCredentials.ConfigureServiceHost(this);

            base.OnOpening();
        }

    }
}
