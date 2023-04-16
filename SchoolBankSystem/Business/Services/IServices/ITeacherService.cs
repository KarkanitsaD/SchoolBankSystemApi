using Business.Models.Teacher;

namespace Business.Services.IServices
{
    public interface ITeacherService
    {
        Task<List<TeacherModel>> GetAllAsync(TeacherFilterModel teacherFilterModel);

        Task UpdateAsync(TeacherModel teacher);

        Task DeleteAsync(Guid id);
    }
}
