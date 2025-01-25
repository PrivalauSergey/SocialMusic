using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace SM.Home.API.Endpoints.Account.Models
{
    public class LoginResponse
    {
        [JsonPropertyName("token")]
        public string Token { get; set; }
    }
}
