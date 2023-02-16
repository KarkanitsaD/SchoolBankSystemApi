using AutoMapper;
using Business.Models.Student;
using DAL.Entities;

namespace Business.MappingProfiles
{
    public class StudentProfile : Profile
    {
        public StudentProfile()
        {
            CreateMap<Student, StudentModel>();
        }
    }
}