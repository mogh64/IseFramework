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


namespace IseFrameworkUnitTest	
{
	public partial class CsCustomerRepository : ISE.Framework.Server.Core.DataAccessBase.IRepository<CsCustomer, CsCustomerDto>
	{
		private EntitiesModel1 context;
		
		public EntitiesModel1 Context
		{
		    get
		    {
		        if (this.context == null)
		        {
		            this.context = new EntitiesModel1();
		        }
		        return this.context;
		    }
		}
		
		public CsCustomerDto FindSingle(Expression<Func<CsCustomer, bool>> expression)
		{
		    if (expression == null)
		    {
		        expression = (x) => true;
		    }
		    CsCustomer oaObj = this.Context.GetAll<CsCustomer>().Where(expression).FirstOrDefault();
		
		    return GetDto(oaObj);
		}
		
		public IList<CsCustomerDto> Find(Expression<Func<CsCustomer, bool>> expression)
		{
		    if (expression == null)
		    {
		        expression = (x) => true;
		    }
		    IQueryable<CsCustomer> oaObjects = this.Context.GetAll<CsCustomer>().Where(expression);
		
		    return GetDtos(oaObjects);
		}
		
		public IQueryable<CsCustomer> GetQueryable()
		{    
		    IQueryable<CsCustomer> oaObjects = this.Context.GetAll<CsCustomer>();
		
		    return oaObjects;
		}
		
		public long Count(Expression<Func<CsCustomer, bool>> expression)
		{
		    if (expression == null)
		    {
		        expression = (x) => true;
		    }
		   long count = this.Context.GetAll<CsCustomer>().Count(expression);
		
		    return count;
		}
		
		internal static CsCustomer CreateInternal(CsCustomerDto dtObj, EntitiesModel1 context)
		{
			if(dtObj == null)
			{
				return null;
			}
			CsCustomer oaObj = new CsCustomer();
		
			oaObj.CustomerId = dtObj.CustomerId;
			oaObj.Fname = dtObj.Fname;
			oaObj.Phone = dtObj.Phone;
			oaObj.Lname = dtObj.Lname;
			oaObj.Id = dtObj.Id;
		
			context.Add(oaObj);
			return oaObj;
		}
		
		public CsCustomer Create(CsCustomerDto dtObj)
		{
			return CreateInternal(dtObj, this.Context);
		}
		
		internal static CsCustomer UpdateOrCreateInternal(CsCustomerDto dtObj, EntitiesModel1 context)
		{
			if(dtObj == null)
			{
				return null;
			}
			CsCustomer oaObj = (from t in context.GetAll<CsCustomer>() where
							t.CustomerId == dtObj.CustomerId	
								select t).FirstOrDefault();
			if (oaObj == null)
			{
				return CreateInternal(dtObj, context);
			}
			oaObj.Fname = dtObj.Fname;
			oaObj.Phone = dtObj.Phone;
			oaObj.Lname = dtObj.Lname;
			oaObj.Id = dtObj.Id;
			return oaObj;
		}
		
		public CsCustomer UpdateOrCreate(CsCustomerDto dtObj)
		{
			return UpdateOrCreateInternal(dtObj, this.Context);
		}
		
		public void Delete(CsCustomerDto dtObj)
		{
			if(dtObj == null)
			{
				return;
			}
			CsCustomer oaObj = (from t in this.Context.GetAll<CsCustomer>() where
								t.CustomerId == dtObj.CustomerId	
								select t).FirstOrDefault();
			if (oaObj != null)
			{
				this.Context.Delete(oaObj);
			}
		}
		
		public void SaveChanges()
		{
			this.Context.SaveChanges();
		}
		
		public static CsCustomerDto GetDto(CsCustomer oaObj)
		{
			if(oaObj == null)
			{
				return null;
			}
			CsCustomerDto dtObj = new CsCustomerDto();
			dtObj.CustomerId = oaObj.CustomerId;
			dtObj.Fname = oaObj.Fname;
			dtObj.Phone = oaObj.Phone;
			dtObj.Lname = oaObj.Lname;
			dtObj.Id = oaObj.Id;
			
			return dtObj;
		}
		
		public static IList<CsCustomerDto> GetDtos(IQueryable<CsCustomer> oaObjects)
		{
			IList<CsCustomerDto> dtObjects = new List<CsCustomerDto>();
			foreach(CsCustomer oaObj in oaObjects)
			{
				dtObjects.Add(GetDto(oaObj));
			}
			return dtObjects;
		}
		
		public void Dispose()
		{
			if(this.context != null)
			{
				this.context.Dispose();
			}
		}
	}
}