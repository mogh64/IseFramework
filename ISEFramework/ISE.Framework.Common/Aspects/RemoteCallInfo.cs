using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace ISE.Framework.Common.Aspects
{
    public class RemoteCallInfo
    {
        public RemoteCallInfo() { }    
        public static string ContractName
        {
            get
            {
                try
                {
                    var conractName = System.ServiceModel.OperationContext.Current.EndpointDispatcher.ContractName;
                    return conractName;
                }
                catch (Exception ex)
                {
                    return string.Empty;
                }                
            }
        }
        public static string ServiceType
        {
            get
            {
                try
                {
                    var serviceType = (System.ServiceModel.OperationContext.Current.Host).Description.ServiceType.ToString();
                    return serviceType;
                }
                catch (Exception ex)
                {
                    return string.Empty;
                }
            }
        }
        public static string RequestId
        {
            get
            {
                try
                {
                    return System.ServiceModel.OperationContext.Current.IncomingMessageHeaders.MessageId.ToString();
                }
                catch
                {
                    return string.Empty;
                }
            }
        }
    }
}
