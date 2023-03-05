using Business.Models.Reward;

namespace Business.Services.IServices
{
    public interface IRewardService
    {
        Task<List<RewardModel>> GetAllAsync();

        Task<RewardModel> GetAsync(Guid id);

        Task<RewardModel> AddAsync(AddRewardModel rewardModel);

        Task<RewardModel> UpdateAsync(RewardModel rewardModel);
    }
}
