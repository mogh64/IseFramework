// developer mortaza ghahremani
// email: mortaza.ghahremani@gmail.com
// produced in august 2014
using ISE.Framework.Common.Service.Message;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.ServiceModel.Description;
using System.Text;
using System.Threading.Tasks;

namespace ISE.Framework.Common.Service.Wcf
{
    public class WcfCommandDispatcher
        : ICommandDispatcher
    {
        public WcfCommandDispatcher()
        {           
        }
        public TResult ExecuteCommand<TService, TResult>(Func<TService, TResult> command)
            where TResult : IDtoResponseEnvelop
            where TService : class,IServiceContract
        {
            var proxy = WcfProxyFactory.CreateProxy<TService>();
           
            SetCredential<TService>(proxy);       
            try
            {
                var result = command.Invoke(proxy.WcfChannel);
                proxy.Close();
                return result;
            }
            catch (Exception ex)
            {
                proxy.Abort();
                throw;
            }
        }       
        public TResult ExecuteBatchCommand<TService, TResult>(Func<TService, TResult> command)
            where TResult : IList<IDtoResponseEnvelop>
            where TService : class,IServiceContract
        {
            var proxy = WcfProxyFactory.CreateProxy<TService>();
           
            SetCredential<TService>(proxy);       
            try
            {
                var result = command.Invoke(proxy.WcfChannel);
                proxy.Close();
                return result;
            }
            catch (Exception)
            {
                proxy.Abort();
                throw;
            }
        }
        


        public void ExecuteCommand<TService>(Action<TService> command) where TService : class, IServiceContract
        {
            var proxy = WcfProxyFactory.CreateProxy<TService>();
           
            SetCredential<TService>(proxy);   
            try
            {
                command.Invoke(proxy.WcfChannel);
                proxy.Close();
                
            }
            catch (Exception)
            {
                proxy.Abort();
                throw;
            }
        }

        public TResult ExecuteSimpleCommand<TService, TResult>(Func<TService, TResult> command)
            where TService : class, IServiceContract        
        {
            var proxy = WcfProxyFactory.CreateProxy<TService>();
          
            SetCredential<TService>(proxy);        
            
            try
            {
                var result = command.Invoke(proxy.WcfChannel);
                proxy.Close();
                return result;
            }
            catch (Exception)
            {
                proxy.Abort();
                throw;
            }
        }

        private  void SetCredential<TService>(WcfProxy<TService> proxy) where TService : class, IServiceContract
        {
            var credential = proxy.Endpoint.Behaviors.OfType<ClientCredentials>().FirstOrDefault();
            if (!proxy.Endpoint.Behaviors.Contains(typeof(EndpointBehavior)))
            {
                proxy.Endpoint.Behaviors.Add(new EndpointBehavior());
            }
            
            if (credential != null)
            {
                if (credential.UserName.UserName == null)
                {
                    if (ISE.Framework.Common.Service.Security.LoginContext.ServiceLogin != null)
                    {
                        credential.UserName.UserName = ISE.Framework.Common.Service.Security.LoginContext.ServiceLogin.UserName;
                        credential.UserName.Password = ISE.Framework.Common.Service.Security.LoginContext.ServiceLogin.Password;
                        var elements = proxy.Endpoint.Binding.CreateBindingElements();
                        var securityElement = elements.Find<SecurityBindingElement>();
                        if (securityElement != null)
                        {
                            securityElement.EnableUnsecuredResponse = true;
                            proxy.Endpoint.Binding = new CustomBinding(elements);
                        }

                    }
                }
            }         
        }
    }
}
