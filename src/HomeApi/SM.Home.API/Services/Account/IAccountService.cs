using SM.Home.API.Endpoints.Account.Models;
using SM.Identity.API.Client;
using SM.Identity.API.Client.Models;
using SM.Identity.API.Client.Models.Account;
using SM.Identity.API.Client.Models.Login;
using System.Net.Http;
using System.Threading.Tasks;

namespace SM.Home.API.Services
{
    public interface IAccountService
    {
        Task<ApiResponse<AccountCreateResponse>> CreateAccount(
            string login,
            string password,
            string email,
            string ivHex);

        Task<ApiResponse<UserLoginResponse>> Login(
            string login,
            string password,
            string ivHex);
    }
}
