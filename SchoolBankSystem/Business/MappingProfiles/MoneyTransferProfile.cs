using AutoMapper;
using Business.Models.MoneyTransfer;
using DAL.Entities;

namespace Business.MappingProfiles
{
    public class MoneyTransferProfile : Profile
    {
        public MoneyTransferProfile()
        {
            CreateMap<MoneyTransfer, MoneyTransferModel>()
                .ForMember(x => x.StudentFromName, act => act.MapFrom(x => x.StudentFrom.Name))
                .ForMember(x => x.StudentFromSurname, act => act.MapFrom(x => x.StudentFrom.Surname))
                .ForMember(x => x.StudentToName, act => act.MapFrom(x => x.StudentTo.Name))
                .ForMember(x => x.StudentToSurname, act => act.MapFrom(x => x.StudentTo.Surname));
        }
    }
}