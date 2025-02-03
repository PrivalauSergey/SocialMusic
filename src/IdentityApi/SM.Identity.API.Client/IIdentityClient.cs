using SM.Identity.API.Client.Models;
using SM.Identity.API.Client.Models.Account;
using SM.Identity.API.Client.Models.Login;

namespace SM.Identity.API.Client
{
    public interface IIdentityClient
    {
        Task<AccountCreateResponse> CreateAccount(AccountCreateRequest createRequest);
        Task<UserLoginResponse> Login(UserLoginRequest loginRequest);
    }
}
