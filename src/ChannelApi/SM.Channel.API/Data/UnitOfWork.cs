using SM.Channel.API.Repositories.Interfaces;

namespace SM.Channel.API.Data
{
    public class UnitOfWork : IUnitOfWork
    {
        public UnitOfWork(IChannelRepository channelRepository, IUserRepository userRepository, IChannelUserRepository channelUserRepository)
        {
            ChannelRepository = channelRepository;
            UserRepository = userRepository;
            ChannelUserRepository = channelUserRepository;
        }

        public IChannelRepository ChannelRepository { get; }

        public IUserRepository UserRepository { get; }

        public IChannelUserRepository ChannelUserRepository { get; }
    }
}
