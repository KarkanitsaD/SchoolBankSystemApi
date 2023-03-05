using Business.Models.StudentReward;

namespace Business.Services.IServices
{
    public interface IStudentRewardService
    {
        Task<StudentRewardModel> RewardStudentAsync(RewardStudentModel rewardStudentModel);
    }
}
