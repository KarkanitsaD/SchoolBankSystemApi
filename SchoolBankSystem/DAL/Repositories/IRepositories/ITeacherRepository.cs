using DAL.Entities;
using System.Linq.Expressions;

namespace DAL.Repositories.IRepositories
{
    public interface ITeacherRepository : IRepository<Teacher>
    {
        Task<Teacher> GetFullTeacherAsync(Expression<Func<Teacher, bool>> predicate);
    }
}