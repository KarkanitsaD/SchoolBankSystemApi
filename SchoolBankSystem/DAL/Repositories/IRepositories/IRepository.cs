using Microsoft.EntityFrameworkCore.Storage;
using System.Linq.Expressions;

namespace DAL.Repositories.IRepositories
{
    public interface IRepository<TEntity> where TEntity : class
    {
        Task<List<TEntity>> GetAllAsync(Expression<Func<TEntity, bool>> predicate);

        Task<TEntity> GetFirstAsync(Expression<Func<TEntity, bool>> predicate);

        Task<int> CountAsync(Expression<Func<TEntity, bool>> predicate);

        Task<bool> AnyAsync(Expression<Func<TEntity, bool>> predicate);

        Task<TEntity> CreateAsync(TEntity entity);

        Task<TEntity> UpdateAsync(TEntity entity);

        Task<List<TEntity>> UpdateRangeAsync(List<TEntity> entities);

        Task<int> DeleteAsync(Expression<Func<TEntity, bool>> predicate);

        Task<IDbContextTransaction> BeginTransactionAsync();
    }
}