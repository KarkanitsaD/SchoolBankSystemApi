using DAL.Entities;
using System.Linq.Expressions;

namespace DAL.Repositories.IRepositories
{
    public interface ITeacherRepository : IRepository<Teacher>
    {
        Task<Teacher> GetFullTeacher(Expression<Func<Teacher, bool>> predicate);
    }
}