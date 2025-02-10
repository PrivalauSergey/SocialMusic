using Microsoft.AspNetCore.Mvc;
using SM.Identity.API.Models;
using SM.Identity.API.Models.Account;
using SM.Identity.API.Models.Login;
using System.Threading.Tasks;

namespace SM.Identity.API.Services.Interfaces
{
    public interface IAccountService
    {
        Task<ApiResponse<AccountCreateResponse>> CreateAccountAsync(string userName, string email, string password);
        Task<ApiResponse<UserLoginResponse>> LoginAsync(string userName, string password);
    }
}
