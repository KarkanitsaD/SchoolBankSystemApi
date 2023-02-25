using Business.Models.Certificate;

namespace Business.Services.IServices
{
    public interface ICertificateService
    {
        Task<CertificateModel> AddCertificateAsync(AddCertificateModel addModel);

        Task<CertificateModel> UpdateCertificateAsync(CertificateModel certificateModel);

        Task DeleteCertificateAsync(Guid certificateId);
    }
}
