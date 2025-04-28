using BusinessLogicLayer.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace SignalRApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SliderController : ControllerBase
    {
        private readonly ISliderService _sliderService;
       

		public SliderController(ISliderService sliderService)
		{
			_sliderService = sliderService;
		}
		[HttpGet]
        public IActionResult GetList()
        {
            var values = _sliderService.TGetListAll();
            return Ok(values);
        }
    }
}
