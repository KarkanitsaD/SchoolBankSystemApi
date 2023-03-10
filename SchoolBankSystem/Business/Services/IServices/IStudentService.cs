using Business.Models.Student;

namespace Business.Services.IServices
{
    public interface IStudentService
    {
        Task<List<StudentModel>> GetAllAsync(StudentFilterModel studentFilterModel);
    }
}