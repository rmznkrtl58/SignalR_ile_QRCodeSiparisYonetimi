using AutoMapper;
using BusinessLogicLayer.Abstract;
using DTOLayer.ContactDTOs;
using EntityLayer.Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace SignalRApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactController : ControllerBase
    {
        private readonly IContactService _contactService;
        private readonly IMapper _mapper;
        public ContactController(IContactService contactService, IMapper mapper)
        {
            _contactService = contactService;
            _mapper = mapper;
        }
        [HttpGet]
        public IActionResult GetListContact()
        {
            var values = _mapper.Map<List<ResultContactDTO>>(_contactService.TGetListAll());
            return Ok(values);
        }
        [HttpGet("{id}")]
        public IActionResult GetContact(int id)
        {
            var findContact = _mapper.Map<GetContactDTO>(_contactService.TGetById(id));
            return Ok(findContact);
        }
        [HttpPost]
        public IActionResult CreateContact(CreateContactDTO p)
        {
            var value = _mapper.Map<Contact>(p);
            _contactService.TInsert(value);
            return Ok("İletişim Başarıyla Eklendi.");
        }
        [HttpPut]
        public IActionResult UpdateContact(UpdateContactDTO p)
        {
			var value = _mapper.Map<Contact>(p);
			_contactService.TUpdate(value);
			return Ok("İletişim Başarıyla Güncellendi.");
        }
        [HttpDelete]
        public IActionResult DeleteContact(int id)
        {
            var findContact = _contactService.TGetById(id);
            _contactService.TDelete(findContact);
            return Ok("İletişim Başarıyla Silindi.");
        }
    }
}
