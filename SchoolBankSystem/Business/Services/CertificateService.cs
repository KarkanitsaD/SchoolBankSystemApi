using AutoMapper;
using Business.Models.Certificate;
using Business.Services.IServices;
using DAL.Entities;
using DAL.Repositories.IRepositories;

namespace Business.Services
{
    public class CertificateService : ICertificateService
    {
        private readonly IRepository<Certificate> _repository;
        private readonly IMapper _mapper;

        public CertificateService(IRepository<Certificate> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<CertificateModel> AddCertificateAsync(AddCertificateModel addModel)
        {
            var certificate = _mapper.Map<AddCertificateModel, Certificate>(addModel);
            await _repository.CreateAsync(certificate);
            var result = _mapper.Map<Certificate, CertificateModel>(certificate);

            return result;
        }

        public async Task<CertificateModel> UpdateCertificateAsync(CertificateModel certificateModel)
        {
            var certificate = _mapper.Map<CertificateModel, Certificate>(certificateModel);
            await _repository.UpdateAsync(certificate);

            return certificateModel;
        }

        public async Task DeleteCertificateAsync(Guid certificateId)
        {
            await _repository.DeleteAsync(x => x.Id == certificateId);
        }
    }
}
