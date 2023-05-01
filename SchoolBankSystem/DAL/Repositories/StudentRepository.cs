using DAL.Entities;
using DAL.Repositories.IRepositories;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace DAL.Repositories
{
    public class StudentRepository : Repository<Student>, IStudentRepository
    {
        public StudentRepository(SchoolBankSystemDbContext dbContext) : base(dbContext)
        {
        }

        public async Task<Student> GetFullStudentAsync(Expression<Func<Student, bool>> predicate)
        {
            var result = await DbSet
                .Include(x => x.CertificatePurchases.OrderByDescending(x => x.Time))

                .Include(x => x.MoneyTransfersFromStudent).ThenInclude(x => x.StudentTo)

                .Include(x => x.MoneyTransfersToStudent).ThenInclude(x => x.StudentFrom)

                .Include(x => x.StudentRewards).ThenInclude(x => x.Teacher)
                .Include(x => x.StudentRewards).ThenInclude(x => x.Reward)

                .Where(predicate)
                .FirstOrDefaultAsync();

            return result;
        }
    }
}