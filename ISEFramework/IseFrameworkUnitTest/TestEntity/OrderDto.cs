

using ISE.Framework.Common.CommonBase;
using System;
using System.Linq;
using System.Runtime.Serialization;


namespace IseFrameworkUnitTest
{
    public partial class CsOrderDto:BaseDto
    {
        public CsOrderDto()
        {
            this.PrimaryKeyName = "ORDER_ID";
        }
       
        
    }
}
