using SM.Identity.API.Client.Models;
using SM.Identity.API.Client.Models.Account;
using SM.Identity.API.Client.Models.Login;

namespace SM.Identity.API.Client
{
    public interface IIdentityClient
    {
        Task<ApiResponse> CreateAccount(AccountCreateRequest createRequest);
        Task<ApiResponse> Login(UserLoginRequest loginRequest);
    }
}
