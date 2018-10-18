// developer mortaza ghahremani
// email: mortaza.ghahremani@gmail.com
// produced in august 2014
using System;
using System.ServiceModel;
using System.ServiceModel.Dispatcher;

namespace ISE.Framework.Common.Service.Wcf.WcfRequestContext
{
    public class InstanceCreationInitializer : IInstanceContextInitializer
    {
        #region IInstanceContextInitializer Members
        
        public void Initialize(InstanceContext instanceContext,System.ServiceModel.Channels.Message message)
        {
            // Add extension which contains the new instance creation index
            instanceContext.Extensions.Add(new InstanceCreationExtension(DateTime.Now));
        }
        
        #endregion
    }
}