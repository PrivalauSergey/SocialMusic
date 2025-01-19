using SM.Home.API.Clients.IndentityClient.MockModels;
using System.Threading.Tasks;

namespace SM.Home.API.Clients.IndentityClient
{
    public interface IIndetityApiClientMock
    {
        public Task<CreateAccountModelMock> CreateAccount();
    }
}
