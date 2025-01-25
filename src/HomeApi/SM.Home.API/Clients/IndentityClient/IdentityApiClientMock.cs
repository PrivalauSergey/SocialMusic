using SM.Home.API.Clients.IndentityClient.Models;
using SM.Home.API.Endpoints.Account.Models;
using System.Threading.Tasks;

namespace SM.Home.API.Clients.IndentityClient
{
    public class IdentityApiClientMock : IIdentityApiClient
    {
        public async Task<CreateAccountModel> CreateAccount(string login, string password, string email)
        {
            return await Task.FromResult(new CreateAccountModel());
        }

        public async Task<LoginResponse> Login(string login, string password)
        {
            return await Task.FromResult(new LoginResponse { Token = "token" });
        }
    }
}
