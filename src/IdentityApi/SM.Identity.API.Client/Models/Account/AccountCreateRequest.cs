using System.Text.Json.Serialization;

namespace SM.Identity.API.Client.Models.Account
{
    public class AccountCreateRequest
    {
        [JsonPropertyName("username")]
        public string UserName { get; set; }

        [JsonPropertyName("email")]
        public string Email { get; set; }

        [JsonPropertyName("encrryptPassword")]
        public string EncrryptPassword { get; set; }

        [JsonPropertyName("ivHex")]
        public string IvHex { get; set; }
    }
}
