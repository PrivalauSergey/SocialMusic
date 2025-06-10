using System.Collections.Generic;
using System.Threading.Tasks;
using System.Threading;
using SM.Channel.API.Models.Responses;

namespace SM.Channel.API.Services
{
    public interface IChannelService
    {
        Task<IEnumerable<ChannelDetailsResponse>> GetChannelsByUserIdAsync(long userId, CancellationToken cancellationToken);

        Task<ChannelDetailsResponse> GetChannelByIdAsync(long id, CancellationToken cancellationToken);

        Task<ChannelDetailsResponse> CreateChannelAsync(string name, long createdBy, CancellationToken cancellationToken);

        Task AddUserToChannelAsync(long channelId, long userId, CancellationToken cancellationToken);

        Task UpdateChannelAsync(long id, string newName, CancellationToken cancellationToken);

        Task DeleteChannelAsync(long id, CancellationToken cancellationToken);
    }
}