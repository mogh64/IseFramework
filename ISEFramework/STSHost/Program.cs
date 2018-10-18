// developer mortaza ghahremani
// email: mortaza.ghahremani@gmail.com
// produced in september 2014
using Router.Contracts;
using STS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Security;
using System.Text;
using System.Threading.Tasks;

namespace STSHost
{
    class Program
    {
        static void Main(string[] args)
        {
            ServiceHostDecorator host = null;
            try
            {
                CustomWsServiceHost stsHost = new CustomWsServiceHost(new CustomSecurityTokenServiceConfiguration());

                stsHost.Open();


                Console.WriteLine();
                Console.WriteLine(string.Format("Security Token Service Started at {0}...", stsHost.BaseAddresses[0].ToString()));
                Console.ReadLine();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);

            }
            finally
            {
                try
                {
                    if (host.State == CommunicationState.Faulted)
                        host.Close();
                }
                catch
                {
                }
            }
            Console.ReadLine();

        }

    }
}
