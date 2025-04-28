using AutoMapper;
using DTOLayer.AboutDTOs;
using EntityLayer.Entities.Concrete;

namespace SignalRApi.Mapping
{
    public class AboutMapping:Profile
    {
        //Entitiylerim ile DTO'larımı eşleştiriyorum
        public AboutMapping()
        {
            CreateMap<About, GetAboutDTO>().ReverseMap();
            CreateMap<About,ResultAboutDTO>().ReverseMap();
            CreateMap<About,CreateAboutDTO>().ReverseMap();
            CreateMap<About,UpdateAboutDTO>().ReverseMap();
        }
    }
}
