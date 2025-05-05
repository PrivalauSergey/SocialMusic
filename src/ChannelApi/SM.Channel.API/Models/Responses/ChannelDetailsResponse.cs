using System;

namespace SM.Channel.API.Models.Responses
{
    public class ChannelDetailsResponse
    {
        public long ChannelId { get; set; }

        public string ChannelName { get; set; }

        public DateTime CreatedAt { get; set; }

        public long CreatedBy { get; set; }
    }
}