using ISE.Framework.Common.Service.Wcf;

// developer mortaza ghahremani
// email: mortaza.ghahremani@gmail.com
// produced in august 2014
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.ServiceModel.Description;
using System.Text;
using System.Threading.Tasks;

namespace Router.Contracts
{
    public class ServiceHostDecorator
    {
        ServiceHost host;
        Uri[] uris;
        Type serviceType;
        public ServiceHostDecorator(Type serviceType)
        {
            this.serviceType = serviceType;
            uris = ServiceRouterHost.GetUris();
            host = new ExtendedServiceHost(serviceType, uris);
            host.Closing += new EventHandler(ServiceRouterHost.Host_Closing);
            host.Faulted += new EventHandler(ServiceRouterHost.Host_Faulted);
            //IServiceBehavior behavior = new EndpointBehavior();
            //host.Description.Behaviors.Add(behavior);
            

            //BindingElementCollection serviceBec = new BindingElementCollection();
            //SecurityBindingElement serviceSbe = SecurityBindingElement.CreateUserNameForCertificateBindingElement();
            //serviceSbe.EnableUnsecuredResponse = true;
            //serviceBec.Add(serviceSbe);
            //serviceBec.Add(new TextMessageEncodingBindingElement());
            //serviceBec.Add(new HttpTransportBindingElement());
            //Binding serviceBinding = new CustomBinding(serviceBec);
            //host.AddServiceEndpoint()            
        }
        public ServiceHostDecorator(ServiceHost host)
        {
            this.host = host;
            host.Closing += new EventHandler(ServiceRouterHost.Host_Closing);
            host.Faulted += new EventHandler(ServiceRouterHost.Host_Faulted);
        }
        public void Open()
        {
            
            host.Open();
            ServiceRouterHost.RegisterWithRouter(host);
        }
        public void Close()
        {
            host.Close();
        }
        public Uri[] Uris
        {
            get
            {
                return uris;
            }
        }
        public string OpenMessage
        {
            get
            {
                string msg = string.Empty;
                if (serviceType != null)
                {
                    msg = string.Format("The service {0} is ready at: {1}", serviceType.ToString(), uris[0]); 
                }
                else
                {
                    msg = string.Format("The service {0} is ready at: {1}", host.Description.ToString(), host.BaseAddresses[0]); 
                }
                return msg;
            }
        }
        public ServiceHost Host
        {
            get
            {
                return host;
            }
        }
        public  CommunicationState State
        {
            get
            {
                return host.State;
            }
        }
    }
}
