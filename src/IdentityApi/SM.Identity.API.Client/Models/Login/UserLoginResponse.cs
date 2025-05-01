using System.Text.Json.Serialization;

namespace SM.Identity.API.Client.Models.Login
{
    public class UserLoginResponse
    {
        [JsonPropertyName("token")]
        public string Token { get; set; }
    }
}
