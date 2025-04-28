using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SignalRWebUI.DTOs.ComminicationDTOs;
using System.Text;

namespace SignalRWebUI.Areas.Showcase.Controllers
{
    [Area("Showcase")]
    [Route("Showcase/[controller]/[action]/{id?}")]
	[AllowAnonymous]
	public class MessageController : Controller
	{
		IHttpClientFactory _httpClientFactory;

        public MessageController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public IActionResult Index()
		{
			return View();
		}
		[HttpGet]
		public PartialViewResult HomePageCommunication()
		{
			return PartialView();
		}
        [HttpPost]//AJAX İÇİN backend Kodları
        public async Task<IActionResult> SendCommunication(CreateCommunicationDTO c)
        {
            //Sayfa Yenilenmeden Mesaj Gönderme işlemi(Ajax)
            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(c);
            StringContent sContent= new StringContent(jsonData,Encoding.UTF8,"application/json");
            var responseMessage = await client.PostAsync("https://localhost:7223/api/Message", sContent);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index","Default");
            }
            return Json(c);
        }
    }
}
