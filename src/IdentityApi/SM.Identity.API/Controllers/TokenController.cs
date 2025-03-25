using Microsoft.AspNetCore.Mvc;
using SM.Identity.API.Models.Login;
using SM.Identity.API.Services;
using System.Net;
using System.Threading.Tasks;

namespace SM.Identity.API.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
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
            var response = await _accountService.LoginByNameOrEmailAsync(loginRequest.Login, loginRequest.Password);
            return response.StatusCode switch
            {
                HttpStatusCode.OK => Ok(response.Data),
                HttpStatusCode.BadRequest => BadRequest(),
                _ => StatusCode((int)HttpStatusCode.InternalServerError)
            };
        }
    }
}
