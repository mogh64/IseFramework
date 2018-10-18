
using ISE.Framework.Common.Aspects;
using ISE.Framework.Common.Service.ServiceBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.ServiceModel;


namespace IseFrameworkUnitTest
{
    [ServiceContract(Namespace = "http://wcfservice/CustomerService")]
   
    public interface ICustomerService:IServiceBase
    {
        [OperationContract]
       
        CustomerDtoContainer GetOrders(long customerId);
       
    }
}
