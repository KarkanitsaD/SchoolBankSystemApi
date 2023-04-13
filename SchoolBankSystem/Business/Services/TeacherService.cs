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
    }
}
