using Business.Models.CertificatePurchase;

namespace Business.Services.IServices
{
    public interface ICertificatePurchaseService
    {
        Task<CertificatePurchaseModel> PurchaseAsync(Guid certificateId);

        Task<CertificatePurchaseModel> ActivateAsync(Guid purchaseId);
    }
}
