using ISE.Framework.Common.Aspects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;

namespace RouterWindowsHost
{
    public class RouterWindowsService:ServiceBase
    {
        ServiceHost host;
        public RouterWindowsService()
        {
            this.InitializeComponent();
        }
        private void InitializeComponent()
        {
            // 
            // SMWindowsService
            // 
            this.ServiceName = "RouterWindowsService";

        }
        protected override void OnStart(string[] args)
        {
            if (host != null)
            {
                host.Close();
            }
            try
            {
                host = new ServiceHost(typeof(Router.RouterService));
                host.Faulted += new EventHandler(host_Faulted);
                host.Open();
                LogManager.GetLogger().Info("Router Started.");
            }
            catch(Exception ex)
            {
                LogManager.GetLogger().Error(ex);
            }
        }
        protected override void OnStop()
        {
            if (host != null)
            {
                host.Close();
                host = null;
            }
            LogManager.GetLogger().Info("Router Stoped.");
        }
        static void host_Faulted(object sender, EventArgs e)
        {
             LogManager.GetLogger().Info("ServiceHost faulted.");
            
        }
    }
}
