using Business.Models.Teacher;

namespace Business.Services.IServices
{
    public interface ITeacherService
    {
        Task<List<TeacherModel>> GetAllAsync(TeacherFilterModel teacherFilterModel);
    }
}
