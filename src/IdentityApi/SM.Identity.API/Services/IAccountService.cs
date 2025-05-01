using Microsoft.AspNetCore.Mvc;
using SM.Identity.API.Models;
using SM.Identity.API.Models.Account;
using SM.Identity.API.Models.Login;
using System.Threading.Tasks;

namespace SM.Identity.API.Services
{
    public interface IAccountService
    {
        Task<ApiResponse<AccountCreateResponse>> CreateAccountAsync(
            string userName,
            string email,
            string encrryptPassword,
            string ivHex);
        Task<ApiResponse<UserLoginResponse>> LoginByNameOrEmailAsync(
            string userName,
            string encrryptPassword,
            string ivHex);
    }
}
