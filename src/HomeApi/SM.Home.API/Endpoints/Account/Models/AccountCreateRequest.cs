using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace SM.Home.API.Endpoints.Account.Models
{
    public class AccountCreateRequest
    {
        [Required]
        [JsonPropertyName("username")]
        public string Username { get; set; }

        [EmailAddress]
        [JsonPropertyName("email")]
        public string Email { get; set; }

        [PasswordPropertyText]
        [JsonPropertyName("password")]
        public string Password { get; set; }
    }
}
