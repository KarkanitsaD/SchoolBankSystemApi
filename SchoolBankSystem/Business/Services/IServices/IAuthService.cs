using Business.Models.Auth;
using Business.Models.Student;
using Business.Models.Teacher;

namespace Business.Services.IServices
{
    public interface IAuthService
    {
        Task RegisterStudentAsync(RegisterModel registerModel);

        Task RegisterTeacherAsync(RegisterModel registerModel);

        Task<AuthenticationStudentModel> LoginStudentAsync(LoginModel loginModel);

        Task<AuthenticationTeacherModel> LoginTeacherAsync(LoginModel loginModel);
    }
}