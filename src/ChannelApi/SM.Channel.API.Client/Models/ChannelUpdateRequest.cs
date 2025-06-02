using System.Text.Json.Serialization;

namespace SM.Channel.API.Client.Models
{
    public class ChannelUpdateRequest
    {
        [JsonPropertyName("channelId")]
        public long ChannelId { get; set; }

        [JsonPropertyName("channelName")]
        public string ChannelName { get; set; }
    }
}
