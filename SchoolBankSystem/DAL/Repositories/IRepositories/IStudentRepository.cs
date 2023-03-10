using DAL.Entities;
using System.Linq.Expressions;

namespace DAL.Repositories.IRepositories
{
    public interface IStudentRepository : IRepository<Student>
    {
        Task<Student> GetFullStudentAsync(Expression<Func<Student, bool>> predicate);
    }
}