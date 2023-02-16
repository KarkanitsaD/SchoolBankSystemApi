using Business.Models.Login;
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

    [HttpPost]
    [Route("register/teacher")]
    public async Task<IActionResult> RegisterTeacher(LoginModel loginModel)
    {
        return Ok();
    }

    [HttpPost]
    [Route("register/student")]
    public async Task<IActionResult> RegisterStudent(LoginModel loginModel)
    {
        return Ok();
    }
}