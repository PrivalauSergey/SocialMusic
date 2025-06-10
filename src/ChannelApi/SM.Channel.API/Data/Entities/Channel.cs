using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SM.Channel.API.Data.Entities
{
    public class Channel
    {
        [Key]
        public long ChannelId { get; set; }

        public string ChannelName { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        public long CreatedBy { get; set; }

        public ICollection<ChannelUser> ChannelUsers { get; set; }
    }
}