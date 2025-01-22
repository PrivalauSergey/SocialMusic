using SM.Home.API.Clients.IndentityClient;
using SM.Home.API.Clients.IndentityClient.Models;
using SM.Home.API.Endpoints.Account.Models;
using System.Threading.Tasks;

namespace SM.Home.API.Services
{
    public class AccountService : IAccountService
    {
        private readonly IIdentityApiClient _indetityApiClient;

        public AccountService(IIdentityApiClient indetityApiClient)
        {
            _indetityApiClient = indetityApiClient;
        }

        public async Task<CreateAccountModel> CreateAccount(string login, string password, string email)
        {
            return await _indetityApiClient.CreateAccount(login, password, email);
        }

        public async Task<LoginResponse> Login(string login, string password)
        {
            return await _indetityApiClient.Login(login, password);
        }
    }
}
