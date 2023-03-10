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
                .Include(x => x.CertificatePurchases)
                .Include(x => x.MoneyTransfersFromStudent)
                .Include(x => x.MoneyTransfersToStudent)
                .Include(x => x.StudentRewards)
                .Where(predicate)
                .FirstOrDefaultAsync();

            return result;
        }
    }
}