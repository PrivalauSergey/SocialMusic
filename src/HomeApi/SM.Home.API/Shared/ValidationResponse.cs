using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace SM.Home.API.Shared
{
    public class ValidationResponse
    {
        [JsonPropertyName("error")]
        public string Error { get; set; }

        [JsonPropertyName("data")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public IDictionary<string, string[]> Data { get; set; }
    }
}
