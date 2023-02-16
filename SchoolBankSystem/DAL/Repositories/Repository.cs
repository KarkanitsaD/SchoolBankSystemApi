using DAL.Repositories.IRepositories;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace DAL.Repositories
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        protected DbContext DbContext;

        protected DbSet<TEntity> DbSet { get; set; }

        public Repository(DbContext dbContext)
        {
            DbContext = dbContext;
            DbSet = DbContext.Set<TEntity>();
        }

        public async Task<List<TEntity>> GetAllAsync(Expression<Func<TEntity, bool>> predicate)
        {
            var result = await DbSet.Where(predicate).ToListAsync();

            return result;
        }

        public async Task<int> CountAsync(Expression<Func<TEntity, bool>> predicate)
        {
            return await DbSet.Where(predicate).CountAsync();
        }

        public async Task<bool> AnyAsync(Expression<Func<TEntity, bool>> predicate)
        {
            return await DbSet.Where(predicate).AnyAsync();
        }

        public async Task<TEntity> CreateAsync(TEntity entity)
        {
            await DbSet.AddAsync(entity);
            await DbContext.SaveChangesAsync();

            return entity;
        }

        public async Task<TEntity> UpdateAsync(TEntity entity)
        {
            DbSet.Update(entity);
            await DbContext.SaveChangesAsync();

            return entity;
        }

        public async Task<List<TEntity>> UpdateRangeAsync(List<TEntity> entities)
        {
            DbSet.UpdateRange(entities);
            await DbContext.SaveChangesAsync();

            return entities;
        }

        public async Task<int> DeleteAsync(Expression<Func<TEntity, bool>> predicate)
        {
            var items = DbSet.Where(predicate);
            var result = await items.CountAsync();
            if (result > 0)
            {
                DbSet.RemoveRange(items);
                await DbContext.SaveChangesAsync();
            }

            return result;
        }
    }
}