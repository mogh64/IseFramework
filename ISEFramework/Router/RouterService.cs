// developer mortaza ghahremani
// email: mortaza.ghahremani@gmail.com
// produced in august 2014
using System;
using System.Collections.Generic;
using System.Text;
using System.ServiceModel;
using System.Runtime.Serialization;
using System.ServiceModel.Channels;
using System.Diagnostics;
using System.ServiceModel.Description;
using System.Linq;
using Router.Contracts;
using System.Threading;
using ISE.Framework.Common.Aspects;

namespace Router
{


   [ServiceBehavior(InstanceContextMode = InstanceContextMode.PerCall, AddressFilterMode=AddressFilterMode.Any, ValidateMustUnderstand=false)]
    public class RouterService : IRouterService, IRegistrationService 
    {
       static public IDictionary<int, RegistrationInfo> RegistrationList = new Dictionary<int, RegistrationInfo>();
       static public IDictionary<string, int> RoundRobinCount = new Dictionary<string, int>();

        #region IRouterService Members
 
        public Message ProcessMessage(Message requestMessage)
        {
            
            Binding binding = null;
            EndpointAddress endpointAddress = null;
            GetServiceEndpoint(requestMessage, out binding, out endpointAddress);

            using (ChannelFactory<IRouterService> factory = new ChannelFactory<IRouterService>(binding,endpointAddress))
            {

                OperationContext context = OperationContext.Current;
                MessageProperties prop = context.IncomingMessageProperties;
                RemoteEndpointMessageProperty endpoint = prop[RemoteEndpointMessageProperty.Name] as RemoteEndpointMessageProperty;
                string src_ip = endpoint.Address;
                int src_port = endpoint.Port;




                factory.Endpoint.Behaviors.Add(new MustUnderstandBehavior(false));
                IRouterService proxy = factory.CreateChannel();

                using (proxy as IDisposable)
                {
                    // log request message
                    IClientChannel clientChannel = proxy as IClientChannel;
                    var threadId = Thread.CurrentThread.ManagedThreadId;
                    string message = String.Format("Thread id {3},Source Ip:{4}: Request received at {0}, to {1}\r\tAction: {2}.", DateTime.Now, clientChannel.RemoteAddress.Uri.AbsoluteUri, requestMessage.Headers.Action, threadId, string.Format("{0}:{1}", src_ip, src_port));
                    Console.WriteLine(message);
                    LogManager.GetLogger().Info(message);
                   
                    // invoke service
                    Message responseMessage = proxy.ProcessMessage(requestMessage);

                    // log response message
                    message = String.Format("Thread id {2},Source Ip:{3}: Reply received at {0}\r\tAction: {1}.", DateTime.Now, responseMessage.Headers.Action, threadId, string.Format("{0}:{1}", src_ip, src_port));
                    Console.WriteLine(message);
                    LogManager.GetLogger().Info(message);
                    Console.WriteLine();

                    return responseMessage;
                }
            }           
        }

        private void GetServiceEndpoint(Message requestMessage, out Binding binding, out EndpointAddress endpointAddress)
        {
            var requestHeader = requestMessage.Headers.FirstOrDefault(it => it.Name == "Route");
            string contractNamespace = requestHeader.Namespace.Trim();           
            string[] contractNamespaceParts = contractNamespace.Split(':');
            string listienUri = "";
            List<KeyValuePair<int, RegistrationInfo>> results ;
            if(contractNamespaceParts.Count()>2)
            {
                listienUri = contractNamespaceParts[2].Trim();
                string contractKey = contractNamespaceParts[0] + ":" + contractNamespaceParts[1];
                // get a list of all registered service entries for the specified contract
                results = (from item in RouterService.RegistrationList
                           where item.Value.ContractNamespace.Equals(contractKey) && item.Value.listenUri==listienUri
                           select item).ToList();
            }
            else
            {
                // get a list of all registered service entries for the specified contract
                results = (from item in RouterService.RegistrationList
                           where item.Value.ContractNamespace.Equals(contractNamespace)
                           select item).ToList();
            }
                     
            // get last address used
            int index = 0;
            if (!RouterService.RoundRobinCount.ContainsKey(contractNamespace))
                RouterService.RoundRobinCount.Add(contractNamespace, 0);
            else
            {
                int lastIndex = RouterService.RoundRobinCount[contractNamespace];
                if (++lastIndex > results.Count<KeyValuePair<int,RegistrationInfo>>() - 1)
                    lastIndex = 0;

                index = lastIndex;
                RouterService.RoundRobinCount[contractNamespace] = index;
            }


            RegistrationInfo regInfo = results.ElementAt<KeyValuePair<int, RegistrationInfo>>(index).Value;

            Uri addressUri = new Uri(regInfo.Address);

            binding = ConfigurationUtility.GetRouterBinding(addressUri.Scheme);
            endpointAddress = new EndpointAddress(regInfo.Address);
            
        }

        #endregion

        #region IRegistrationService Members


        public void Register(RegistrationInfo regInfo)
        {            
            if (!RouterService.RegistrationList.ContainsKey(regInfo.GetHashCode()))
            {
                RouterService.RegistrationList.Add(regInfo.GetHashCode(), regInfo);
            }
            else
            {
                RouterService.RegistrationList.Remove(regInfo.GetHashCode());
                RouterService.RegistrationList.Add(regInfo.GetHashCode(), regInfo);
            }
        }

        public void Unregister(RegistrationInfo regInfo)
        {
            if (RouterService.RegistrationList.ContainsKey(regInfo.GetHashCode()))
            {
                RouterService.RegistrationList.Remove(regInfo.GetHashCode());
            }
        }

        #endregion
    }
}
