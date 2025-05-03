using SM.Channel.API.Repositories.Interfaces;

namespace SM.Channel.API.Data
{
    public interface IUnitOfWork
    {
        IChannelRepository ChannelRepository { get; }

        IUserRepository UserRepository { get; }

        IChannelUserRepository ChannelUserRepository { get; }
    }
}
