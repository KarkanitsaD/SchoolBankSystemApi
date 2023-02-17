using Business.Models.Student;
using Business.Models.Teacher;

namespace Business.Services.IServices;

public interface ITokenService
{
    string GenerateStudentJwt(StudentModel student);

    string GenerateTeacherJwt(TeacherModel teacher);
}