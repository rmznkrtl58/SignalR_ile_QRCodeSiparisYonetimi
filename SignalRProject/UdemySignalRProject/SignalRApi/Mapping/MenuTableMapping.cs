using AutoMapper;
using DTOLayer.MenuTableDTOs;
using EntityLayer.Entities.Concrete;

namespace SignalRApi.Mapping
{
	public class MenuTableMapping:Profile
	{
        public MenuTableMapping()
        {
            CreateMap<MenuTable, ResultMenuTableDTO>().ReverseMap();
            CreateMap<MenuTable, CreateMenuTableDTO>().ReverseMap();
            CreateMap<MenuTable, UpdateMenuTableDTO>().ReverseMap();
        }
    }
}
