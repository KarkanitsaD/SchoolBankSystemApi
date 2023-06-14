using AutoMapper;
using Business.Exceptions;
using Business.Helpers;
using Business.Models.Auth;
using Business.Models.Student;
using Business.Models.Teacher;
using Business.Services.IServices;
using DAL.Entities;
using DAL.Repositories.IRepositories;
using System.Security.Claims;
using File = DAL.Entities.File;

namespace Business.Services
{
    public class AuthService : IAuthService
    {
        private readonly IMapper _mapper;
        private readonly ITokenService _tokenService;
        private readonly IStudentRepository _studentRepository;
        private readonly ITeacherRepository _teacherRepository;

        public AuthService
        (
            IMapper mapper,
            ITokenService tokenService,
            IStudentRepository studentRepository,
            ITeacherRepository teacherRepository
        )
        {
            _mapper = mapper;
            _tokenService = tokenService;
            _studentRepository = studentRepository;
            _teacherRepository = teacherRepository;
        }

        public async Task RegisterStudentAsync(RegisterModel registerModel)
        {
            if (await _studentRepository.AnyAsync(x => x.Phone == registerModel.Phone))
            {
                throw new Exception($"Student with {registerModel.Phone} phone number already exists.");
            }

            var student = _mapper.Map<RegisterModel, Student>(registerModel);
            student.PasswordHash = GetPasswordHash(registerModel.Password);
            student.Image = new File
            {
                Extension = registerModel.ImageExtension,
                Content = Base64Converter.Base64ToBytes(registerModel.ImageBase64)
            };
            await _studentRepository.CreateAsync(student);
        }

        public async Task RegisterTeacherAsync(RegisterModel registerModel)
        {
            if (await _teacherRepository.AnyAsync(x => x.Phone == registerModel.Phone))
            {
                throw new Exception($"Teacher with {registerModel.Phone} phone number already exists.");
            }

            var teacher = _mapper.Map<RegisterModel, Teacher>(registerModel);
            teacher.PasswordHash = GetPasswordHash(registerModel.Password);
            await _teacherRepository.CreateAsync(teacher);
        }

        public async Task<AuthenticationStudentModel> LoginStudentAsync(LoginModel loginModel)
        {
            var passwordHash = GetPasswordHash(loginModel.Password);
            var studentEntity = await _studentRepository.GetFullStudentAsync(x => x.Phone == loginModel.Phone && x.PasswordHash == passwordHash);
            if (studentEntity == null)
            {
                throw new NotAuthenticatedException();
            }

            var student = _mapper.Map<Student, StudentModel>(studentEntity);
            var jwt = _tokenService.GenerateStudentJwt(student);
            var authModel = new AuthenticationStudentModel(student, jwt);

            return authModel;
        }

        public async Task<AuthenticationTeacherModel> LoginTeacherAsync(LoginModel loginModel)
        {
            var passwordHash = GetPasswordHash(loginModel.Password);
            var teacherEntity = await _teacherRepository.GetFullTeacherAsync(x => x.Phone == loginModel.Phone && x.PasswordHash == passwordHash);
            if (teacherEntity == null)
            {
                throw new NotAuthenticatedException();
            }

            var teacher = _mapper.Map<Teacher, TeacherModel>(teacherEntity);
            var jwt = _tokenService.GenerateTeacherJwt(teacher);
            var authModel = new AuthenticationTeacherModel(teacher, jwt);

            return authModel;
        }

        public async Task<AuthenticationTeacherModel> AuthenticateTeacherAsync(ClaimsPrincipal user)
        {
            var claimId = user.Claims.Where(x => x.Type == ClaimTypes.NameIdentifier).First().Value;
            var id = Guid.Parse(claimId);
            var teacherEntity = await _teacherRepository.GetFullTeacherAsync(x => x.Id == id);

            var teacher = _mapper.Map<Teacher, TeacherModel>(teacherEntity);
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