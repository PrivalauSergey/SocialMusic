using SM.Home.API.Endpoints.Account.Models;
using SM.Identity.API.Client.Models;
using SM.Identity.API.Client.Models.Account;
using SM.Identity.API.Client.Models.Login;
using System.Threading.Tasks;

namespace SM.Home.API.Services
{
    public interface IAccountService
    {
        public Task<AccountCreateResponse> CreateAccount(string login, string password, string email);

        public Task<UserLoginResponse> Login(string login, string password);
    }
}
