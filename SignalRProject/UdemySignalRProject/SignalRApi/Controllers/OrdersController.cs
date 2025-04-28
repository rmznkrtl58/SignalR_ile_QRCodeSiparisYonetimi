using AutoMapper;
using BusinessLogicLayer.Abstract;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace SignalRApi.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class OrdersController : ControllerBase
	{   private readonly IOrderService _orderService;
		private readonly IMapper _mapper;

		public OrdersController(IOrderService orderService, IMapper mapper)
		{
			_orderService = orderService;
			_mapper = mapper;
		}

		[HttpGet("GetTotalOrderCount")]
		public IActionResult GetTotalOrderCount()
		{
			var values = _mapper.Map<int>(_orderService.TGetTotalOrderCount());
			return Ok(values);
		}
		[HttpGet("GetActiveOrderCount")]
		public IActionResult GetActiveOrderCount()
		{
			var values = _mapper.Map<int>(_orderService.TGetActiveOrderCount());
			return Ok(values);
		}
		[HttpGet("GetLastOrderPrice")]
		public IActionResult GetLastOrderPrice()
		{
			var values = _mapper.Map<int>(_orderService.TGetLastOrderPrice());
			return Ok(values);
		}
	}
}
