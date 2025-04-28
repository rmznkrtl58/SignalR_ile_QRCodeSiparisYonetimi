using AutoMapper;
using DTOLayer.NotificationDTOs;
using EntityLayer.Entities.Concrete;

namespace SignalRApi.Mapping
{
	public class NotificationMapping:Profile
	{
        public NotificationMapping()
        {
            CreateMap<Notification, ResultNotificationDTO>().ReverseMap();
            CreateMap<Notification, CreateNotificationDTO>().ReverseMap();
            CreateMap<Notification, UpdateNotificationDTO>().ReverseMap();
        }
    }
}
