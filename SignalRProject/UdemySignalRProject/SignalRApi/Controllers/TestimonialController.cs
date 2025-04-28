using AutoMapper;
using BusinessLogicLayer.Abstract;
using DTOLayer.SocialMediaDTOs;
using DTOLayer.TestimonialDTOs;
using EntityLayer.Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace SignalRApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestimonialController : ControllerBase
    {
        private readonly ITestimonialService _testimonialService;
        private readonly IMapper _mapper;

        public TestimonialController(ITestimonialService testimonialService, IMapper mapper)
        {
            _testimonialService = testimonialService;
            _mapper = mapper;
        }
        [HttpGet]
        public IActionResult GetListTestimonial()
        {
            var values = _mapper.Map<List<ResultTestimonialDTO>>(_testimonialService.TGetListAll());
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
        public IActionResult GetTestimonial(int id)
        {
            var findTestimonial = _mapper.Map<GetTestimonialDTO>(_testimonialService.TGetById(id));
            if (findTestimonial == null)
            {
                return NotFound();
            }
            {
                return Ok(findTestimonial);
            }
        }
        [HttpPost]
        public IActionResult CreateTestimonial(CreateTestimonialDTO p)
        {
            var value = _mapper.Map<Testimonial>(p);
            _testimonialService.TInsert(value);
            return Ok("Referans Başarıyla Eklendi.");
        }
        [HttpPut]
        public IActionResult UpdateTestimonial(UpdateTestimonialDTO p)
        {
			var value = _mapper.Map<Testimonial>(p);
			_testimonialService.TUpdate(value);
			return Ok("Referans Başarıyla Güncellendi.");
        }
        [HttpDelete("{id}")]
        public IActionResult DeleteSocialMedia(int id)
        {
            var findTestimonial = _testimonialService.TGetById(id);
            if (findTestimonial == null)
            {
                return NotFound();
            }
            else
            {
                _testimonialService.TDelete(findTestimonial);
                return Ok("Referans Başarıyla Silindi.");
            }
        }
    }
}
