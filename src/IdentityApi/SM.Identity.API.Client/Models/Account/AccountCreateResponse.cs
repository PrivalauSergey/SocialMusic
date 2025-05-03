using System.Text.Json.Serialization;

namespace SM.Identity.API.Client.Models.Account
{
    public class AccountCreateResponse
    {
        [JsonPropertyName("token")]
        public string Token { get; set; }
    }
}