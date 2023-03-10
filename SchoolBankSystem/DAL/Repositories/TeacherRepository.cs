using DAL.Entities;
using DAL.Repositories.IRepositories;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace DAL.Repositories
{
    public class TeacherRepository : Repository<Teacher>, ITeacherRepository
    {
        public TeacherRepository(SchoolBankSystemDbContext dbContext) : base(dbContext)
        {
        }

        public async Task<Teacher> GetFullTeacher(Expression<Func<Teacher, bool>> predicate)
        {
            var result = await DbSet
                .Include(x => x.StudentRewards)
                .Where(predicate).FirstOrDefaultAsync();

            return result;
        }
    }
}