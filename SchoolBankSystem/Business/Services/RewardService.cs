using AutoMapper;
using Business.Models.Reward;
using Business.Services.IServices;
using DAL.Entities;
using DAL.Repositories.IRepositories;

namespace Business.Services
{
    public class RewardService : IRewardService
    {
        private readonly IMapper _mapper;
        private readonly IRepository<Reward> _rewardRepository;

        public RewardService
        (
            IRepository<Reward> rewardRepository,
            IMapper mapper
        )
        {
            _rewardRepository = rewardRepository;
            _mapper = mapper;
        }

        public async Task<RewardModel> AddAsync(AddRewardModel rewardModel)
        {
            var reward = _mapper.Map<AddRewardModel, Reward>(rewardModel);
            await _rewardRepository.CreateAsync(reward);
            var result = _mapper.Map<Reward, RewardModel>(reward);

            return result;
        }

        public async Task<List<RewardModel>> GetAllAsync()
        {
            var rewards = await _rewardRepository.GetAllAsync(x => true);
            var models = _mapper.Map<List<Reward>, List<RewardModel>>(rewards);

            return models;
        }

        public async Task<RewardModel> GetAsync(Guid id)
        {
            var reward = await _rewardRepository.GetFirstAsync(x => x.Id == id);
            if(reward == null)
            {
                throw new Exception("Reward not found.");
            }

            var model = _mapper.Map<Reward, RewardModel>(reward);

            return model;
        }

        public async Task<RewardModel> UpdateAsync(RewardModel rewardModel)
        {
            var reward = _mapper.Map<RewardModel, Reward>(rewardModel);
            await _rewardRepository.UpdateAsync(reward);

            return rewardModel;
        }
    }
}
