using Business.Models.MoneyTransfer;

namespace Business.Services.IServices
{
    public interface IMoneyTransferService
    {
        Task<MoneyTransferModel> TransferMoneyAsync(TransferMoneyModel transferModel);
    }
}
