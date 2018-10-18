using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel.Configuration;
using System.Text;

namespace ISE.Framework.Common.Service.Wcf
{
    public class EndpointBehaviorExtensionElement : BehaviorExtensionElement
    {
        protected override object CreateBehavior()
        {
            return new EndpointBehavior();
        }

        public override Type BehaviorType
        {
            get
            {
                return typeof(EndpointBehavior);
            }
        }
    }
}
