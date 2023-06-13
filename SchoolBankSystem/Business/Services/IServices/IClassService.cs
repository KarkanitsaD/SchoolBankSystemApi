using Business.Models.Class;

namespace Business.Services.IServices
{
    public interface IClassService
    {
        Task<ClassModel> AddCLassAsync(ClassModel classModel);

        Task RemoveCLassAsync(Guid classId);

        Task<ClassModel> UpdateAsync(ClassModel classModel);

        Task<ClassModel> GetCLassAsync(Guid classId);

        Task<List<ClassModel>> GetAllAsync();
    }
}
