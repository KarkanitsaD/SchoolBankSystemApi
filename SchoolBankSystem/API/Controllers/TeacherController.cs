using Business.Models.Teacher;
using Business.Services.IServices;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TeacherController : ControllerBase
    {
        private ITeacherService _teacherService;

        public TeacherController(ITeacherService teacherService) 
        {
            _teacherService = teacherService;
        }

        [HttpPost]
        [Route("search")]
        public async Task<IActionResult> GetAllAsync(TeacherFilterModel teacherFilterModel)
        {
            var result = await _teacherService.GetAllAsync(teacherFilterModel);

            return Ok(result);
        }
    }
}
