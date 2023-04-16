using AutoMapper;
using Business.Models.Teacher;
using Business.Services.IServices;
using DAL.Entities;
using DAL.Repositories.IRepositories;
using System.Linq.Expressions;

namespace Business.Services
{
    public class TeacherService : ITeacherService
    {
        private readonly IMapper _mapper;
        private readonly IRepository<Teacher> _teacherRepository;

        public TeacherService(IRepository<Teacher> teacherRepository, IMapper mapper)
        {
            _teacherRepository= teacherRepository;
            _mapper = mapper;
        }

        public async Task<List<TeacherModel>> GetAllAsync(TeacherFilterModel teacherFilterModel)
        {
            Expression<Func<Teacher, bool>> filterPredicate = _ => true;

            if (teacherFilterModel != null)
            {
                filterPredicate = x =>
                (teacherFilterModel.Name == null || x.Name.ToLower().StartsWith(teacherFilterModel.Name.ToLower())) &&
                (teacherFilterModel.Surname == null || x.Surname.ToLower().StartsWith(teacherFilterModel.Surname.ToLower())) &&
                (teacherFilterModel.Phone == null || x.Phone.ToLower().StartsWith(teacherFilterModel.Phone.ToLower()));
            }

            var teachers = await _teacherRepository.GetAllAsync(filterPredicate);
            var result = _mapper.Map<List<Teacher>, List<TeacherModel>>(teachers);

            return result;
        }

        public async Task UpdateAsync(TeacherModel model)
        {
            var teacher = await _teacherRepository.GetFirstAsync(x => x.Id == model.Id);
            if (teacher == null)
            {
                throw new Exception("Not Found.");
            }

            teacher.Name = model.Name;
            teacher.Surname = model.Surname;
            teacher.Phone = model.Phone;
            await _teacherRepository.UpdateAsync(teacher);
        }

        public async Task DeleteAsync(Guid id)
        {
            var teacher = await _teacherRepository.GetFirstAsync(x => x.Id == id);
            if (teacher == null)
            {
                throw new Exception("Not Found.");
            }

            teacher.IsDeleted = true;
            await _teacherRepository.UpdateAsync(teacher);
        }
    }
}
