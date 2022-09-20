using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using VCard.Core.Entities;
using VCard.Core.Repositories.Abstract;

namespace VCard.Core.Repositories.Concrete
{
    public class EFRepositoryBase<TEntity,TContext> : IRepository<TEntity>
    where TEntity :class,IEntity,new()
    where  TContext:DbContext,new()
   
    {
        public async Task<IEnumerable<TEntity>> GetAllAsync(Expression<Func<TEntity, bool>> filter = null)
        {
            using (TContext context=new TContext())
            {
                 return filter == null
                    ? await context.Set<TEntity>().ToListAsync()
                    :await context.Set<TEntity>().Where(filter).ToListAsync();
            }
        }

        public async Task<TEntity> GetAsync(Expression<Func<TEntity, bool>> filter)
        {
            using (TContext context = new TContext())
            {
                return await context.Set<TEntity>().SingleOrDefaultAsync(filter);
            }
        }

        public async Task<TEntity> AddAsync(TEntity entity)
        {
            using (TContext context = new TContext())
            {
                context.Entry(entity).State = EntityState.Added;
                await context.SaveChangesAsync();
                return entity;
            }
        }

        public async Task<TEntity> UpdateAsync(TEntity entity)
        {
            using (TContext context = new TContext())
            {
                context.Entry(entity).State = EntityState.Modified;
                await context.SaveChangesAsync();
                return entity;
            }
        }

        public async Task<TEntity> DeleteAsync(TEntity entity)
        {
            using (TContext context = new TContext())
            {
                context.Entry(entity).State = EntityState.Deleted;
                await context.SaveChangesAsync();
                return entity;
            }
        }

        public async Task<IEnumerable<TEntity>> GetAllAsyncByCount(Expression<Func<TEntity, bool>> filter = null, int count = 0)
        {
            using (TContext context = new TContext())
            {
                return filter == null
                   ? await context.Set<TEntity>().Take(count).ToListAsync()
                   : await context.Set<TEntity>().Where(filter).Take(count).ToListAsync();
            }
        }
    }
}
