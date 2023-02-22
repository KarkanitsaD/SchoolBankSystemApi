using Business.Models.Auth;
using Business.Services.IServices;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AuthController : ControllerBase
{
    private readonly IAuthService _authService;

    public AuthController(IAuthService authService)
    {
        _authService = authService;
    }

    [HttpPost]
    [Route("login/student")]
    public async Task<IActionResult> LoginAsStudent(LoginModel loginModel)
    {
        var result = await _authService.LoginStudentAsync(loginModel);

        return Ok(result);
    }

    [HttpPost]
    [Route("login/teacher")]
    public async Task<IActionResult> LoginAsTeacher(LoginModel loginModel)
    {
        var result = await _authService.LoginTeacherAsync(loginModel);

        return Ok(result);
    }

    [HttpPost]
    [Route("register/teacher")]
    public async Task<IActionResult> RegisterTeacher(RegisterModel registerModel)
    {
        await _authService.RegisterTeacherAsync(registerModel);

        return Ok();
    }

    [HttpPost]
    [Route("register/student")]
    public async Task<IActionResult> RegisterStudent(RegisterModel registerModel)
    {
        await _authService.RegisterStudentAsync(registerModel);

        return Ok();
    }
}