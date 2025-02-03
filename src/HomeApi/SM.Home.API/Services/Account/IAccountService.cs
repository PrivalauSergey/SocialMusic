using SM.Home.API.Clients.IndentityClient.Models;
using SM.Home.API.Endpoints.Account.Models;
using System.Threading.Tasks;

namespace SM.Home.API.Services
{
    public interface IAccountService
    {
        public Task<CreateAccountModel> CreateAccount(string login, string password, string email);

        Task<LoginResponse> Login(string login, string password);
    }
}
