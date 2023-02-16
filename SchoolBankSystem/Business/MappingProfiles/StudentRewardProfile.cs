using AutoMapper;
using Business.Models.StudentReward;
using DAL.Entities;

namespace Business.MappingProfiles
{
    public class StudentRewardProfile : Profile
    {
        public StudentRewardProfile()
        {
            CreateMap<StudentReward, StudentRewardModel>();
        }
    }
}