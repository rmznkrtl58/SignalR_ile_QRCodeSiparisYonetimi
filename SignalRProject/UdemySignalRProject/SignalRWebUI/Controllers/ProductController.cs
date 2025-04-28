using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
using SignalRWebUI.DTOs.CategoryDTOs;
using SignalRWebUI.DTOs.ProductDTOs;
using System.Text;

namespace SignalRWebUI.Controllers
{
	public class ProductController : Controller
	{
		private readonly IHttpClientFactory _httpClientFactory;

        public ProductController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IActionResult> Index()
		{
			var client = _httpClientFactory.CreateClient();
			var responseMessage = await client.GetAsync("https://localhost:7223/api/Product/GetProductWithCategory");
			if (responseMessage.IsSuccessStatusCode)
			{
				var jsonData = await responseMessage.Content.ReadAsStringAsync();
				var values = JsonConvert.DeserializeObject<List<ResultProductDTO>>(jsonData);
				return View(values);
			}
			return View();
		}
		[HttpGet]
		public async Task<IActionResult> AddProduct() 
		{
			//dropdowna categoryleri listeleme 
			var client=_httpClientFactory.CreateClient();
			var responseMessage =await client.GetAsync("https://localhost:7223/api/Category");
			if (responseMessage.IsSuccessStatusCode)
			{
				var jsonData= await responseMessage.Content.ReadAsStringAsync();
				var values = JsonConvert.DeserializeObject<List<ResultCategoryDTO>>(jsonData);
				List<SelectListItem> categoryList = (from x in values select new SelectListItem
				{
					Text = x.CategoryName,
					Value = x.CategoryId.ToString()
				}).ToList();
				ViewBag.v = categoryList;
			}
			return View();
		}
        [HttpPost]
        public async Task<IActionResult> AddProduct(CreateProductDTO p)
        {
			var client=_httpClientFactory.CreateClient();
		    var jsonData=JsonConvert.SerializeObject(p);
			StringContent sContent=new StringContent(jsonData,Encoding.UTF8,"application/json");
			var responseMessage = await client.PostAsync("https://localhost:7223/api/Product", sContent);
			if (responseMessage.IsSuccessStatusCode) 
			{
				return RedirectToAction("Index");
			}
            return View();
        }
		[HttpGet]
		public async Task<IActionResult> EditProduct(int id)
		{
			//dropdowna categoryleri listeleme 
			var client1 = _httpClientFactory.CreateClient();
			var responseMessage1 = await client1.GetAsync("https://localhost:7223/api/Category");
			if (responseMessage1.IsSuccessStatusCode)
			{
				var jsonData1 = await responseMessage1.Content.ReadAsStringAsync();
				var values1 = JsonConvert.DeserializeObject<List<ResultCategoryDTO>>(jsonData1);
				List<SelectListItem> categoryList = (from x in values1
													 select new SelectListItem
													 {
														 Text = x.CategoryName,
														 Value = x.CategoryId.ToString()
													 }).ToList();
				ViewBag.v = categoryList;
			}
			var client2= _httpClientFactory.CreateClient();
			var responseMessage2 = await client2.GetAsync($"https://localhost:7223/api/Product/{id}");
			if (responseMessage2.IsSuccessStatusCode)
			{
				var jsonData = await responseMessage2.Content.ReadAsStringAsync();
				var values = JsonConvert.DeserializeObject<UpdateProductDTO>(jsonData);
				return View(values);
			}
			return View();
		}
		[HttpPost]
		public async Task<IActionResult> EditProduct(UpdateProductDTO p)
		{
			var client=_httpClientFactory.CreateClient();
			var jsonData=JsonConvert.SerializeObject(p);
			StringContent sContent=new StringContent(jsonData,Encoding.UTF8,"application/json");
			var responseMessage = await client.PutAsync("https://localhost:7223/api/Product/", sContent);
			if (responseMessage.IsSuccessStatusCode)
			{
				return RedirectToAction("Index");
			}
			return View();
		}
    }
}
