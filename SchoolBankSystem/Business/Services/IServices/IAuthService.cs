using Business.Models.Auth;
using Business.Models.Student;
using Business.Models.Teacher;
using System.Security.Claims;
using System.Security.Principal;

namespace Business.Services.IServices
{
    public interface IAuthService
    {
        Task RegisterStudentAsync(RegisterModel registerModel);

        Task RegisterTeacherAsync(RegisterModel registerModel);

        Task<AuthenticationStudentModel> LoginStudentAsync(LoginModel loginModel);

        Task<AuthenticationTeacherModel> LoginTeacherAsync(LoginModel loginModel);

        Task<AuthenticationTeacherModel> AuthenticateTeacherAsync(ClaimsPrincipal user);
    }
}