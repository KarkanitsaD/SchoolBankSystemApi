using AutoMapper;
using Business.Models.Teacher;
using DAL.Entities;

namespace Business.MappingProfiles
{
    public class TeacherProfile : Profile
    {
        public TeacherProfile()
        {
            CreateMap<Teacher, TeacherModel>();
        }
    }
}