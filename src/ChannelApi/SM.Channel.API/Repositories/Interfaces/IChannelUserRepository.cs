using SM.Channel.API.Data.Entities;
using System.Threading.Tasks;
using System.Threading;
using System.Collections.Generic;

namespace SM.Channel.API.Repositories.Interfaces
{
    public interface IChannelUserRepository
    {
        Task<IEnumerable<Data.Entities.Channel>> GetChannelsByUserIdAsync(long userId, CancellationToken cancellationToken);

        Task AddUserToChannelAsync(ChannelUser channelUser, CancellationToken cancellationToken);

        Task<bool> IsUserInChannelAsync(long channelId, long userId, CancellationToken cancellationToken);
    }
}
