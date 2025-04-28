using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SignalRWebUI.DTOs.MenuTableDTOs;
using System.Text;

namespace SignalRWebUI.Controllers
{
	public class MenuTableController : Controller
	{
		private readonly IHttpClientFactory _httpClientFactory;

		public MenuTableController(IHttpClientFactory httpClientFactory)
		{
			_httpClientFactory = httpClientFactory;
		}

		public async Task<IActionResult> Index()
		{
			var client = _httpClientFactory.CreateClient();
			var responseMessage = await client.GetAsync("https://localhost:7223/api/MenuTables/GetMenuTableList");
			if (responseMessage.IsSuccessStatusCode)
			{
				var jsonData = await responseMessage.Content.ReadAsStringAsync();
				var values = JsonConvert.DeserializeObject<List<ResultMenuTableDTO>>(jsonData);
				return View(values);
			}
			return View();
		}
		[HttpGet]
		public IActionResult AddMenuTable()
		{
			return View();
		}
		[HttpPost]
		public async Task<IActionResult> AddMenuTable(CreateMenuTableDTO m) 
		{
			var client = _httpClientFactory.CreateClient();
			var jsonData=JsonConvert.SerializeObject(m);
			StringContent sContent=new StringContent(jsonData,Encoding.UTF8,"application/json");
			var responseMessage = await client.PostAsync("https://localhost:7223/api/MenuTables",sContent);
			if (responseMessage.IsSuccessStatusCode)
			{
				return RedirectToAction("Index", "MenuTable");
			}
			return View();
		}
		[HttpGet]
		public async  Task<IActionResult> EditMenuTable(int id)
		{
			var client= _httpClientFactory.CreateClient();
			var responseMessage = await client.GetAsync($"https://localhost:7223/api/MenuTables/GetMenuTableById/{id}");
			if (responseMessage.IsSuccessStatusCode)
			{
				var jsonData=await responseMessage.Content.ReadAsStringAsync();
				var values = JsonConvert.DeserializeObject<UpdateMenuTableDTO>(jsonData);
				return View(values);
			}
			return View();
		}
		[HttpPost]
		public async Task<IActionResult> EditMenuTable(UpdateMenuTableDTO m)
		{
			var client = _httpClientFactory.CreateClient();
			var jsonData = JsonConvert.SerializeObject(m);
			StringContent sContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
			var responseMessage = await client.PutAsync("https://localhost:7223/api/MenuTables", sContent);
			if (responseMessage.IsSuccessStatusCode)
			{
				return RedirectToAction("Index", "MenuTable");
			}
			return View();
		}
		public async Task<IActionResult> DeleteMenuTable(int id)
		{
			var client=_httpClientFactory.CreateClient();
			var responseMessage = await client.DeleteAsync($"https://localhost:7223/api/MenuTables/{id}");
			if (responseMessage.IsSuccessStatusCode) 
			{
				return RedirectToAction("Index", "MenuTable");
			}
			return View();
		}
		[HttpGet]
		public async Task<IActionResult> GetMenuTableByStatus()
		{
			//masanın boş olup olmadıklarının listesi
			return View();
		}
	}
}
