using AutoMapper;
using BusinessLogicLayer.Abstract;
using DTOLayer.CommunicationDTOs;
using EntityLayer.Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace SignalRApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MessageController : ControllerBase
    {
        private readonly ICommunicationService _communicationService;
        private readonly IMapper _mapper;

		public MessageController(ICommunicationService communicationService, IMapper mapper)
		{
			_communicationService = communicationService;
			_mapper = mapper;
		}
		[HttpGet]
        public IActionResult GetCommunicationList()
        {
            var values = _mapper.Map<ResultCommunicationDTO>(_communicationService.TGetListAll());
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
        public  IActionResult CreateMessage(CreateCommunicationDTO c)
        {
            var value = _mapper.Map<communication>(c);
            _communicationService.TInsert(value);
            return Ok("Mesaj Başarıyla Admine Gönderildi");
        }
    }
}
