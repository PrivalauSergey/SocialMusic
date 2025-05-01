using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
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

        public async Task<ApiResponse<AccountCreateResponse>> CreateAccount(AccountCreateRequest createRequest)
        {
            var content = new StringContent(JsonSerializer.Serialize(createRequest), Encoding.UTF8, "application/json");
            var response = await _httpClient.PostAsync("/api/v1/account/accounts", content);
            
            var result = new ApiResponse<AccountCreateResponse>
            {
                StatusCode = response.StatusCode,
                Data = null
            };

            if (response.IsSuccessStatusCode)
            {
                var responseContent = await response.Content.ReadAsStringAsync();
                result.Data = JsonSerializer.Deserialize<AccountCreateResponse>(responseContent);
                return result;
            }

            return result;
        }

        public async Task<ApiResponse<UserLoginResponse>> Login(UserLoginRequest loginRequest)
        {
            var content = new StringContent(JsonSerializer.Serialize(loginRequest), Encoding.UTF8, "application/json");
            var response = await _httpClient.PostAsync("/api/v1/token/login", content);

            var result = new ApiResponse<UserLoginResponse>
            {
                StatusCode = response.StatusCode,
                Data = null
            };

            if (response.IsSuccessStatusCode)
            {
                var responseContent = await response.Content.ReadAsStringAsync();
                result.Data = JsonSerializer.Deserialize<UserLoginResponse>(responseContent);
                return result;
            }

            return result;
        }
    }
}
