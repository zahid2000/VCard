using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using VCard.Core.Entities;

namespace VCard.Core.Repositories.Abstract
{
    public interface IRepository<TEntity> where TEntity : class, IEntity, new()
    {
        Task<IEnumerable<TEntity>> GetAllAsync(Expression<Func<TEntity,bool>> filter = null);
        Task<IEnumerable<TEntity>> GetAllAsyncByCount(Expression<Func<TEntity,bool>> filter = null,int count=0);
        Task<TEntity> GetAsync(Expression<Func<TEntity, bool>> filter);
        Task<TEntity> AddAsync(TEntity entity);
        Task<TEntity> UpdateAsync(TEntity entity);
        Task<TEntity> DeleteAsync(TEntity entity);

    }
}
