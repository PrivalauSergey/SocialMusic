using System;
using System.Text.Json.Serialization;

namespace SM.Channel.API.Client.Models
{
    public class ChannelDetailsResponse
    {
        [JsonPropertyName("channelId")]
        public long ChannelId { get; set; }

        [JsonPropertyName("channelName")]
        public string ChannelName { get; set; }

        [JsonPropertyName("createdAt")]
        public DateTime CreatedAt { get; set; }

        [JsonPropertyName("createdBy")]
        public long CreatedBy { get; set; }
    }
}
