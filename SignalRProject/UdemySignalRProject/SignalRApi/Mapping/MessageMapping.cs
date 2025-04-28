using AutoMapper;
using DTOLayer.CommunicationDTOs;
using EntityLayer.Entities.Concrete;

namespace SignalRApi.Mapping
{
	public class MessageMapping:Profile
	{
        public MessageMapping()
        {
            CreateMap<CreateCommunicationDTO,communication>().ReverseMap();
            CreateMap<ResultCommunicationDTO,communication>().ReverseMap();
        }
    }
}
