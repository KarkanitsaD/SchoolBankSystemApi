using AutoMapper;
using DAL.Entities;

namespace Business.MappingProfiles
{
    public class MoneyTransferProfile : Profile
    {
        public MoneyTransferProfile()
        {
            CreateMap<MoneyTransfer, MoneyTransferProfile>();
        }
    }
}