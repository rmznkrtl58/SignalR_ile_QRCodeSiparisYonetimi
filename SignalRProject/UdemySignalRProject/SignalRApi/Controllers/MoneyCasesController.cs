using AutoMapper;
using BusinessLogicLayer.Abstract;
using DTOLayer.AboutDTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace SignalRApi.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class MoneyCasesController : ControllerBase
	{
		private readonly IMoneyCaseService _moneyCaseService;
		

		public MoneyCasesController(IMoneyCaseService moneyCaseService)
		{
			_moneyCaseService = moneyCaseService;
		
		}

		[HttpGet("GetMoneyCaseTotalAmount")]
		public IActionResult GetMoneyCaseTotalAmount()
		{
			var values = _moneyCaseService.TGetMoneyCaseTotalAmount();
			return Ok(values);
		}
	}
}
