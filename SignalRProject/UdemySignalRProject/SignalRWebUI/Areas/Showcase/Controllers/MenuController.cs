using SignalRWebUI.DTOs.ProductDTOs;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SignalRWebUI.DTOs.BasketDTOs;
using System.Text;
using Microsoft.AspNetCore.Authorization;

namespace SignalRWebUI.Areas.Showcase.Controllers
{
    [Area("Showcase")]
    [AllowAnonymous]
    [Route("Showcase/[controller]/[action]/{id?}")]
    public class MenuController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;
        public MenuController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }
        public async Task<IActionResult> Index(int id)
        {
            ViewBag.menuTableId = id;
            var client=_httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7223/api/Product/GetProductWithCategory");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData=await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultProductDTO>>(jsonData);
                return View(values);
            }
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> AddBasket(int id,int menuTableId)
        {
            //Sepet veritabanıma ProductId'den gelen değere göre ekleme yapıyorum
            if (menuTableId == 0)
            {
                return BadRequest("MenuTableId 0 Geliyor!");
            }
            CreateBasketByProductIdAndMenuTableId model=new CreateBasketByProductIdAndMenuTableId();
            model.ProductId= id;
            model.MenuTableId = menuTableId;
            var client=_httpClientFactory.CreateClient();
            var jsonData=JsonConvert.SerializeObject(model);
            StringContent content= new StringContent(jsonData,Encoding.UTF8,"application/json");
            var ResponseMessage = await client.PostAsync("https://localhost:7223/api/Baskets", content);
            var client2 = _httpClientFactory.CreateClient();
            await client2.GetAsync("https://localhost:7223/api/MenuTables/ChangeMenuTableStatusActive/" + menuTableId);
            if (ResponseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return Json(model);
        }
    }
}
