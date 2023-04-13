using Business.Models.Certificate;

namespace Business.Services.IServices
{
    public interface ICertificateService
    {
        Task<List<CertificateModel>> GetAllAsync(CertificateFilterModel filterModel);

        Task<CertificateModel> AddCertificateAsync(AddCertificateModel addModel);

        Task<CertificateModel> UpdateCertificateAsync(CertificateModel certificateModel);

        Task DeleteCertificateAsync(Guid certificateId);
    }
}
