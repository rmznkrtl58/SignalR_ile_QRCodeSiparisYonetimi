using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SignalRWebUI.DTOs.ContactDTOs;
using System.Text;

namespace SignalRWebUI.Controllers
{
    public class ContactController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public ContactController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }
        [HttpGet]
        public async Task<IActionResult> Index(int id)
        {
            id = 4;//tek bir iletişim verileri olduğu için tek bir Id
            //Üzerinden sadece güncelleme yapmam yetecek
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync($"https://localhost:7223/api/Contact/{id}");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<UpdateContactDTO>(jsonData);
                return View(values);
            }
            return View();
        }
		[HttpPost]
		public async Task<IActionResult> Index(UpdateContactDTO u)
		{
			var client = _httpClientFactory.CreateClient();
            var jsonData=JsonConvert.SerializeObject(u);
            StringContent sContent = new StringContent(jsonData,Encoding.UTF8,"application/json");
			var responseMessage = await client.PutAsync("https://localhost:7223/api/Contact",sContent);
			if (responseMessage.IsSuccessStatusCode)
			{
				return View();
			}
			return View();
		}
	}
}
