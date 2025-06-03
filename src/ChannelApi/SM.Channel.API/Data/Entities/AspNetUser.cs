using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SM.Channel.API.Data.Entities
{
    public class AspNetUser
    {
        [Key]
        public long Id { get; set; }

        public string UserName { get; set; }

        public string Email { get; set; }

        public ICollection<ChannelUser> ChannelUsers { get; set; }
    }
}
