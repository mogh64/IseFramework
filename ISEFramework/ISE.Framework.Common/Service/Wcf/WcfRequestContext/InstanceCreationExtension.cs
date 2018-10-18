// developer mortaza ghahremani
// email: mortaza.ghahremani@gmail.com
// produced in august 2014
using ISE.Framework.Common.Service.Wcf.Request;
using System;
using System.ServiceModel;

namespace ISE.Framework.Common.Service.Wcf.WcfRequestContext
{
    public class InstanceCreationExtension : IExtension<InstanceContext>
    {
        public DateTime InstanceCreated { get; private set; }
        public BusinessNotifier Notifier { get; private set; }

        public InstanceCreationExtension(DateTime instanceCreated)
        {
            InstanceCreated = instanceCreated;
            Notifier = new BusinessNotifier();
        }

        #region IExtension<InstanceContext> Members

        public void Attach(InstanceContext owner)
        {
            // Make sure we detach when the owner is closed
            owner.Closed += (sender, args) => Detach((InstanceContext)sender);
        }

        public void Detach(InstanceContext owner)
        {
            Notifier = null;
        }

        #endregion
    }
}