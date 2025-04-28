using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SignalRWebUI.DTOs.ReservationDTOs;
using System.Text;

namespace SignalRWebUI.Controllers
{
	public class ReservationController : Controller
	{
		private readonly IHttpClientFactory _httpClientFactory;

		public ReservationController(IHttpClientFactory httpClientFactory)
		{
			_httpClientFactory = httpClientFactory;
		}

		public async Task<IActionResult> PendingConfirmation()
		{
			var client = _httpClientFactory.CreateClient();
			var responseMessage = await client.GetAsync("https://localhost:7223/api/Reservation");
			if (responseMessage.IsSuccessStatusCode)
			{
				var jsonData=await responseMessage.Content.ReadAsStringAsync();
				var values = JsonConvert.DeserializeObject<List<ResultReservationDTO>>(jsonData);
				return View(values);
			}
			return View();
		}
		[HttpGet]
		public async Task<IActionResult> EditReservation(int id)
		{
			var client = _httpClientFactory.CreateClient();
			var responseMessage = await client.GetAsync($"https://localhost:7223/api/Reservation/{id}");
			if (responseMessage.IsSuccessStatusCode)
			{
				var jsonData=await responseMessage.Content.ReadAsStringAsync();
				var values = JsonConvert.DeserializeObject<UpdateReservationDTO>(jsonData);
				return View(values);
			}
			return View();
		}
		[HttpPost]
        public async Task<IActionResult> EditReservation(UpdateReservationDTO r)
		{
			var client= _httpClientFactory.CreateClient();
			var jsonData = JsonConvert.SerializeObject(r);
			StringContent sContent= new StringContent(jsonData,Encoding.UTF8,"application/json");
			var responseMessage = await client.PutAsync("https://localhost:7223/api/Reservation", sContent);
			if (responseMessage.IsSuccessStatusCode)
			{
				return RedirectToAction("PendingConfirmation");
			}
			return View();
		}
		[HttpGet]
		public IActionResult AddReservation()
		{
			return View();
		}
		[HttpPost]
		public async Task<IActionResult> AddReservation(CreateReservationDTO r)
		{
			var client=_httpClientFactory.CreateClient();
			var jsonData=JsonConvert.SerializeObject(r);
			StringContent sContent = new StringContent(jsonData,Encoding.UTF8,"application/json");
			var responseMessage = await client.PostAsync("https://localhost:7223/api/Reservation", sContent);
			if (responseMessage.IsSuccessStatusCode) 
			{
				return RedirectToAction("PendingConfirmation");
			}
			return View();
		}
		public async  Task<IActionResult> ConfirmReservation(int id)
		{
			var client = _httpClientFactory.CreateClient();
			await client.GetAsync($"https://localhost:7223/api/Reservation/ConfirmReservation/{id}");
			return RedirectToAction("PendingConfirmation");
		}
	
		public async Task<IActionResult> DeleteReservation(int id)
		{
			var client = _httpClientFactory.CreateClient();
			var responseMessage = await client.DeleteAsync($"https://localhost:7223/api/Reservation/{id}");
			if (responseMessage.IsSuccessStatusCode)
			{
				return RedirectToAction("PendingConfirmation");
			}
			return View();
		}
	}
}
