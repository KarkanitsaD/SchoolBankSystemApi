using AutoMapper;
using Business.Models.Class;
using Business.Services.IServices;
using DAL.Entities;
using DAL.Repositories.IRepositories;

namespace Business.Services
{
    public class ClassService : IClassService
    {
        private readonly IRepository<Class> _repository;
        private readonly IMapper _mapper;
        public ClassService(IRepository<Class> repository, IMapper mapper) 
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<ClassModel> AddCLassAsync(ClassModel classModel)
        {
            var classEntity = _mapper.Map<ClassModel, Class>(classModel);
            classEntity = await _repository.CreateAsync(classEntity);
            var result = _mapper.Map<Class, ClassModel>(classEntity);

            return result;
        }

        public async Task<List<ClassModel>> GetAllAsync()
        {
            var classes = await _repository.GetAllAsync(_ => true);
            var result = _mapper.Map<List<Class>, List<ClassModel>>(classes);

            return result;
        }

        public async Task<ClassModel> GetCLassAsync(Guid classId)
        {
            var classEntity = await _repository.GetFirstAsync(x => x.Id == classId);
            var result = _mapper.Map<Class, ClassModel>(classEntity);

            return result;
        }

        public async Task RemoveCLassAsync(Guid classId)
        {
            await _repository.DeleteAsync(x => x.Id == classId);
        }

        public async Task<ClassModel> UpdateAsync(ClassModel classModel)
        {
            var entity = _mapper.Map<ClassModel, Class>(classModel);
            entity = await _repository.UpdateAsync(entity);
            var result = _mapper.Map<Class, ClassModel>(entity);

            return result;
        }

    }
}
