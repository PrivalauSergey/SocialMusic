using SM.Channel.API.Data.Entities;
using System.Threading.Tasks;
using System.Threading;

namespace SM.Channel.API.Repositories.Interfaces
{
    public interface IUserRepository
    {
        Task<AspNetUser> GetUserByIdAsync(long userId, CancellationToken cancellationToken);
    }
}
