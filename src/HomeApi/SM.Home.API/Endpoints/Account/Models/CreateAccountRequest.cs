using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace SM.Home.API.Endpoints.Account.Models
{
    public class CreateAccountRequest
    {
        [Required]
        [JsonPropertyName("username")]
        public string Username { get; set; }

        [Required]
        [EmailAddress]
        [JsonPropertyName("email")]
        public string Email { get; set; }

        [Required]
        [JsonPropertyName("encryptedPassword")]
        public string EncryptedPassword { get; set; }

        [Required]
        [JsonPropertyName("ivHex")]
        public string IvHex { get; set; }
    }
}
