using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SM.Channel.API.Data;
using SM.Channel.API.Data.Entities;
using SM.Channel.API.Repositories.Interfaces;

namespace SM.Channel.API.Repositories
{
    public class UserRepository : IUserRepository
    {
        public readonly ApplicationDbContext _dbContext;

        public UserRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;

        }

        public async Task<AspNetUser> GetUserByIdAsync(long userId, CancellationToken cancellationToken)
        {
            return await _dbContext.AspNetUsers
                .FirstOrDefaultAsync(u => u.Id == userId, cancellationToken);
        }
    }
}
