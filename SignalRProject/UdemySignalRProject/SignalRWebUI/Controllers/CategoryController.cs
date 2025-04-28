using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SignalRWebUI.DTOs.CategoryDTOs;
using System.Text;

namespace SignalRWebUI.Controllers
{
	public class CategoryController : Controller
	{
		//apilerimi consume için gerekli
		private readonly IHttpClientFactory _httpClientFactory;

		public CategoryController(IHttpClientFactory httpClientFactory)
		{
			_httpClientFactory = httpClientFactory;
		}
		//DeserializeObject->listeleme ve getirme işlemlerinde
		//SerializeObject->ekleme ve güncellemede
		public async Task<IActionResult> Index()
		{
			var client=_httpClientFactory.CreateClient();
			var responseMessage = await client.GetAsync("https://localhost:7223/api/Category");
			if (responseMessage.IsSuccessStatusCode)//200 ile 299 arası
			{
				var jsonData=await responseMessage.Content.ReadAsStringAsync();
				var values = JsonConvert.DeserializeObject<List<ResultCategoryDTO>>(jsonData);
				return View(values);
			}
			return View();
		}
		[HttpGet]
		public IActionResult AddCategory()
		{
			return View();
		}
		[HttpPost]
		public async Task<IActionResult> AddCategory(CreateCategoryDTO c)
		{
			var client=_httpClientFactory.CreateClient();
			var jsonData=JsonConvert.SerializeObject(c);
			StringContent sContent = new StringContent(jsonData,Encoding.UTF8,"application/json");
			var responseMessage =await client.PostAsync("https://localhost:7223/api/Category", sContent);
			if (responseMessage.IsSuccessStatusCode)
			{
				return RedirectToAction("Index");
			}
			return View();
		}
		public async Task<IActionResult> DeleteCategory(int id)
		{
			var client=_httpClientFactory.CreateClient();
			var responseMessage = await client.DeleteAsync($"https://localhost:7223/api/Category/{id}");
			if (responseMessage.IsSuccessStatusCode)
			{
				return RedirectToAction("Index");

			}
			return View();
		}
		[HttpGet]
		public async Task<IActionResult> EditCategory(int id)
		{
			var client = _httpClientFactory.CreateClient();
			var responseMessage = await client.GetAsync($"https://localhost:7223/api/Category/{id}");
			if (responseMessage.IsSuccessStatusCode) 
			{
				var jsonData =await responseMessage.Content.ReadAsStringAsync();
				var values = JsonConvert.DeserializeObject<UpdateCategoryDTO>(jsonData);
				return View(values);
			}
			return View();
		}
		[HttpPost]
		public async Task<IActionResult> EditCategory(UpdateCategoryDTO c)
		{
			var client=_httpClientFactory.CreateClient();
			var jsonData=JsonConvert.SerializeObject(c);
			StringContent sContent= new StringContent(jsonData,Encoding.UTF8,"application/json");
			var responseMessage = await client.PutAsync("https://localhost:7223/api/Category" ,sContent);
			if (responseMessage.IsSuccessStatusCode)
			{
				return RedirectToAction("Index");
			}
			return View();
		}
	}
}
