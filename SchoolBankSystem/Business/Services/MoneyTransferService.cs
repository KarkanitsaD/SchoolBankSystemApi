using AutoMapper;
using Business.Models.MoneyTransfer;
using Business.Services.IServices;
using DAL.Entities;
using DAL.Repositories.IRepositories;
using Microsoft.AspNetCore.Http;
using System.Security.Claims;

namespace Business.Services
{
    public class MoneyTransferService : IMoneyTransferService
    {
        private readonly IRepository<MoneyTransfer> _moneyTransferRepository;
        private readonly IRepository<Student> _studentRepository;
        private readonly IHttpContextAccessor _contextAccessor;
        private readonly IMapper _mapper;

        public MoneyTransferService
        (
            IRepository<MoneyTransfer> moneyTransferRepository,
            IRepository<Student> studentRepository,
            IHttpContextAccessor contextAccessor,
            IMapper mapper
        )
        {
            _moneyTransferRepository = moneyTransferRepository;
            _studentRepository = studentRepository;
            _contextAccessor = contextAccessor;
            _mapper = mapper;
        }

        public async Task<MoneyTransferModel> TransferMoneyAsync(TransferMoneyModel transferModel)
        {
            var studentIdFromClaim = _contextAccessor.HttpContext.User.Claims.First(x => x.Type == ClaimTypes.NameIdentifier);
            var studentFromId = new Guid(studentIdFromClaim.Value);

            if (studentFromId == transferModel.StudentToId)
            {
                throw new Exception("It is impossible to transfer money to yourself.");
            }

            var studentFrom = await _studentRepository.GetFirstAsync(x => x.Id == studentFromId);

            if (studentFrom.Sum < transferModel.Sum)
            {
                throw new Exception("Not enough funds for transaction.");
            }

            var studentTo = await _studentRepository.GetFirstAsync(x => x.Id == transferModel.StudentToId);

            using var transaction = await _moneyTransferRepository.BeginTransactionAsync();

            studentFrom.Sum -= transferModel.Sum;
            studentTo.Sum += transferModel.Sum;
            var moneyTransfer = new MoneyTransfer
            {
                StudentFromId = studentFromId,
                StudentToId = transferModel.StudentToId,
                Sum = transferModel.Sum,
                Time = DateTime.Now
            };

            await _studentRepository.UpdateRangeAsync(new List<Student> { studentFrom, studentTo });
            await _moneyTransferRepository.CreateAsync(moneyTransfer);

            await transaction.CommitAsync();

            moneyTransfer.StudentFrom = studentFrom;
            moneyTransfer.StudentTo = studentTo;
            var result = _mapper.Map<MoneyTransfer, MoneyTransferModel>(moneyTransfer);

            return result;
        }
    }
}
