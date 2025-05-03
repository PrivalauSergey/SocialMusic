using System.Text.Json.Serialization;

namespace SM.Identity.API.Models.Login
{
    public class UserLoginRequest
    {
        [JsonPropertyName("login")]
        public string Login { get; set; }

        [JsonPropertyName("encrryptPassword")]
        public string EncrryptPassword { get; set; }

        [JsonPropertyName("ivHex")]
        public string IvHex { get; set; }
    }
}