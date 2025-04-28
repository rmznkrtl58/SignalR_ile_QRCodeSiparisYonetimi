using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SignalRWebUI.DTOs.AboutDTOs;
using System.Text;

namespace SignalRWebUI.Controllers
{
	public class AboutController : Controller
	{
		private readonly IHttpClientFactory _httpClientFactory;

		public AboutController(IHttpClientFactory httpClientFactory)
		{
			_httpClientFactory = httpClientFactory;
		}
		[HttpGet]
		public async Task<IActionResult> Index(int id)
		{
			id = 3;//hakkımda kısmında sadece bir hakkımda 
				   //bilgisi olduğu için ve silmediğimiz için sadece
				   //güncelleme gerektiği için tek bir veri var 
			var client = _httpClientFactory.CreateClient();
			var responseMessage = await client.GetAsync($"https://localhost:7223/api/About/{id}");
			if (responseMessage.IsSuccessStatusCode)
			{
				var jsonData =await responseMessage.Content.ReadAsStringAsync();
				var values = JsonConvert.DeserializeObject<UpdateAboutDTO>(jsonData);
				return View(values);
			}
			return View();
		}
		[HttpPost]
		public async Task<IActionResult> Index(UpdateAboutDTO a)
		{
			var client=_httpClientFactory.CreateClient();
			var jsonData=JsonConvert.SerializeObject(a);
			StringContent sContent=new StringContent(jsonData,Encoding.UTF8,"application/json");
			var responseMessage = await client.PutAsync("https://localhost:7223/api/About/",sContent);
			if (responseMessage.IsSuccessStatusCode)
			{
				return RedirectToAction("Index","Category");
			}
			return View();
		}
	}
}
