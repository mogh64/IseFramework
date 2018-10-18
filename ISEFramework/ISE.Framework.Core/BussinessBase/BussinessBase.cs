// developer mortaza ghahremani
// email: mortaza.ghahremani@gmail.com
// produced in august 2014
using ISE.Framework.Common.CommonBase;
using ISE.Framework.Server.Core.DataAccessBase;
using ISE.Framework.Utility.Utils;
using System;
using System.Collections.Generic;
using System.Linq;


namespace ISE.Framework.Server.Core.BussinessBase
{
    public abstract class BussinessBase<TEntity, TEntityDto> : IBussiness<TEntityDto,TEntity>
        where TEntity : class
        where TEntityDto : BaseDto
    {
        protected  IDataAccess<TEntity, TEntityDto> dataAccess;
        public BussinessBase()             
        {
            
        }

        public virtual IList<TEntityDto> GetAll()
        {
            var result = dataAccess.GetAll();
            return result;
        }

        public virtual IList<TEntityDto> GetAll(System.Linq.Expressions.Expression<Func<TEntity, bool>> whereCondition) 
        {            
            var result = dataAccess.GetAll(whereCondition);
            return result;
        }
        public IList<TEntityDto> GetAll(int page, int pageCount)
        {
            var result = dataAccess.GetAll(page, pageCount);
            return result;
        }

        public IList<TEntityDto> GetAll(System.Linq.Expressions.Expression<Func<TEntity, bool>> whereCondition, int page, int pageCount)
        {
            var result = dataAccess.GetAll(whereCondition, page, pageCount);
            return result;
        }

        public virtual TEntityDto GetSingle(System.Linq.Expressions.Expression<Func<TEntity, bool>> whereCondition) 
        {           
            var result = dataAccess.GetSingle(whereCondition);
            return result;
        }

        public virtual void Insert(TEntityDto entityDto)
        {
            dataAccess.Insert(entityDto);
        }

        public virtual void Insert(List<TEntityDto> entityDtoList)
        {
            dataAccess.Insert(entityDtoList);
        }

        public virtual void Delete(TEntityDto entityDto)
        {
            dataAccess.Delete(entityDto);
        }

        public virtual void Delete(List<TEntityDto> entityDtoList)
        {
            dataAccess.Delete(entityDtoList);
        }

        public virtual void Update(TEntityDto entityDto)
        {
            dataAccess.Update(entityDto);
        }

        public virtual void Update(List<TEntityDto> entityDtoList)
        {
            dataAccess.Update(entityDtoList);
        }



        public IQueryable<TEntity> GetQueryable()
        {
           return  dataAccess.GetQueryable();
        }

        public long Count(System.Linq.Expressions.Expression<Func<TEntity, bool>> whereCondition)
        {
           return  dataAccess.Count(whereCondition);
        }

        public long Count()
        {
           return  dataAccess.Count();
        }
    }
}
