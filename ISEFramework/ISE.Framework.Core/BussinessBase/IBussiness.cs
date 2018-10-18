// developer mortaza ghahremani
// email: mortaza.ghahremani@gmail.com
// produced in august 2014
using ISE.Framework.Common.CommonBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;


namespace ISE.Framework.Server.Core.BussinessBase
{
    public interface IBussiness<TEntityDto, TEntity>
         where TEntityDto : BaseDto
        where TEntity:class
    {
        IList<TEntityDto> GetAll();
        IList<TEntityDto> GetAll(int page, int pageCount);
        IList<TEntityDto> GetAll(Expression<Func<TEntity, bool>> whereCondition);
        IList<TEntityDto> GetAll(Expression<Func<TEntity, bool>> whereCondition, int page, int pageCount);
        TEntityDto GetSingle(Expression<Func<TEntity, bool>> whereCondition);
        void Insert(TEntityDto entityDto);
        void Insert(List<TEntityDto> entityDtoList);
        void Delete(TEntityDto entityDto);
        void Delete(List<TEntityDto> entityDtoList);
        void Update(TEntityDto entityDto);
        void Update(List<TEntityDto> entityDtoList);
        IQueryable<TEntity> GetQueryable();      
        long Count(Expression<Func<TEntity, bool>> whereCondition);
        long Count();
    }
}
