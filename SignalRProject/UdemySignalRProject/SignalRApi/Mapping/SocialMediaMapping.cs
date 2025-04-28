using AutoMapper;
using DTOLayer.SocialMediaDTOs;
using EntityLayer.Entities.Concrete;

namespace SignalRApi.Mapping
{
    public class SocialMediaMapping:Profile
    {
        public SocialMediaMapping()
        {
            CreateMap<SocialMedia, ResultSocialMediaDTO>().ReverseMap();
            CreateMap<SocialMedia,GetSocialMediaDTO>().ReverseMap();
            CreateMap<SocialMedia,CreateSocialMediaDTO>().ReverseMap();
            CreateMap<SocialMedia,UpdateSocialMediaDTO>().ReverseMap();
        }
    }
}
