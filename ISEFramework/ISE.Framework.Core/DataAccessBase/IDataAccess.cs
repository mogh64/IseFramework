// developer mortaza ghahremani
// email: mortaza.ghahremani@gmail.com
// produced in august 2014
using ISE.Framework.Common.CommonBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;


namespace ISE.Framework.Server.Core.DataAccessBase
{
    public interface IDataAccess<TEntity, TEntityDto> where TEntity : class
        where TEntityDto : BaseDto
    {
        /// <summary>
        /// Get a selected extiry by the object primary key ID
        /// </summary>
        /// <param name="id">Primary key ID</param>
        TEntityDto GetSingle(Expression<Func<TEntity, bool>> whereCondition);

        /// <summary> 
        /// Add entity to the repository 
        /// </summary> 
        /// <param name="entity">the entity to add</param> 
        /// <returns>The added entity</returns> 
        void Insert(TEntityDto entityDto);
        void Insert(List<TEntityDto> entityDtoList);

        /// <summary> 
        /// Mark entity to be deleted within the repository 
        /// </summary> 
        /// <param name="entity">The entity to delete</param> 
        void Delete(TEntityDto entityDto);
        void Delete(List<TEntityDto> entityDtoList);

        /// <summary> 
        /// Updates entity within the the repository 
        /// </summary> 
        /// <param name="entity">the entity to update</param> 
        /// <returns>The updates entity</returns>         
        void Update(TEntityDto entityDto);
        void Update(List<TEntityDto> entityDtoList);
        /// <summary> 
        /// Load the entities using a linq expression filter
        /// </summary> 
        /// <typeparam name="E">the entity type to load</typeparam> 
        /// <param name="where">where condition</param> 
        /// <returns>the loaded entity</returns> 
        IList<TEntityDto> GetAll(Expression<Func<TEntity, bool>> whereCondition);
        IList<TEntityDto> GetAll(Expression<Func<TEntity, bool>> whereCondition, int page, int pageCount);

        /// <summary>
        /// Get all the element of this repository
        /// </summary>
        /// <returns></returns>
        IList<TEntityDto> GetAll();
        IList<TEntityDto> GetAll(int page,int pageCount);

        /// <summary> 
        /// Query entities from the repository that match the linq expression selection criteria
        /// </summary> 
        /// <typeparam name="E">the entity type to load</typeparam> 
        /// <param name="where">where condition</param> 
        /// <returns>the loaded entity</returns> 
         IQueryable<TEntity> GetQueryable();

        /// <summary>
        /// Count using a filer
        /// </summary>
         long Count(Expression<Func<TEntity, bool>> whereCondition);

        /// <summary>
        /// All item count
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        long Count();
    }
}
