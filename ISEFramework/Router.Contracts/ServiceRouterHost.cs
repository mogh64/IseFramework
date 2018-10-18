// developer mortaza ghahremani
// email: mortaza.ghahremani@gmail.com
// produced in august 2014
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.ServiceModel;
using System.ServiceModel.Dispatcher;
using System.Text;
using System.Threading.Tasks;

namespace Router.Contracts
{
    public class ServiceRouterHost
    {
        //private static int port = 0;
        public static void Host_Faulted(object sender, EventArgs e)
        {

            UnregisterWithRouter(sender as ServiceHost);
        }

        public static void Host_Closing(object sender, EventArgs e)
        {
            UnregisterWithRouter(sender as ServiceHost);
        }
        public static Uri[] GetUris()
        {
            List<Uri> uriList = new List<Uri>();
            Uri httpBaseA = new Uri(string.Format("http://localhost:{0}", FindFreePort()));
            Uri tcpBaseA = new Uri(string.Format("net.tcp://localhost:{0}", FindFreePort()));
           // Uri netPipeBaseA = new Uri(string.Format("net.pipe://localhost/{0}", Guid.NewGuid().ToString()));
            uriList.Add(httpBaseA);
            uriList.Add(tcpBaseA);
           // uriList.Add(netPipeBaseA);
            return uriList.ToArray();
        }
        public static Uri GetHttpBaseUri()
        {
            Uri uri = new Uri(string.Format("http://localhost:{0}", FindFreePort()));
            return uri;
        }
        public static Uri GeTcpBaseUri()
        {
            Uri uri = new Uri(string.Format("net.tcp://localhost:{0}", FindFreePort()));
            return uri;
        }
        public static Uri GetNetPipeBaseUri()
        {
            Uri uri = new Uri(string.Format("net.pipe://localhost/:{0}", FindFreePort()));
            return uri;
        }
        private static int FindFreePort()
        {

           //if(port>0)
           //    return port;
            int port = 0;

            IPEndPoint endPoint = new IPEndPoint(IPAddress.Any, 0);
            using (Socket socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp))
            {
                socket.Bind(endPoint);
                IPEndPoint local = (IPEndPoint)socket.LocalEndPoint;
                port = local.Port;
            }

            if (port == 0)
                throw new InvalidOperationException("Unable to find a free port.");

            return port;
        }

        public static void RegisterWithRouter(ServiceHost host)
        {
            using (ChannelFactory<IRegistrationService> factory = new ChannelFactory<IRegistrationService>("routerEndpoint"))
            {
                IRegistrationService proxy = factory.CreateChannel();

                using (proxy as IDisposable)
                {

                    Console.WriteLine("Dispatch listeners: {0}", host.ChannelDispatchers.Count);
                    foreach (ChannelDispatcher dispatcher in host.ChannelDispatchers)
                    {

                        Console.WriteLine("\t{0}", dispatcher.Listener.Uri.AbsoluteUri);
                        Console.WriteLine("\t{0}", dispatcher.BindingName);
                        foreach (EndpointDispatcher endpointDispatcher in dispatcher.Endpoints)
                        {
                            Console.WriteLine("\t{0}, {1}", endpointDispatcher.ContractName, endpointDispatcher.ContractNamespace);

                            proxy.Register(new RegistrationInfo { Address = dispatcher.Listener.Uri.AbsoluteUri, BindingName = dispatcher.BindingName, ContractName = endpointDispatcher.ContractName, ContractNamespace = string.Format("{0}/{1}", endpointDispatcher.ContractNamespace, endpointDispatcher.ContractName) });

                        }
                        Console.WriteLine();
                    }
                }
            }
        }

        public static void UnregisterWithRouter(ServiceHost host)
        {
            using (ChannelFactory<IRegistrationService> factory = new ChannelFactory<IRegistrationService>("routerEndpoint"))
            {
                IRegistrationService proxy = factory.CreateChannel();

                using (proxy as IDisposable)
                {

                    foreach (ChannelDispatcher dispatcher in host.ChannelDispatchers)
                    {

                        Console.WriteLine("Unregistering endpoints:");
                        Console.WriteLine("\t{0}", dispatcher.Listener.Uri.AbsoluteUri);
                        foreach (EndpointDispatcher endpointDispatcher in dispatcher.Endpoints)
                        {
                            Console.WriteLine("\t{0}, {1}", endpointDispatcher.ContractName, endpointDispatcher.ContractNamespace);

                            proxy.Unregister(new RegistrationInfo { Address = dispatcher.Listener.Uri.AbsoluteUri, BindingName = dispatcher.BindingName, ContractName = endpointDispatcher.ContractName, ContractNamespace = string.Format("{0}/{1}", endpointDispatcher.ContractNamespace, endpointDispatcher.ContractName) });

                        }
                        Console.WriteLine();
                    }
                }
            }
        }
    }
}
