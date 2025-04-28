using AutoMapper;
using BusinessLogicLayer.Abstract;
using DTOLayer.AboutDTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using EntityLayer.Entities.Concrete;

namespace SignalRApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AboutController : ControllerBase
    {
        private readonly IAboutService _aboutService;
        private readonly IMapper _mapper;

		public AboutController(IAboutService aboutService, IMapper mapper)
		{
			_aboutService = aboutService;
			_mapper = mapper;
		}

		[HttpGet]
        public IActionResult GetListAbout()
        {
            var values = _mapper.Map<List<ResultAboutDTO>>(_aboutService.TGetListAll());
            if (values != null) 
            {
				return Ok(values);
			}
            else
            {
                return NotFound();
            }
        }
        [HttpGet("{id}")]
        public IActionResult GetAbout(int id)
        {
            var findAbout = _mapper.Map<ResultAboutDTO>(_aboutService.TGetById(id));
            if (findAbout == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(findAbout);
            }
           
        }
        [HttpPost]
        public IActionResult CreateAbout(CreateAboutDTO p)
        {
            //_aboutService.TInsert(new About
            //{
            //    Description = p.Description,
            //    ImageUrl = p.ImageUrl,
            //    Title = p.Title
            //});
            //yukarıdaki işlem varya eşleştirme o işlemi maplama yapıyor işte!
           var value=_mapper.Map<About>(p);//about entitymdeki proplarımla "p" parametremden gelen
            //değerlerimi eşleştirdim
            _aboutService.TInsert(value);
            return Ok("Hakkımızda Başarıyla Eklendi.");
        }
        [HttpDelete("{id}")]
        public IActionResult DeleteAbout(int id)
        {
            var findAbout=_aboutService.TGetById(id);
            _aboutService.TDelete(findAbout);
            return Ok("Hakkımda Başarıyla Silindi.");
        }
        [HttpPut]
        public IActionResult UpdateAbout(UpdateAboutDTO p)
        {
            //_aboutService.TUpdate(new About
            //{
            //    AboutId = p.AboutId,
            //    Title = p.Title,
            //    Description = p.Description,
            //    ImageUrl = p.ImageUrl
            //});
            //yukarıdaki işlem varya eşleştirme o işlemi maplama yapıyor işte!
            var value = _mapper.Map<About>(p);
            _aboutService.TUpdate(value);
			return Ok("Hakkımızda Başarıyla Güncellendi.");
        }
    }
}
