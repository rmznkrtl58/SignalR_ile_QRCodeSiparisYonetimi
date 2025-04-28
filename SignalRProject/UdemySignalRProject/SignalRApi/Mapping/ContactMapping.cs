using AutoMapper;
using DTOLayer.ContactDTOs;
using EntityLayer.Entities.Concrete;

namespace SignalRApi.Mapping
{
    public class ContactMapping:Profile
    {
        public ContactMapping()
        {
            CreateMap<Contact, ResultContactDTO>().ReverseMap();
            CreateMap<Contact, GetContactDTO>().ReverseMap();
            CreateMap<Contact, CreateContactDTO>().ReverseMap();
            CreateMap<Contact, UpdateContactDTO>().ReverseMap();
        }
    }
}
