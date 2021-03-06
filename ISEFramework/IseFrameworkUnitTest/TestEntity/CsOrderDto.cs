#pragma warning disable 1591
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
using System;
using System.Data;
using System.Linq;
using System.Linq.Expressions;
using System.Data.Common;
using System.Collections.Generic;
using Telerik.OpenAccess;
using Telerik.OpenAccess.Metadata;
using Telerik.OpenAccess.Data.Common;
using Telerik.OpenAccess.Metadata.Fluent;
using Telerik.OpenAccess.Metadata.Fluent.Advanced;
using IseFrameworkUnitTest;
using System.Runtime.Serialization;


namespace IseFrameworkUnitTest	
{
	[DataContract(Name = "CsOrderDto")]
	public partial class CsOrderDto
	{
		private long _orderid;
		[DataMember(Name = "OrderId", IsRequired = false)]
		public virtual long OrderId 
		{ 
		    get
		    {
		        return this._orderid;
		    }
		    set
		    {
		        this._orderid = value;
		    }
		}
		
		private long? _amount;
		[DataMember(Name = "Amount", IsRequired = false)]
		public virtual long? Amount 
		{ 
		    get
		    {
		        return this._amount;
		    }
		    set
		    {
		        this._amount = value;
		    }
		}
		
		private DateTime? _orderdate;
		[DataMember(Name = "OrderDate", IsRequired = false)]
		public virtual DateTime? OrderDate 
		{ 
		    get
		    {
		        return this._orderdate;
		    }
		    set
		    {
		        this._orderdate = value;
		    }
		}
		
		private long? _customerid;
		[DataMember(Name = "CustomerId", IsRequired = false)]
		public virtual long? CustomerId 
		{ 
		    get
		    {
		        return this._customerid;
		    }
		    set
		    {
		        this._customerid = value;
		    }
		}
		
		private long? _id;
		[DataMember(Name = "Id", IsRequired = false)]
		public virtual long? Id 
		{ 
		    get
		    {
		        return this._id;
		    }
		    set
		    {
		        this._id = value;
		    }
		}
		
		private IList<CsOrderitemDto> _csorderitems = new List<CsOrderitemDto>();
		[DataMember(Name = "CsOrderitems", IsRequired = false)]
		public virtual IList<CsOrderitemDto> CsOrderitems 
		{ 
		    get
		    {
		        return this._csorderitems;
		    }
		    set
		    {
		        this._csorderitems = value;
		    }
		}
		
	}
}
