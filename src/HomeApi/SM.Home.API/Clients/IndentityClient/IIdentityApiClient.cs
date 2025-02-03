using SM.Home.API.Clients.IndentityClient.Models;
using SM.Home.API.Endpoints.Account.Models;
using System.Threading.Tasks;

namespace SM.Home.API.Clients.IndentityClient
{
    public interface IIdentityApiClient
    {
        public Task<CreateAccountModel> CreateAccount(string login, string password, string email);

        public Task<LoginResponse> Login(string login, string password);
    }
}
