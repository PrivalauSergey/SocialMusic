using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SM.Channel.API.Data;
using SM.Channel.API.Data.Entities;
using SM.Channel.API.Repositories.Interfaces;

namespace SM.Channel.API.Repositories
{
    public class ChannelUserRepository : IChannelUserRepository
    {
        private readonly ApplicationDbContext _dbContext;
        public ChannelUserRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<Data.Entities.Channel>> GetChannelsByUserIdAsync(long userId, CancellationToken cancellationToken)
        {
            return await _dbContext.ChannelUsers
                .Where(cu => cu.UserId == userId)
                .Select(cu => cu.Channel)
                .ToListAsync(cancellationToken);
        }


        public async Task AddUserToChannelAsync(ChannelUser channelUser, CancellationToken cancellationToken)
        {
            _dbContext.ChannelUsers.Add(channelUser);
            await _dbContext.SaveChangesAsync(cancellationToken);
        }

        public async Task<bool> IsUserInChannelAsync(long channelId, long userId, CancellationToken cancellationToken)
        {
            return await _dbContext.ChannelUsers
                .AnyAsync(cu => cu.ChannelId == channelId && cu.UserId == userId, cancellationToken);
        }
    }
}
