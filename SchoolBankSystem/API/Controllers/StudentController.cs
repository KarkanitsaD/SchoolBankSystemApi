using Business.Models.Student;
using Business.Services.IServices;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class StudentController : ControllerBase
    {
        private readonly IStudentService _studentService;

        public StudentController(IStudentService studentService)
        {
            _studentService = studentService;
        }

        [HttpPost]
        [Route("search")]
        public async Task<IActionResult> GetAllAsync(StudentFilterModel studentFilterModel)
        {
            var result = await _studentService.GetAllAsync(studentFilterModel);

            return Ok(result);
        }
    }
}