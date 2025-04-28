using AutoMapper;
using BusinessLogicLayer.Abstract;
using DTOLayer.MenuTableDTOs;
using EntityLayer.Entities.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace SignalRApi.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class MenuTablesController : ControllerBase
	{
		private readonly IMenuTableService _menuTableService;
		private readonly IMapper _mapper;

		public MenuTablesController(IMenuTableService menuTableService, IMapper mapper)
		{
			_menuTableService = menuTableService;
			_mapper = mapper;
		}

		[HttpGet("GetMenuTableCount")]
		public IActionResult GetMenuTableCount()
		{
			var values = _mapper.Map<int>(_menuTableService.TGetMenuTableCount());
			return Ok(values);
		}
		[HttpGet("GetMenuTableList")]
		public IActionResult GetMenuTableList()
		{
			var values = _mapper.Map<List<ResultMenuTableDTO>>(_menuTableService.TGetListAll());
			if (values == null)
			{
				return NotFound();
			}
			else
			{
				return Ok(values);
			}
		}
		[HttpPost]
		public IActionResult CreateMenuTable(CreateMenuTableDTO m)
		{
			var value = _mapper.Map<MenuTable>(m);
			_menuTableService.TInsert(value);
			return Ok("Masa Başarıyla Eklendi");
		}
		[HttpPut]
		public IActionResult UpdateMenuTable(UpdateMenuTableDTO m)
		{
			var value = _mapper.Map<MenuTable>(m);
			_menuTableService.TUpdate(value);
			return Ok("Masa Başarıyla Güncellendi");
		}
		[HttpDelete("{id}")]
		public IActionResult DeleteMenuTable(int id)
		{
			var findMenuTable = _menuTableService.TGetById(id);
			_menuTableService.TDelete(findMenuTable);
			return Ok("Masa Başarıyla Silindi");
		}
		[HttpGet("GetMenuTableById/{id}")]
		public IActionResult GetMenuTableById(int id) 
		{
			var findMenuTable = _mapper.Map<ResultMenuTableDTO>(_menuTableService.TGetById(id));
			if (findMenuTable==null)
			{
				return NotFound();
			}
			else
			{
				return Ok(findMenuTable);
			}
		}
		[HttpGet("ChangeMenuTableStatusActive/{id}")]
		public IActionResult ChangeMenuTableStatusActive(int id)
		{
			//Masa Dolu
			_menuTableService.TChangeMenuTableStatusActive(id);
			return Ok("Masa Aktif Hale Geldi!");
		}
        [HttpGet("ChangeMenuTableStatusPassive/{id}")]
        public IActionResult ChangeMenuTableStatusPassive(int id)
        {    
			//Masa Boş
            _menuTableService.TChangeMenuTableStatusPassive(id);
            return Ok("Masa Pasif Hale Geldi!");
        }

    }
}
