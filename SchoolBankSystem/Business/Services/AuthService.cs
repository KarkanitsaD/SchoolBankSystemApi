using AutoMapper;
using Business.Helpers;
using Business.Models.Auth;
using Business.Models.Student;
using Business.Models.Teacher;
using Business.Services.IServices;
using DAL.Entities;
using DAL.Repositories.IRepositories;

namespace Business.Services
{
    public class AuthService : IAuthService
    {
        private readonly IMapper _mapper;
        private readonly ITokenService _tokenService;
        private readonly IRepository<Student> _studentRepository;
        private readonly IRepository<Teacher> _teacherRepository;

        public AuthService(IMapper mapper, ITokenService tokenService, IRepository<Student> studentRepository, IRepository<Teacher> teacherRepository)
        {
            _mapper = mapper;
            _tokenService = tokenService;
            _studentRepository = studentRepository;
            _teacherRepository = teacherRepository;
        }

        public async Task RegisterStudentAsync(RegisterModel registerModel)
        {
            var student = _mapper.Map<RegisterModel, Student>(registerModel);
            student.PasswordHash = GetPasswordHash(registerModel.Password);
            await _studentRepository.CreateAsync(student);
        }

        public async Task RegisterTeacherAsync(RegisterModel registerModel)
        {
            var teacher = _mapper.Map<RegisterModel, Teacher>(registerModel);
            teacher.PasswordHash = PasswordHasher.GeneratePasswordHash(registerModel.Password);
            await _teacherRepository.CreateAsync(teacher);
        }

        public async Task<AuthenticationStudentModel> LoginStudentAsync(LoginModel loginModel)
        {
            var passwordHash = PasswordHasher.GeneratePasswordHash(loginModel.Password);
            var students = await _studentRepository.GetAllAsync(x => x.Phone == loginModel.Phone && x.PasswordHash == passwordHash);
            if (!students.Any())
            {
                throw new Exception("User not found.");
            }

            var student = _mapper.Map<Student, StudentModel>(students[0]);
            var jwt = _tokenService.GenerateStudentJwt(student);
            var authModel = new AuthenticationStudentModel(student, jwt);

            return authModel;
        }

        public async Task<AuthenticationTeacherModel> LoginTeacherAsync(LoginModel loginModel)
        {
            var passwordHash = GetPasswordHash(loginModel.Password);
            var teachers = await _teacherRepository.GetAllAsync(x => x.Phone == loginModel.Phone && x.PasswordHash == passwordHash);
            if (!teachers.Any())
            {
                throw new Exception("User not found.");
            }

            var teacher = _mapper.Map<Teacher, TeacherModel>(teachers[0]);
            var jwt = _tokenService.GenerateTeacherJwt(teacher);
            var authModel = new AuthenticationTeacherModel(teacher, jwt);

            return authModel;
        }

        private string GetPasswordHash(string password)
        {
            return PasswordHasher.GeneratePasswordHash(password);
        }
    }
}