using AutoMapper;
using Business.Models.MoneyTransfer;
using DAL.Entities;

namespace Business.MappingProfiles
{
    public class MoneyTransferProfile : Profile
    {
        public MoneyTransferProfile()
        {
            CreateMap<MoneyTransfer, MoneyTransferModel>();
        }
    }
}