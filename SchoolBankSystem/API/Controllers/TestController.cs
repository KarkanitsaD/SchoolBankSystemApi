using Business.Constants;
using DAL.Entities;
using DAL.Repositories.IRepositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TestController : ControllerBase
    {
        private readonly IRepository<Student> _studentRepository;

        public TestController(IRepository<Student> studentRepository)
        {
            _studentRepository = studentRepository;
        }

        [HttpGet("admin")]
        [Authorize(Policy = Roles.Admin)]
        public async Task<IActionResult> TestAdmin()
        {
            return Ok();
        }

        [HttpGet("student")]
        [Authorize(Policy = Roles.Student)]
        public async Task<IActionResult> TestStudent()
        {
            return Ok();
        }

        [HttpGet]
        [Authorize]
        public async Task<IActionResult> Test()
        {
            return Ok();
        }
    }
}