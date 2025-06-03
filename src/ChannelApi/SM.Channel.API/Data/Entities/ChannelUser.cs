using System;
using System.ComponentModel.DataAnnotations;

namespace SM.Channel.API.Data.Entities
{
    public class ChannelUser
    {
        [Key]
        public long ChannelUserId { get; set; }

        public long ChannelId { get; set; }

        public long UserId { get; set; }

        public DateTime JoinedAt { get; set; } = DateTime.UtcNow;

        public AspNetUser User { get; set; }

        public Channel Channel { get; set; }
    }
}