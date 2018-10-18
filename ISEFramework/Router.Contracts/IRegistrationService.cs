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

namespace Router.Contracts
{

    [DataContract(Namespace = "http://wcfservice/01")]
    public class RegistrationInfo
    {
        [DataMember(IsRequired = true, Order = 1)]
        public string Address { get;  set; }
        
        [DataMember(IsRequired = true, Order = 2)]
        public string BindingName { get;  set; }

        [DataMember(IsRequired = true, Order = 3)]
        public string ContractName { get;  set; }

        [DataMember(IsRequired = true, Order = 4)]
        public string ContractNamespace { get;  set; }
        public string AddressWithoutPort
        {
            get
            {
                string first = this.Address.Split(':')[2];
                if (!string.IsNullOrWhiteSpace(first))
                {
                    string second = first.Split('/')[0];
                    if (!string.IsNullOrWhiteSpace(second))
                        return this.Address.Replace(second, "");
                }
                return this.Address;
            }
        }
        public string listenUri
        {
            get
            {
                return AddressWithoutPort.Split('/').Last().Trim();
            }
        }
        public override int GetHashCode()
        {
            return this.AddressWithoutPort.GetHashCode() + this.ContractName.GetHashCode() + this.ContractNamespace.GetHashCode();
        }
    }

    [ServiceContract(Namespace = "http://wcfservice/01")]
    public interface IRegistrationService
    {
        [OperationContract]
        void Register(RegistrationInfo regInfo);

        [OperationContract]
        void Unregister(RegistrationInfo regInfo);
    }

}
