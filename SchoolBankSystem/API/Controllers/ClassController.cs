using Business.Constants;
using Business.Models.Class;
using Business.Services.IServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ClassController : ControllerBase
    {
        private readonly IClassService _classService;

        public ClassController(IClassService classService) 
        {
            _classService = classService;
        }

        [HttpGet]
        [Route("{id}")]
        [Authorize(Policy = Roles.Teacher)]
        public async Task<IActionResult> GetAsync(Guid id)
        {
            var result = await _classService.GetCLassAsync(id);

            return Ok(result);
        }

        [HttpGet]
        [Authorize(Policy = Roles.Teacher)]
        public async Task<IActionResult> GetAll()
        {
            var result = await _classService.GetAllAsync();

            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Create(ClassModel classModel)
        {
            var result = await _classService.AddCLassAsync(classModel);

            return Ok(result);
        }

        [HttpPut]
        public async Task<IActionResult> Update(ClassModel classModel)
        {
            var result = await _classService.UpdateAsync(classModel);

            return Ok(result);
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            await _classService.RemoveCLassAsync(id);

            return Ok();
        }
    }
}
