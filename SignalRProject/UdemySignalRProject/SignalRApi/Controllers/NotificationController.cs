using AutoMapper;
using BusinessLogicLayer.Abstract;
using DTOLayer.NotificationDTOs;
using EntityLayer.Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace SignalRApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NotificationController : ControllerBase
    {
        private readonly INotificationService _notificationService;
        private readonly IMapper _mapper;
		public NotificationController(INotificationService notificationService, IMapper mapper)
		{
			_notificationService = notificationService;
			_mapper = mapper;
		}
		[HttpGet]
        public IActionResult GetNotificationList()
        {
            var values = _mapper.Map<List<ResultNotificationDTO>>(_notificationService.TGetListAll());
            if (values == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(values);
            }
        }
        [HttpGet("GetNotificationCountByFalse")]
        public IActionResult GetNotificationCountByFalse()
        {
            int notificationCount = _mapper.Map<int>(_notificationService.TGetNotificationCountByFalse());
            return Ok (notificationCount);
        }
        [HttpGet("GetNotificationFalse")]
        public IActionResult GetNotificationFalse()
        {
            var values = _mapper.Map<ResultNotificationDTO>(_notificationService.TGetNotificationByFalse());
            if (values == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(values);
            }
        }
        [HttpGet("GetNotificationById/{id}")]
        public ActionResult GetNotificationById(int id)
        {
            var findNatification = _mapper.Map<ResultNotificationDTO>(_notificationService.TGetById(id));
            if (findNatification == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(findNatification);
            }
        }
        [HttpPost]
        public ActionResult CreateNotification(CreateNotificationDTO n)
        {
            var value = _mapper.Map<Notification>(n);
            _notificationService.TInsert(value);
            return Ok("Ekleme İşlemi Başarıyla Sağlandı");
        }
        [HttpPut]
        public ActionResult UpdateNotification(UpdateNotificationDTO n)
        {
			var value = _mapper.Map<Notification>(n);
			_notificationService.TUpdate(value);
			return Ok("Güncelleme İşlemi Başarıyla Sağlandı");
        }
        [HttpDelete("{id}")]
        public ActionResult DeleteNotification(int id)
        {
            var findNotification = _notificationService.TGetById(id);
            _notificationService.TDelete(findNotification);
            return Ok("Bildirim Başarıyla Silindi");
        }
    }
}
