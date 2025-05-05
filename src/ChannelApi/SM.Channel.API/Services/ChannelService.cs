using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using SM.Channel.API.Data;
using SM.Channel.API.Data.Entities;
using SM.Channel.API.Exceptions;
using SM.Channel.API.Models.Responses;

namespace SM.Channel.API.Services
{
    public class ChannelService : IChannelService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public ChannelService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<IEnumerable<ChannelDetailsResponse>> GetChannelsByUserIdAsync(long userId, CancellationToken cancellationToken)
        {
            var channels =  await _unitOfWork.ChannelUserRepository.GetChannelsByUserIdAsync(userId, cancellationToken);

            return _mapper.Map<IEnumerable<ChannelDetailsResponse>>(channels);
        }

        public async Task<ChannelDetailsResponse> GetChannelByIdAsync(long id, CancellationToken cancellationToken)
        {
            var channel = await _unitOfWork.ChannelRepository.GetChannelByIdAsync(id, cancellationToken);

            return _mapper.Map<ChannelDetailsResponse>(channel);
        }

        public async Task<ChannelDetailsResponse> CreateChannelAsync(string name, long createdBy, CancellationToken cancellationToken)
        {
            _ = await _unitOfWork.UserRepository.GetUserByIdAsync(createdBy, cancellationToken)
                ?? throw new NotFoundException($"User with ID {createdBy} does not exist.");

            var channel = new Data.Entities.Channel
            {
                ChannelName = name,
                CreatedBy = createdBy,
                CreatedAt = DateTime.UtcNow
            };

            await _unitOfWork.ChannelRepository.AddAsync(channel, cancellationToken);
            return _mapper.Map<ChannelDetailsResponse>(channel);
        }

        public async Task AddUserToChannelAsync(long channelId, long userId, CancellationToken cancellationToken)
        {
            _ = await _unitOfWork.ChannelRepository.GetChannelByIdAsync(channelId, cancellationToken) 
                ?? throw new NotFoundException($"Channel with ID {channelId} does not exist.");
            
            _ = await _unitOfWork.UserRepository.GetUserByIdAsync(userId, cancellationToken) 
                ?? throw new NotFoundException($"User with ID {userId} does not exist.");

            if (await _unitOfWork.ChannelUserRepository.IsUserInChannelAsync(channelId, userId, cancellationToken))
                throw new ValidationException("User is already a member of the channel.");

            await _unitOfWork.ChannelUserRepository.AddUserToChannelAsync(new ChannelUser
            {
                ChannelId = channelId,
                UserId = userId,
                JoinedAt = DateTime.UtcNow
            }, cancellationToken);
        }

        public async Task UpdateChannelAsync(long id, string newName, CancellationToken cancellationToken)
        {
            var channel = await _unitOfWork.ChannelRepository.GetChannelByIdAsync(id, cancellationToken);

            if (channel == null)
                throw new NotFoundException($"Channel with ID {id} does not exist.");

            channel.ChannelName = newName;
            await _unitOfWork.ChannelRepository.UpdateAsync(channel, cancellationToken);
        }

        public async Task DeleteChannelAsync(long id, CancellationToken cancellationToken)
        {
            var channel = await _unitOfWork.ChannelRepository.GetChannelByIdAsync(id, cancellationToken);

            if (channel == null)
                throw new NotFoundException($"Channel with ID {id} does not exist.");

            await _unitOfWork.ChannelRepository.DeleteAsync(channel, cancellationToken);
        }
    }
}