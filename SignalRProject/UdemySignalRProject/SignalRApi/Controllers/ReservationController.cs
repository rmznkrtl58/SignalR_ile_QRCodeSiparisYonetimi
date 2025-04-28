using AutoMapper;
using BusinessLogicLayer.Abstract;
using DTOLayer.ReservationDTOs;
using EntityLayer.Entities.Concrete;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;

namespace SignalRApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReservationController : ControllerBase
    {
        private readonly IReservationService _reservationService;
        private readonly IMapper _mapper;
        private readonly IValidator<CreateReservationDTO> _validator;//fluent validation kullanımı
        public ReservationController(IReservationService reservationService, IMapper mapper, IValidator<CreateReservationDTO> validator)
        {
            _reservationService = reservationService;
            _mapper = mapper;
            _validator = validator;
        }

        [HttpGet]
        public IActionResult GetListReservation()
        {
            var values = _mapper.Map<List<ResultReservationDTO>>(_reservationService.TGetListReservationByPendingConfirmation());
			return Ok(values);
        }
        [HttpGet("{id}")]
        public IActionResult GetReservation(int id)
        {
            var findReservation = _mapper.Map<ResultReservationDTO>(_reservationService.TGetById(id));
            return Ok(findReservation);
        }
        [HttpPost]
        public IActionResult CreateReservation(CreateReservationDTO p)
        {
            var validator = _validator.Validate(p);
            if (!validator.IsValid)//eğer doğrulama sağlanmadıysa
            {
                return BadRequest(validator.Errors);
            }
            else
            {
                _reservationService.TInsert(new Reservation
                {
                    Mail = p.Mail,
                    NameSurname = p.NameSurname,
                    PersonCount = p.PersonCount,
                    Phone = p.Phone,
                    ReservationDate = p.ReservationDate,
                    DeleteStatus = true,
                    ReservationStatus = false
                });
                return Ok("Rezervasyon Başarıyla Eklendi.");
            }
        }
        [HttpPut]
        public IActionResult UpdateReservation(UpdateReservationDTO p)
        {
            _reservationService.TUpdate(new Reservation
            {
                Mail=p.Mail,
                NameSurname= p.NameSurname,
                PersonCount=p.PersonCount,
                Phone = p.Phone,
                ReservationDate= p.ReservationDate,
                ReservationId=p.ReservationId,
                DeleteStatus=true,
                ReservationStatus=false
            });
            return Ok("Reservasyon Başarıyla Güncellendi.");
        }
        [HttpDelete("{id}")]
        public IActionResult DeleteReservation(int id)
        {
            var findReservation=_reservationService.TGetById(id);
            _reservationService.TDelete(findReservation);
            return Ok("Rezervasyon Başarıyla Silindi.");
        }
        [HttpGet("ConfirmReservation/{id}")]
        public IActionResult ConfirmReservation(int id)
        {
            _reservationService.TConfirmReservation(id);
			return Ok("Rezervasyon Başarıyla Onaylandı.");
        }
	}
}
