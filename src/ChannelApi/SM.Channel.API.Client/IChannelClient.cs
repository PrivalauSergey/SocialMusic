using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using SM.Channel.API.Client.Models;

namespace SM.Channel.API.Client
{
    public interface IChannelClient
    {
        Task<ApiResponse<IEnumerable<ChannelDetailsResponse>>> GetChannelsByUserIdAsync(long userId, CancellationToken cancellationToken = default);
        
        Task<ApiResponse<ChannelDetailsResponse>> GetChannelByIdAsync(long channelId, CancellationToken cancellationToken = default);
        
        Task<ApiResponse<object>> CreateChannelAsync(ChannelCreateRequest request, CancellationToken cancellationToken = default);
        
        Task<ApiResponse<object>> AddUserToChannelAsync(long channelId, long userId, CancellationToken cancellationToken = default);
        
        Task<ApiResponse<object>> UpdateChannelAsync(ChannelUpdateRequest request, CancellationToken cancellationToken = default);
        
        Task<ApiResponse<object>> DeleteChannelAsync(long channelId, CancellationToken cancellationToken = default);
    }
}