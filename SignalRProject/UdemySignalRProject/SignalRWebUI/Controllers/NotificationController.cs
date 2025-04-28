using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Razor.Hosting;
using Newtonsoft.Json;
using SignalRWebUI.DTOs.NotificationDTOs;
using System.Runtime.InteropServices;
using System.Text;

namespace SignalRWebUI.Controllers
{
    public class NotificationController : Controller
    {
        IHttpClientFactory _httpClientFactory;

		public NotificationController(IHttpClientFactory httpClientFactory)
		{
			_httpClientFactory = httpClientFactory;
		}
        [HttpGet]
		public async Task<IActionResult> Index()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7223/api/Notification");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData=await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultNotificationDTO>>(jsonData);
                return View(values);
            }
            return View();
        }
		[HttpGet]
		public async Task<IActionResult> EditNotification(int id)
		{
			var client = _httpClientFactory.CreateClient();
			var responseMessage = await client.GetAsync($"https://localhost:7223/api/Notification/GetNotificationById/{id}");
			if (responseMessage.IsSuccessStatusCode)
			{
				var jsonData = await responseMessage.Content.ReadAsStringAsync();
				var value = JsonConvert.DeserializeObject<ResultNotificationDTO>(jsonData);
				return View(value);
			}
			return View();
		}
		[HttpPost]
		public async Task<IActionResult> EditNotification(UpdateNotificationDTO n)
		{
			var client=_httpClientFactory.CreateClient();
			var jsonData=JsonConvert.SerializeObject(n);
			StringContent sContent=new StringContent(jsonData,Encoding.UTF8,"application/json");
			var responseMessage = await client.PutAsync("https://localhost:7223/api/Notification", sContent);
			if (responseMessage.IsSuccessStatusCode)
			{
				return RedirectToAction("Index", "Notification");
			}
			else
			{
				return View();
			}
		}
		[HttpGet]
		public async Task<IActionResult> AddNotification()
		{
			return View();
		}
		[HttpPost]
		public async Task<IActionResult> AddNotification(CreateNotificationDTO n)
		{
			var client = _httpClientFactory.CreateClient();
			var jsonData = JsonConvert.SerializeObject(n);
			StringContent sContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
			var responseMessage = await client.PostAsync("https://localhost:7223/api/Notification", sContent);
			if (responseMessage.IsSuccessStatusCode)
			{
				return RedirectToAction("Index", "Notification");
			}
			else
			{
				return View();
			}
		}
		public async Task<IActionResult> DeleteNotification(int id)
		{
			var client = _httpClientFactory.CreateClient();
			var responseMessage = await client.DeleteAsync($"https://localhost:7223/api/Notification/{id}");
			if (responseMessage.IsSuccessStatusCode)
			{
				return RedirectToAction("Index", "Notification");
			}
            return View();
		}
	}
}
