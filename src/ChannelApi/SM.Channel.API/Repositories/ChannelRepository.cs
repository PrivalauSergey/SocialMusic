using Microsoft.EntityFrameworkCore;
using SM.Channel.API.Data;
using System.Threading.Tasks;
using System.Threading;
using SM.Channel.API.Repositories.Interfaces;
using ChannelEntity = SM.Channel.API.Data.Entities.Channel;

namespace SM.Channel.API.Repositories
{
    public class ChannelRepository : IChannelRepository
    {
        public readonly ApplicationDbContext _dbContext;

        public ChannelRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<ChannelEntity> GetChannelByIdAsync(long channelId, CancellationToken cancellationToken)
        {
            return await _dbContext.Channels
                .FirstOrDefaultAsync(c => c.ChannelId == channelId, cancellationToken);
        }

        public async Task AddAsync(ChannelEntity channel, CancellationToken cancellationToken)
        {
            _dbContext.Channels.Add(channel);
            await _dbContext.SaveChangesAsync(cancellationToken);
        }

        public async Task UpdateAsync(ChannelEntity channel, CancellationToken cancellationToken)
        {
            _dbContext.Channels.Update(channel);
            await _dbContext.SaveChangesAsync(cancellationToken);
        }

        public async Task DeleteAsync(ChannelEntity channel, CancellationToken cancellationToken)
        {
            _dbContext.Channels.Remove(channel);
            await _dbContext.SaveChangesAsync(cancellationToken);
        }
    }
}