using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using SM.Identity.API.Services.Interfaces;
using SM.Identity.API.Models.Account;
using System.Net;
using Microsoft.AspNetCore.Http.HttpResults;

namespace SM.Identity.API.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
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
            var response = await _accountService.CreateAccountAsync(createRequest.UserName, createRequest.Email, createRequest.Password);

            return response.StatusCode switch
            {
                HttpStatusCode.OK => Ok(response.Data),
                HttpStatusCode.BadRequest => BadRequest(),
                _ => StatusCode((int)HttpStatusCode.InternalServerError)
            };
        }
    }
}