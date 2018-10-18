
using ISE.Framework.Common.CommonBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace IseFrameworkUnitTest
{
    [DataContract]
    public class CustomerDtoContainer:DtoContainer
    {
        public CustomerDtoContainer()
          
        {
            CustomerDtos = new List<CsCustomerDto>();
            OrderDtos = new List<CsOrderDto>();
        }
        [DataMember]
        public List<CsCustomerDto> CustomerDtos { get; set; }
        [DataMember]
        public List<CsOrderDto> OrderDtos { get; set; }
    }
}
