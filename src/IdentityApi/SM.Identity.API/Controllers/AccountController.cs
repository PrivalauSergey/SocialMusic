using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using SM.Identity.API.Services.Interfaces;
using SM.Identity.API.Models.Account;

namespace SM.Identity.API.Controllers
{
    [ApiController]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiVersion("1.0")]
    public class AccountController : ControllerBase
    {
        private readonly IAccountService _accountService;

        public AccountController(IAccountService accountService)
        {
            _accountService = accountService;
        }

        [HttpPost("accounts")]
        public async Task<IActionResult> CreateAccount([FromBody] AccountCreateRequest createRequest)
        {
            var token = await _accountService.CreateAccountAsync(createRequest.UserName, createRequest.Email, createRequest.Password);
            return Ok(new AccountCreateResponse { Token = token });
        }
    }
}