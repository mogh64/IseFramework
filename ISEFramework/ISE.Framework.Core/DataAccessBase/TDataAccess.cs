// developer mortaza ghahremani
// email: mortaza.ghahremani@gmail.com
// produced in august 2014
using ISE.Framework.Common.CommonBase;
using ISE.Framework.Common.Service;
using ISE.Framework.Common.Token;
using ISE.Framework.Utility.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Transactions;
using Telerik.OpenAccess;

namespace ISE.Framework.Server.Core.DataAccessBase
{
    public abstract class TDataAccess<TEntity, TEntityDto, TContext> : IDataAccess<TEntity, TEntityDto>        
        where TEntity: class
        where TEntityDto : BaseDto
        where TContext : IRepository<TEntity, TEntityDto> 
    {
                
       public TDataAccess(IRepository<TEntity, TEntityDto> repository)
        {
            CurrentRepository = repository;
        }
       private IRepository<TEntity, TEntityDto> CurrentRepository { get; set; }
       public TContext Repository { get { return (TContext)CurrentRepository; } }
       public virtual TEntityDto GetSingle(Expression<Func<TEntity, bool>> whereCondition)
       {
           var result = CurrentRepository.FindSingle(whereCondition);     
           return result;
       }
       public virtual void Insert(TEntityDto entityDto)
       {
           try
           {
               if (WcfCurrentContext.IsAuthenticated)
               {
                   UserIdentity currentUser = WcfCurrentContext.CurrentUser;
                   var perId = int.Parse(currentUser.UserId);
                   AssemblyReflector.SetValue(entityDto, "InsertPerId", perId);
               }              
               AssemblyReflector.SetValue(entityDto,"InsertDate", DateTime.Now);
               TEntity entity =  CurrentRepository.Create(entityDto);               
               CurrentRepository.SaveChanges();

               object id = AssemblyReflector.GetValue(entity, entityDto.PrimaryKeyName);
               AssemblyReflector.SetValue(entityDto, entityDto.PrimaryKeyName, id);
               entityDto.State = DtoObjectState.Inserted;
           }
           catch (Exception ex)
           {
               entityDto.State = DtoObjectState.Ignore;
               entityDto.Response.AddBusinessException(new Framework.Common.Service.Message.BusinessExceptionDto(Framework.Common.Service.Message.BusinessExceptionEnum.Operational, "در ورود اطلاعات به دیتابیس مشکل بوجود آمد!", ex.Message, ex.StackTrace));
               ex.Data.Add("type", "db");
               throw ex;
           }   
       }
       public virtual void Insert(List<TEntityDto> entityDtoList)
       {
          
         
        //   using (TransactionScope scope = new TransactionScope(TransactionScopeOption.Required))
           {
               try
               {
                   List<TEntity> insertedList = new List<TEntity>();
                   foreach (var entityDto in entityDtoList)
                   {
                       if (WcfCurrentContext.IsAuthenticated)
                       {
                           UserIdentity currentUser = WcfCurrentContext.CurrentUser;
                           var perId = int.Parse(currentUser.UserId);
                           AssemblyReflector.SetValue(entityDto, "InsertPerId", perId);
                       }                       
                       AssemblyReflector.SetValue(entityDto,"InsertDate", DateTime.Now);
                       TEntity entity = CurrentRepository.Create(entityDto);
                       insertedList.Add(entity);
                   }
                   CurrentRepository.SaveChanges();
                 //  scope.Complete();
                   
                   if (insertedList.Count == entityDtoList.Count)
                   {
                       int index = 0;
                       foreach (var entityDto in entityDtoList)
                       {
                           var entity = insertedList[index++];
                           object id = AssemblyReflector.GetValue(entity, entityDto.PrimaryKeyName);
                           AssemblyReflector.SetValue(entityDto, entityDto.PrimaryKeyName, id);

                           entityDto.State = DtoObjectState.Inserted;
                       }
                   }
                   
               }
               catch (Exception ex)
               {
                  
                   foreach (var entityDto in entityDtoList)
                   {
                       entityDto.State = DtoObjectState.Ignore;
                       entityDto.Response.AddBusinessException(new Framework.Common.Service.Message.BusinessExceptionDto(Framework.Common.Service.Message.BusinessExceptionEnum.Operational, "در ورود اطلاعات به دیتابیس مشکل بوجود آمد!", ex.Message, ex.StackTrace));
                   }
                   ex.Data.Add("type", "db");
                   throw ex;
               }              
           }          
       }

       public virtual void Delete(TEntityDto entityDto)
       {
           try
           {
               CurrentRepository.Delete(entityDto);
               CurrentRepository.SaveChanges();
               entityDto.State = DtoObjectState.Deleted;
           }
           catch (Exception ex)
           {              
               entityDto.State = DtoObjectState.Ignore;
               entityDto.Response.AddBusinessException(new Framework.Common.Service.Message.BusinessExceptionDto(Framework.Common.Service.Message.BusinessExceptionEnum.Operational, "در حذف اطلاعات از دیتابیس مشکل بوجود آمد!", ex.Message, ex.StackTrace));
               ex.Data.Add("type", "db");
               throw ex;
           }
       }

       public void Delete(List<TEntityDto> entityDtoList)
       {
           using (TransactionScope scope = new TransactionScope(TransactionScopeOption.Required))
           {
               try
               {
                   foreach (var entityDto in entityDtoList)
                   {
                       CurrentRepository.Delete(entityDto);                     
                   }
                   CurrentRepository.SaveChanges();
                   scope.Complete();
                   foreach (var entityDto in entityDtoList)
                   {
                       entityDto.State = DtoObjectState.Deleted;
                   }
               }
               catch (Exception ex)
               {
                   foreach (var entityDto in entityDtoList)
                   {
                       entityDto.State = DtoObjectState.Ignore;
                       entityDto.Response.AddBusinessException(new Framework.Common.Service.Message.BusinessExceptionDto(Framework.Common.Service.Message.BusinessExceptionEnum.Operational, "در حذف اطلاعات از دیتابیس مشکل بوجود آمد!", ex.Message, ex.StackTrace));
                   }
                   ex.Data.Add("type", "db");
                   throw ex;
               }
           }
           
       }
       public virtual void Update(TEntityDto entityDto)
       {
           if (WcfCurrentContext.IsAuthenticated)
           {
               UserIdentity currentUser = WcfCurrentContext.CurrentUser;
               var perId = int.Parse(currentUser.UserId);
               AssemblyReflector.SetValue(entityDto, "UpdatePerId", perId);
           }
          
           AssemblyReflector.SetValue(entityDto, "UpdateDate", DateTime.Now);
           if (entityDto.State == DtoObjectState.Updated || entityDto.State == DtoObjectState.Ignore || entityDto.State == DtoObjectState.Persisted)
           {
               try
               {
                   CurrentRepository.UpdateOrCreate(entityDto);
                   CurrentRepository.SaveChanges();
                   entityDto.State = DtoObjectState.Updated;
               }
               catch (Exception ex)
               {
                   entityDto.State = DtoObjectState.Ignore;
                   entityDto.Response.AddBusinessException(new Framework.Common.Service.Message.BusinessExceptionDto(Framework.Common.Service.Message.BusinessExceptionEnum.Operational, "در ویرایش اطلاعات از دیتابیس مشکل بوجود آمد!", ex.Message, ex.StackTrace));
                   ex.Data.Add("type", "db");
                   throw ex;
               }                   
           }           
       }
       public virtual void Update(List<TEntityDto> entityDtoList)
       {
           using (TransactionScope scope = new TransactionScope(TransactionScopeOption.Required))
           {
               try
               {
                   foreach (var entityDto in entityDtoList)
                   {
                       if (entityDto.State == DtoObjectState.Updated || entityDto.State == DtoObjectState.Ignore || entityDto.State == DtoObjectState.Persisted)
                       {
                           if (WcfCurrentContext.IsAuthenticated)
                           {
                               UserIdentity currentUser = WcfCurrentContext.CurrentUser;
                               var perId = int.Parse(currentUser.UserId);
                               AssemblyReflector.SetValue(entityDto, "UpdatePerId", perId);
                           }
                        
                           AssemblyReflector.SetValue(entityDto, "UpdateDate", DateTime.Now);
                           CurrentRepository.UpdateOrCreate(entityDto);
                       }
                   }
                   CurrentRepository.SaveChanges();
                   scope.Complete();
                   foreach (var entityDto in entityDtoList)
                   {
                       entityDto.State = DtoObjectState.Updated;
                   }
               }
               catch (Exception ex)
               {
                   foreach (var entityDto in entityDtoList)
                   {
                       entityDto.State = DtoObjectState.Ignore;
                       entityDto.Response.AddBusinessException(new Framework.Common.Service.Message.BusinessExceptionDto(Framework.Common.Service.Message.BusinessExceptionEnum.Operational, "در ویرایش اطلاعات از دیتابیس مشکل بوجود آمد!", ex.Message, ex.StackTrace));
                   }
                   ex.Data.Add("type", "db");
                   throw ex;
               }
           }
           
       }
       public virtual IList<TEntityDto> GetAll(Expression<Func<TEntity, bool>> whereCondition)
       {
           var result = CurrentRepository.Find(whereCondition).ToList();

           return result;
       }

       public virtual IList<TEntityDto> GetAll()
       {
           var result = CurrentRepository.Find(null);

           return result;
       }
       public IList<TEntityDto> GetAll(Expression<Func<TEntity, bool>> whereCondition, int page, int pageCount)
       {
           var result = CurrentRepository.Find(whereCondition).Skip((page - 1) * pageCount).Take(pageCount).ToList();
           return result;
       }

       public IList<TEntityDto> GetAll(int page, int pageCount)
       {
           var result = CurrentRepository.Find(null).Skip((page - 1) * pageCount).Take(pageCount).ToList();
           return result;
       }
       public virtual IQueryable<TEntity> GetQueryable()
       {
           var result = CurrentRepository.GetQueryable();
           return result;
       }

       public virtual long Count(Expression<Func<TEntity, bool>> whereCondition)
       {
           var result = CurrentRepository.Count(whereCondition);
           return result;
       }

       public virtual long Count()
       {
           var result = CurrentRepository.Count(null);
           return result;
       }
       
    }
}
