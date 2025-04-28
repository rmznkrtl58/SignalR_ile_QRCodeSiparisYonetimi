using AutoMapper;
using BusinessLogicLayer.Abstract;
using DTOLayer.ProductDTOs;
using DTOLayer.SocialMediaDTOs;
using EntityLayer.Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace SignalRApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SocialMediaController : ControllerBase
    {
        private readonly ISocialMediaService _socialMediaService;
        private readonly IMapper _mapper;

        public SocialMediaController(ISocialMediaService socialMediaService, IMapper mapper)
        {
            _socialMediaService = socialMediaService;
            _mapper = mapper;
        }
        [HttpGet]
        public IActionResult GetListSocialMedia()
        {
            var values = _mapper.Map<List<ResultSocialMediaDTO>>(_socialMediaService.TGetListAll());
            if (values == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(values);
            }
        }
        [HttpGet("{id}")]
        public IActionResult GetSocialMedia(int id)
        {
            var findSocialMedia = _mapper.Map<GetSocialMediaDTO>(_socialMediaService.TGetById(id));
            if (findSocialMedia == null)
            {
                return NotFound();
            }
            {
                return Ok(findSocialMedia);
            }
        }
        [HttpPost]
        public IActionResult CreateSocialMedia(CreateSocialMediaDTO p)
        {
            var value = _mapper.Map<SocialMedia>(p);
            _socialMediaService.TInsert(value);
            return Ok("Sosyal Medya Hesabı Başarıyla Eklendi.");
        }
        [HttpPut]
        public IActionResult UpdateSocialMedia(UpdateSocialMediaDTO p)
        {
			var value = _mapper.Map<SocialMedia>(p);
			_socialMediaService.TUpdate(value);
			return Ok("Sosyal Medya Hesabı Başarıyla Güncellendi.");
        }
        [HttpDelete("{id}")]
        public IActionResult DeleteSocialMedia(int id)
        {
            var findSocialMedia =_socialMediaService.TGetById(id);
            if (findSocialMedia == null)
            {
                return NotFound();
            }
            else
            {
               _socialMediaService.TDelete(findSocialMedia);
                return Ok("Sosyal Medya Hesabı Başarıyla Silindi.");
            }
        }
    }
}
