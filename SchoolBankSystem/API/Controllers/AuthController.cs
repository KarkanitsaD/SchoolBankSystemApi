using Business.Models.Request;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AuthController : ControllerBase
{
    [HttpPost]
    [Route("login/student")]
    public async Task<IActionResult> LoginAsStudent(LoginModel loginModel)
    {
        return Ok();
    }

    [HttpPost]
    [Route("login/teacher")]
    public async Task<IActionResult> LoginAsTeacher(LoginModel loginModel)
    {
        return Ok();
    }
}