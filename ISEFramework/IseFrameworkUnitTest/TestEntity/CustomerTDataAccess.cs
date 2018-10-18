
using ISE.Framework.Common.CommonBase;
using ISE.Framework.Server.Core.DataAccessBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;


namespace IseFrameworkUnitTest
{
    public class CustomerTDataAccess : TDataAccess<CsCustomer, CsCustomerDto,CsCustomerRepository>
    {
        public CustomerTDataAccess()
            : base(new CsCustomerRepository())
        { }
        public override IList<CsCustomerDto> GetAll()
        {
            var customers = this.Repository.Context.CsCustomers.ToList();
            var result = base.GetAll();
            return result;
        }


    }
}
