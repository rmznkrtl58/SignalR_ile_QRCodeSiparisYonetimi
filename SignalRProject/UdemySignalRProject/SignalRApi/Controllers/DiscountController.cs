using AutoMapper;
using BusinessLogicLayer.Abstract;
using DTOLayer.CategoryDTOs;
using DTOLayer.DiscountDTOs;
using EntityLayer.Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace SignalRApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DiscountController : ControllerBase
    {
        private readonly IDiscountService _discountService;
        private readonly IMapper _mapper;

        public DiscountController(IDiscountService discountService, IMapper mapper)
        {
            _discountService = discountService;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetListDiscount()
        {
            var values = _mapper.Map<List<ResultDiscountDTO>>(_discountService.TGetListAll());
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
        public IActionResult GetDiscount(int id)
        {
            var findDiscount = _mapper.Map<GetDiscountDTO>(_discountService.TGetById(id));
            if (findDiscount == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(findDiscount);
            }
        }
        [HttpPost]
        public IActionResult CreateDiscount(CreateDiscountDTO p)
        {
            var value = _mapper.Map<Discount>(p);
            _discountService.TInsert(value);
            return Ok("İndirim Başarıyla Eklendi.");
        }
        [HttpPut]
        public IActionResult UpdateDiscount(UpdateDiscountDTO p)
        {
			var value = _mapper.Map<Discount>(p);
			_discountService.TUpdate(value);
			return Ok("İndirim Başarıyla Güncellendi.");
        }
        [HttpDelete("{id}")]
        public IActionResult DeleteDiscount(int id)
        {
            var findDiscount = _discountService.TGetById(id);
            _discountService.TDelete(findDiscount);
            return Ok("İndirim Başarıyla Silindi.");
        }
    }
}
