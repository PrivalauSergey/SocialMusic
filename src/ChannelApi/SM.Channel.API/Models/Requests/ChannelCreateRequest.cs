namespace SM.Channel.API.Models.Requests
{
    public class ChannelCreateRequest
    {
        public long UserId { get; set; }

        public string ChannelName { get; set; }
    }
}