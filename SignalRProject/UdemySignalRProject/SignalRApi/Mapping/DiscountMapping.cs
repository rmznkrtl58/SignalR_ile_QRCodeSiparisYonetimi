using AutoMapper;
using DTOLayer.DiscountDTOs;
using EntityLayer.Entities.Concrete;

namespace SignalRApi.Mapping
{
    public class DiscountMapping:Profile
    {
        public DiscountMapping()
        {
            CreateMap<Discount, ResultDiscountDTO>().ReverseMap();
            CreateMap<Discount, GetDiscountDTO>().ReverseMap();
            CreateMap<Discount, CreateDiscountDTO>().ReverseMap();
            CreateMap<Discount, UpdateDiscountDTO>().ReverseMap();
        }
    }
}
