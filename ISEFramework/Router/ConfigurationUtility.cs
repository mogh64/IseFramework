// developer mortaza ghahremani
// email: mortaza.ghahremani@gmail.com
// produced in august 2014
using System;
using System.Collections.Generic;
using System.Text;
using System.ServiceModel.Channels;
using System.ServiceModel;

namespace Router
{
    public static class ConfigurationUtility
    {
        public static Binding GetRouterBinding(string scheme)
        {
            Binding b = null;

            if (scheme == "http")
            {
                b = new CustomBinding("manualAddressing");

            }
            else if (scheme == "net.tcp")
            {
                b = new CustomBinding(new BinaryMessageEncodingBindingElement(), new TcpTransportBindingElement{ ManualAddressing = true });

            }
            else if (scheme == "net.pipe")
            {
                b = new CustomBinding(new BinaryMessageEncodingBindingElement(), new NamedPipeTransportBindingElement{ ManualAddressing = true });

                
            }

            return b;
        }
    }
}
