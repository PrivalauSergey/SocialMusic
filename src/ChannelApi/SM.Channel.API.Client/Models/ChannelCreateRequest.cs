using System.Text.Json.Serialization;

namespace SM.Channel.API.Client.Models
{
    public class ChannelCreateRequest
    {
        [JsonPropertyName("userId")]
        public long UserId { get; set; }

        [JsonPropertyName("channelName")]
        public string ChannelName { get; set; }
    }
}
