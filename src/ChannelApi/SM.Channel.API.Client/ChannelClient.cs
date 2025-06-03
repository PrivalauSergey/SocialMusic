using System.Collections.Generic;
using System.Net.Http;
using SM.Channel.API.Client.Models;
using System.Text;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;

namespace SM.Channel.API.Client
{
    public class ChannelClient : IChannelClient
    {
        private readonly HttpClient _httpClient;

        public ChannelClient(IHttpClientFactory httpClientFactory)
        {
            _httpClient = httpClientFactory.CreateClient();
        }

        public async Task<ApiResponse<IEnumerable<ChannelDetailsResponse>>> GetChannelsByUserIdAsync(long userId, CancellationToken cancellationToken = default)
        {
            var response = await _httpClient.GetAsync($"api/v1/Channel/user/{userId}", cancellationToken);
            var result = new ApiResponse<IEnumerable<ChannelDetailsResponse>>
            {
                StatusCode = response.StatusCode,
                Data = null
            };

            if (response.IsSuccessStatusCode)
            {
                var responseContent = await response.Content.ReadAsStringAsync();
                result.Data = JsonSerializer.Deserialize<IEnumerable<ChannelDetailsResponse>>(responseContent);
            }

            return result;
        }

        public async Task<ApiResponse<ChannelDetailsResponse>> GetChannelByIdAsync(long channelId, CancellationToken cancellationToken = default)
        {
            var response = await _httpClient.GetAsync($"api/v1/Channel/{channelId}", cancellationToken);
            var result = new ApiResponse<ChannelDetailsResponse>
            {
                StatusCode = response.StatusCode,
                Data = null
            };

            if (response.IsSuccessStatusCode)
            {
                var responseContent = await response.Content.ReadAsStringAsync();
                result.Data = JsonSerializer.Deserialize<ChannelDetailsResponse>(responseContent);
            }

            return result;
        }

        public async Task<ApiResponse<object>> CreateChannelAsync(ChannelCreateRequest request, CancellationToken cancellationToken = default)
        {
            var content = new StringContent(JsonSerializer.Serialize(request), Encoding.UTF8, "application/json");
            var response = await _httpClient.PostAsync("api/v1/Channel", content, cancellationToken);
            return new ApiResponse<object>
            {
                StatusCode = response.StatusCode,
                Data = null
            };
        }

        public async Task<ApiResponse<object>> AddUserToChannelAsync(long channelId, long userId, CancellationToken cancellationToken = default)
        {
            var response = await _httpClient.PostAsync($"api/v1/Channel/{channelId}/users/{userId}", null, cancellationToken);
            return new ApiResponse<object>
            {
                StatusCode = response.StatusCode,
                Data = null
            };
        }

        public async Task<ApiResponse<object>> UpdateChannelAsync(ChannelUpdateRequest request, CancellationToken cancellationToken = default)
        {
            var content = new StringContent(JsonSerializer.Serialize(request), Encoding.UTF8, "application/json");
            var response = await _httpClient.PutAsync("api/v1/Channel", content, cancellationToken);
            return new ApiResponse<object>
            {
                StatusCode = response.StatusCode,
                Data = null
            };
        }

        public async Task<ApiResponse<object>> DeleteChannelAsync(long channelId, CancellationToken cancellationToken = default)
        {
            var response = await _httpClient.DeleteAsync($"api/v1/Channel/{channelId}", cancellationToken);
            return new ApiResponse<object>
            {
                StatusCode = response.StatusCode,
                Data = null
            };
        }
    }
}
