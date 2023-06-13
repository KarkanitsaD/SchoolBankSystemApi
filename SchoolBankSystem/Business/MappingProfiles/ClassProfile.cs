using AutoMapper;
using Business.Models.Class;
using DAL.Entities;

namespace Business.MappingProfiles
{
    public class ClassProfile : Profile
    {
        public ClassProfile()
        {
            CreateMap<ClassModel, Class>().ReverseMap();
        }
    }
}
