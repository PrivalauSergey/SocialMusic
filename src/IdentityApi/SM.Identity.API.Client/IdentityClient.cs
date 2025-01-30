using System.Text;
using Newtonsoft.Json;
using SM.Identity.API.Client.Models.Account;
using SM.Identity.API.Client.Models.Login;

namespace SM.Identity.API.Client
{
    public class IdentityClient : IIdentityClient
    {
        private readonly HttpClient _httpClient;

        public IdentityClient(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<AccountCreateResponse> CreateAccount(AccountCreateRequest createRequest)
        {
            var content = new StringContent(JsonConvert.SerializeObject(createRequest), Encoding.UTF8, "application/json");
            var response = await _httpClient.PostAsync("/api/v1/account/accounts", content);
            var responseContent = await response.Content.ReadAsStringAsync();
            
            return JsonConvert.DeserializeObject<AccountCreateResponse>(responseContent);
        }

        public async Task<UserLoginResponse> Login(UserLoginRequest loginRequest)
        {
            var content = new StringContent(JsonConvert.SerializeObject(loginRequest), Encoding.UTF8, "application/json");
            var response = await _httpClient.PostAsync("/api/v1/token/login", content);
            var responseContent = await response.Content.ReadAsStringAsync();
            
            return JsonConvert.DeserializeObject<UserLoginResponse>(responseContent);
        }
    }
}
