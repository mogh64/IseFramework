#pragma warning disable 1591
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by the ClassGenerator.ttinclude code generation file.
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

namespace IseFrameworkUnitTest	
{
	public partial class CsCustomer
	{
		private long _customerid;
		public virtual long CustomerId
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
		
		private string _fname;
		public virtual string Fname
		{
			get
			{
				return this._fname;
			}
			set
			{
				this._fname = value;
			}
		}
		
		private string _phone;
		public virtual string Phone
		{
			get
			{
				return this._phone;
			}
			set
			{
				this._phone = value;
			}
		}
		
		private string _lname;
		public virtual string Lname
		{
			get
			{
				return this._lname;
			}
			set
			{
				this._lname = value;
			}
		}
		
		private long? _id;
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
		
		private IList<CsOrder> _csorders = new List<CsOrder>();
		public virtual IList<CsOrder> CsOrders
		{
			get
			{
				return this._csorders;
			}
		}
		
	}
}
#pragma warning restore 1591
