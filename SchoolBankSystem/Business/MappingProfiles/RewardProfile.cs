using AutoMapper;
using Business.Models.Reward;
using DAL.Entities;

namespace Business.MappingProfiles
{
    public class RewardProfile : Profile
    {
        public RewardProfile()
        {
            CreateMap<Reward, RewardModel>().ReverseMap();
            CreateMap<AddRewardModel, Reward>();
        }
    }
}