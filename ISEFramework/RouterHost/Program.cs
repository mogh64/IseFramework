// developer mortaza ghahremani
// email: mortaza.ghahremani@gmail.com
// produced in august 2014
using System;
using System.Collections.Generic;
using System.Text;
using System.ServiceModel;
using ISE.Framework.Common.Aspects;

namespace RouterHost
{
    class Program
    {
        static void Main(string[] args)
        {
            ServiceHost host = null;

            try
            {
                host = new ServiceHost(typeof(Router.RouterService));
                host.Faulted += new EventHandler(host_Faulted);
                host.Open();
             //   LogManager.GetLogger().Info("Router Service Opened.");

                Console.WriteLine();
                Console.WriteLine("Press <ENTER> to terminate host.");
                Console.ReadLine();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
               // LogManager.GetLogger().Error(ex);
            }
            finally
            {
                try
                {
                    if (host.State == CommunicationState.Faulted)
                        host.Abort();
                    else
                        host.Close();
                 //   LogManager.GetLogger().Info("Router Service Closed.");
                }
                catch 
                {
                }
            }
            Console.ReadLine();

        }

        static void host_Faulted(object sender, EventArgs e)
        {
         //   LogManager.GetLogger().Info("ServiceHost faulted.");
            Console.WriteLine("ServiceHost faulted.");
        }
    }
}
