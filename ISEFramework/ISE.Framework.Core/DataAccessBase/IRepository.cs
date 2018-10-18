using ISE.Framework.Common.CommonBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ISE.Framework.Server.Core.DataAccessBase
{
    public interface IRepository<TEntity, TEntityDto> : IDisposable
        where TEntityDto : BaseDto
    {
        TEntityDto FindSingle(Expression<Func<TEntity, bool>> exp);
        IList<TEntityDto> Find(Expression<Func<TEntity, bool>> exp);     

        TEntity Create(TEntityDto entity);
        TEntity UpdateOrCreate(TEntityDto entity);
        void Delete(TEntityDto entity);

        IQueryable<TEntity> GetQueryable();
        void SaveChanges();

        long Count(Expression<Func<TEntity, bool>> whereCondition);
       
       

    }
}
