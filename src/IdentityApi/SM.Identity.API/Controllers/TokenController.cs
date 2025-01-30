using Microsoft.AspNetCore.Mvc;
using SM.Identity.API.Models.Login;
using SM.Identity.API.Services.Interfaces;
using System.Threading.Tasks;

namespace SM.Identity.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TokenController : ControllerBase
    {
        private readonly IAccountService _accountService;

        public TokenController(IAccountService accountService)
        {
            _accountService = accountService;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] UserLoginRequest loginRequest)
        {
            var token = await _accountService.LoginAsync(loginRequest.Login, loginRequest.Password);
            if (token != null)
                return Ok(new UserLoginResponse {Token = token});

            return Unauthorized();
        }
    }
}
