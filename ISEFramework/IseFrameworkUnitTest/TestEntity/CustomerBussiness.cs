using ISE.Framework.Server.Core.BussinessBase;
using System;
using System.Collections.Generic;
using System.Linq;

namespace IseFrameworkUnitTest
{
    public class CustomerBussiness : BussinessBase<CsCustomer, CsCustomerDto>
    {
        public CustomerBussiness()
        {
            this.dataAccess = new CustomerTDataAccess();
        }


    }
}
