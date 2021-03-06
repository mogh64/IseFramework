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
	public partial class CsOrderRepository : ISE.Framework.Server.Core.DataAccessBase.IRepository<CsOrder, CsOrderDto>
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
		
		public CsOrderDto FindSingle(Expression<Func<CsOrder, bool>> expression)
		{
		    if (expression == null)
		    {
		        expression = (x) => true;
		    }
		    CsOrder oaObj = this.Context.GetAll<CsOrder>().Where(expression).FirstOrDefault();
		
		    return GetDto(oaObj);
		}
		
		public IList<CsOrderDto> Find(Expression<Func<CsOrder, bool>> expression)
		{
		    if (expression == null)
		    {
		        expression = (x) => true;
		    }
		    IQueryable<CsOrder> oaObjects = this.Context.GetAll<CsOrder>().Where(expression);
		
		    return GetDtos(oaObjects);
		}
		
		public IQueryable<CsOrder> GetQueryable()
		{    
		    IQueryable<CsOrder> oaObjects = this.Context.GetAll<CsOrder>();
		
		    return oaObjects;
		}
		
		public long Count(Expression<Func<CsOrder, bool>> expression)
		{
		    if (expression == null)
		    {
		        expression = (x) => true;
		    }
		   long count = this.Context.GetAll<CsOrder>().Count(expression);
		
		    return count;
		}
		
		internal static CsOrder CreateInternal(CsOrderDto dtObj, EntitiesModel1 context)
		{
			if(dtObj == null)
			{
				return null;
			}
			CsOrder oaObj = new CsOrder();
		
			oaObj.OrderId = dtObj.OrderId;
			oaObj.Amount = dtObj.Amount;
			oaObj.OrderDate = dtObj.OrderDate;
			oaObj.CustomerId = dtObj.CustomerId;
			oaObj.Id = dtObj.Id;
		
			context.Add(oaObj);
			return oaObj;
		}
		
		public CsOrder Create(CsOrderDto dtObj)
		{
			return CreateInternal(dtObj, this.Context);
		}
		
		internal static CsOrder UpdateOrCreateInternal(CsOrderDto dtObj, EntitiesModel1 context)
		{
			if(dtObj == null)
			{
				return null;
			}
			CsOrder oaObj = (from t in context.GetAll<CsOrder>() where
							t.OrderId == dtObj.OrderId	
								select t).FirstOrDefault();
			if (oaObj == null)
			{
				return CreateInternal(dtObj, context);
			}
			oaObj.Amount = dtObj.Amount;
			oaObj.OrderDate = dtObj.OrderDate;
			oaObj.CustomerId = dtObj.CustomerId;
			oaObj.Id = dtObj.Id;
			return oaObj;
		}
		
		public CsOrder UpdateOrCreate(CsOrderDto dtObj)
		{
			return UpdateOrCreateInternal(dtObj, this.Context);
		}
		
		public void Delete(CsOrderDto dtObj)
		{
			if(dtObj == null)
			{
				return;
			}
			CsOrder oaObj = (from t in this.Context.GetAll<CsOrder>() where
								t.OrderId == dtObj.OrderId	
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
		
		public static CsOrderDto GetDto(CsOrder oaObj)
		{
			if(oaObj == null)
			{
				return null;
			}
			CsOrderDto dtObj = new CsOrderDto();
			dtObj.OrderId = oaObj.OrderId;
			dtObj.Amount = oaObj.Amount;
			dtObj.OrderDate = oaObj.OrderDate;
			dtObj.CustomerId = oaObj.CustomerId;
			dtObj.Id = oaObj.Id;
			
			return dtObj;
		}
		
		public static IList<CsOrderDto> GetDtos(IQueryable<CsOrder> oaObjects)
		{
			IList<CsOrderDto> dtObjects = new List<CsOrderDto>();
			foreach(CsOrder oaObj in oaObjects)
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
