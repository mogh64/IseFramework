


using ISE.Framework.Common.CommonBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;

namespace IseFrameworkUnitTest
{
   
    public partial class CsCustomerDto:BaseDto
    {
        public CsCustomerDto()
        {            
            this.PrimaryKeyName = "CUSTOMER_ID";
           
        }
        //for primary key must set private member

        
    }
}
