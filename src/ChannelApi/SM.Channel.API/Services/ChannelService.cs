using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using SM.Channel.API.Data.Entities;
using SM.Channel.API.Exceptions;
using SM.Channel.API.Models.Responses;
using SM.Channel.API.Repositories.Interfaces;

namespace SM.Channel.API.Services
{
    public class ChannelService : IChannelService
    {
        private readonly IChannelRepository _channelRepository;
        private readonly IUserRepository _userRepository;
        private readonly IChannelUserRepository _channelUserRepository;
        private readonly IMapper _mapper;

        public ChannelService(
            IChannelRepository channelRepository, 
            IUserRepository userRepository, 
            IChannelUserRepository channelUserRepository, 
            IMapper mapper)
        {
            _channelRepository = channelRepository;
            _userRepository = userRepository;
            _channelUserRepository = channelUserRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<ChannelDetailsResponse>> GetChannelsByUserIdAsync(long userId, CancellationToken cancellationToken)
        {
            var channels =  await _channelUserRepository.GetChannelsByUserIdAsync(userId, cancellationToken);

            return _mapper.Map<IEnumerable<ChannelDetailsResponse>>(channels);
        }

        public async Task<ChannelDetailsResponse> GetChannelByIdAsync(long id, CancellationToken cancellationToken)
        {
            var channel = await _channelRepository.GetChannelByIdAsync(id, cancellationToken);

            return _mapper.Map<ChannelDetailsResponse>(channel);
        }

        public async Task<ChannelDetailsResponse> CreateChannelAsync(string name, long createdBy, CancellationToken cancellationToken)
        {
            _ = await _userRepository.GetUserByIdAsync(createdBy, cancellationToken)
                ?? throw new NotFoundException($"User with ID {createdBy} does not exist.");

            var channel = new Data.Entities.Channel
            {
                ChannelName = name,
                CreatedBy = createdBy,
                CreatedAt = DateTime.UtcNow
            };

            await _channelRepository.AddAsync(channel, cancellationToken);

            await _channelUserRepository.AddUserToChannelAsync(new ChannelUser
            {
                ChannelId = channel.ChannelId,
                UserId = createdBy,
                JoinedAt = DateTime.Now
            }, cancellationToken);

            return _mapper.Map<ChannelDetailsResponse>(channel);
        }

        public async Task AddUserToChannelAsync(long channelId, long userId, CancellationToken cancellationToken)
        {
            _ = await _channelRepository.GetChannelByIdAsync(channelId, cancellationToken) 
                ?? throw new NotFoundException($"Channel with ID {channelId} does not exist.");
            
            _ = await _userRepository.GetUserByIdAsync(userId, cancellationToken) 
                ?? throw new NotFoundException($"User with ID {userId} does not exist.");

            if (await _channelUserRepository.IsUserInChannelAsync(channelId, userId, cancellationToken))
                throw new ValidationException("User is already a member of the channel.");

            await _channelUserRepository.AddUserToChannelAsync(new ChannelUser
            {
                ChannelId = channelId,
                UserId = userId,
                JoinedAt = DateTime.UtcNow
            }, cancellationToken);
        }

        public async Task UpdateChannelAsync(long id, string newName, CancellationToken cancellationToken)
        {
            var channel = await _channelRepository.GetChannelByIdAsync(id, cancellationToken);

            if (channel == null)
                throw new NotFoundException($"Channel with ID {id} does not exist.");

            channel.ChannelName = newName;
            await _channelRepository.UpdateAsync(channel, cancellationToken);
        }

        public async Task DeleteChannelAsync(long id, CancellationToken cancellationToken)
        {
            var channel = await _channelRepository.GetChannelByIdAsync(id, cancellationToken);

            if (channel == null)
                throw new NotFoundException($"Channel with ID {id} does not exist.");

            await _channelRepository.DeleteAsync(channel, cancellationToken);
        }
    }
}