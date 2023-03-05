using Business.Constants;
using Business.Models.StudentReward;
using Business.Services.IServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Authorize(Policy = Roles.Teacher)]
    [Route("api/[controller]")]
    public class StudentRewardController : ControllerBase
    {
        private readonly IStudentRewardService _studentRewardService;

        public StudentRewardController(IStudentRewardService studentRewardService)
        {
            _studentRewardService = studentRewardService;
        }

        [HttpPost]
        [Authorize(Policy = Roles.Teacher)]
        public async Task<IActionResult> Reward([FromBody] RewardStudentModel rewardStudentModel)
        {
            var result = await _studentRewardService.RewardStudentAsync(rewardStudentModel);

            return Ok(result);
        }
    }
}
