using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using SM.Identity.API.Models;
using SM.Identity.API.Services.Interfaces;

[ApiController]
[Route("api/[controller]")]
public class AccountController : ControllerBase
{
    private readonly IAccountService _accountService;

    public AccountController(IAccountService accountService)
    {
        _accountService = accountService;
    }

    [HttpPost("users")]
    public async Task<IActionResult> CreateUser([FromBody] UserCreateRequest createRequest)
    {
        var token = await _accountService.CreateUserAsync(createRequest.UserName, createRequest.Email, createRequest.Password);
        return Ok(new { message = "User created successfully", token });
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login([FromBody] UserLoginRequest loginRequest)
    {
        var token = await _accountService.LoginAsync(loginRequest.Login, loginRequest.Password);
        if (token != null)
            return Ok(new { message = "User logged in successfully", token });

        return Unauthorized();
    }
}