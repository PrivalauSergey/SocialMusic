using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace SM.Home.API.Endpoints.Account.Models
{
    public class LogInResponse
    {
        [JsonPropertyName("token")]
        public string Token { get; set; }
    }
}
