using AutoMapper;
using DTOLayer.ReservationDTOs;
using EntityLayer.Entities.Concrete;

namespace SignalRApi.Mapping
{
    public class ReservationMapping:Profile
    {
        public ReservationMapping()
        {
            CreateMap<Reservation, ResultReservationDTO>().ReverseMap();
            CreateMap<Reservation, GetReservationDTO>().ReverseMap();
            CreateMap<Reservation, CreateReservationDTO>().ReverseMap();
            CreateMap<Reservation, UpdateReservationDTO>().ReverseMap();
        }
    }
}
