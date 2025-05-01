using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace SM.Home.API.Endpoints.Account.Models
{
    public class LoginRequest
    {
        [Required]
        [JsonPropertyName("login")]
        public string Login { get; set; }

        [Required]
        [JsonPropertyName("password")]
        public string EncryptedPassword { get; set; }

        [Required]
        [JsonPropertyName("ivHex")]
        public string IvHex { get; set; }
    }
}
