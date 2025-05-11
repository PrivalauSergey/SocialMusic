using AutoMapper;
using SM.Channel.API.Models.Responses;
using ChannelEntity = SM.Channel.API.Data.Entities.Channel;

namespace SM.Channel.API.Mappers
{
    public class AutomapperProfile : Profile
    {
        public AutomapperProfile()
        {
            CreateMap<ChannelEntity, ChannelDetailsResponse>();
        }
    }
}