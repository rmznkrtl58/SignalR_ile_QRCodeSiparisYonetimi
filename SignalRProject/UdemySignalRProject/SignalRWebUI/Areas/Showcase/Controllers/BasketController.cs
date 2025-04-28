using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SignalRWebUI.DTOs.BasketDTOs;
using SignalRWebUI.DTOs.JsonErrorDTOs;


namespace SignalRWebUI.Areas.Showcase.Controllers
{
	[AllowAnonymous]
	[Area("Showcase")]
    [Route("Showcase/[controller]/[action]/{id?}")]
    public class BasketController : Controller
    {
        
		//@await Component.InvokeAsync("_AdminPageSideBarUser")


		private readonly IHttpClientFactory _httpClientFactory;
        public BasketController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }
        public async Task<IActionResult> Index(int id)
        {
            TempData["tableId"]=id;//masa numarasını tempdataya taşıdım
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7223/api/Baskets/GetBasketByMenuTableNumber/"+id);
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultBasketDTO>>(jsonData);
                return View(values);
            }
            return View();
        }
        public async Task<IActionResult> DeleteBasket(int id)
        {
            int mTableId = Convert.ToInt32(TempData["tableId"]); 
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.DeleteAsync($"https://localhost:7223/api/Baskets?id={id}");
            if (responseMessage.IsSuccessStatusCode) 
            {
                return RedirectToAction("Index", "Basket", new {id= mTableId });
                ///Showcase/Basket/Index/id Değeri
            }
            return NoContent();
        }
    }
}
