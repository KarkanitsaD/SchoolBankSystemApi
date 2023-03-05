using Business.Constants;
using Business.Models.Reward;
using Business.Services.IServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class RewardController : ControllerBase
    {
        private readonly IRewardService _rewardService;

        public RewardController(IRewardService rewardService)
        {
            _rewardService = rewardService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result = await _rewardService.GetAllAsync();

            return Ok(result);
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> Get(Guid id)
        {
            var result = await _rewardService.GetAsync(id);

            return Ok(result);
        }

        
        [HttpPost]
        [Authorize(Policy = Roles.Teacher)]
        public async Task<IActionResult> Add(AddRewardModel model)
        {
            var result = await _rewardService.AddAsync(model);

            return Ok(result);
        }

        [HttpPut]
        [Authorize(Policy = Roles.Teacher)]
        public async Task<IActionResult> Update(RewardModel model)
        {
            var result = await _rewardService.UpdateAsync(model);

            return Ok(result);
        }
    }
}
