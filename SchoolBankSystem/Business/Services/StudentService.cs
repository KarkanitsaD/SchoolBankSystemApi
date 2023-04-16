using AutoMapper;
using Business.Models.Student;
using Business.Services.IServices;
using DAL.Entities;
using DAL.Repositories.IRepositories;
using System.Linq.Expressions;

namespace Business.Services
{
    public class StudentService : IStudentService
    {
        private readonly IMapper _mapper;
        private readonly IRepository<Student> _studentRepository;

        public StudentService(IRepository<Student> studentRepository, IMapper mapper)
        {
            _studentRepository = studentRepository;
            _mapper = mapper;
        }

        public async Task<List<StudentModel>> GetAllAsync(StudentFilterModel studentFilterModel)
        {
            Expression<Func<Student, bool>> filterPredicate = _ => true;

            if (studentFilterModel != null)
            {
                filterPredicate = x =>
                    (studentFilterModel.Name == null ||
                     x.Name.ToLower().StartsWith(studentFilterModel.Name.ToLower())) &&
                    (studentFilterModel.Surname == null ||
                     x.Surname.ToLower().StartsWith(studentFilterModel.Surname.ToLower())) &&
                    (studentFilterModel.Phone == null ||
                     x.Phone.ToLower().StartsWith(studentFilterModel.Phone.ToLower())) &&
                    (!studentFilterModel.MinSum.HasValue || x.Sum >= studentFilterModel.MinSum.Value) &&
                    (!studentFilterModel.MaxSum.HasValue || x.Sum <= studentFilterModel.MaxSum.Value);
            }

            var students = await _studentRepository.GetAllAsync(filterPredicate);
            var result = _mapper.Map<List<Student>, List<StudentModel>>(students);

            return result;
        }

        public async Task UpdateAsync(StudentModel studentModel)
        {
            var student = await _studentRepository.GetFirstAsync(x => x.Id == studentModel.Id);
            if (student == null)
            {
                throw new Exception("Not Found.");
            }

            student.Name = studentModel.Name;
            student.Surname = studentModel.Surname;
            student.Phone= studentModel.Phone;
            await _studentRepository.UpdateAsync(student);
        }

        public async Task DeleteAsync(Guid id)
        {
            var student = await _studentRepository.GetFirstAsync(x => x.Id == id);
            if (student == null)
            {
                throw new Exception("Not Found.");
            }

            student.IsDeleted = true;
            await _studentRepository.UpdateAsync(student);
        }
    }
}