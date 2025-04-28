using AutoMapper;
using BusinessLogicLayer.Abstract;
using DTOLayer.FeatureDTOs;
using DTOLayer.ReservationDTOs;
using EntityLayer.Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace SignalRApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FeatureController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IFeatureService _FeatureService;

        public FeatureController(IMapper mapper, IFeatureService featureService)
        {
            _mapper = mapper;
            _FeatureService = featureService;
        }

        [HttpGet]
        public IActionResult GetListFeature()
        {
            var values = _mapper.Map<List<ResultFeatureDTO>>(_FeatureService.TGetListAll());
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
        public IActionResult GetFeature(int id)
        {
            var findFeature = _mapper.Map<GetFeatureDTO>(_FeatureService.TGetById(id));
            if (findFeature == null)
            {
                return NotFound();
            }
            {
                return Ok(findFeature);
            }
        }
        [HttpPost]
        public IActionResult CreateFeature(CreateFeatureDTO p)
        {
            var value = _mapper.Map<Feature>(p);
            _FeatureService.TInsert(value);
            return Ok("Öne Çıkanlar Başarıyla Eklendi.");
        }
        [HttpPut]
        public IActionResult UpdateFeature(UpdateFeatureDTO p)
        {
			var value = _mapper.Map<Feature>(p);
			_FeatureService.TUpdate(value);
			return Ok("Öne Çıkan Başarıyla Güncellendi.");
        }
        [HttpDelete("{id}")]
        public IActionResult DeleteFeature(int id)
        {
            var findFeature = _FeatureService.TGetById(id);
            if (findFeature == null) 
            {
                return NotFound();
            }
            else
            {
                _FeatureService.TDelete(findFeature);
                return Ok("Öne Çıkanlar Başarıyla Silindi.");
            }
        }
    }
}
