using System.Threading.Tasks;
using System.Threading;
using ChannelEntity = SM.Channel.API.Data.Entities.Channel;

namespace SM.Channel.API.Repositories.Interfaces
{
    public interface IChannelRepository
    {
        Task<ChannelEntity> GetChannelByIdAsync(long channelId, CancellationToken cancellationToken);

        Task AddAsync(ChannelEntity channel, CancellationToken cancellationToken);

        Task UpdateAsync(ChannelEntity channel, CancellationToken cancellationToken);

        Task DeleteAsync(ChannelEntity channel, CancellationToken cancellationToken);
    }
}