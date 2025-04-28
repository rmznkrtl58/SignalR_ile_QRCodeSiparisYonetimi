using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SignalRWebUI.DTOs.MenuTableDTOs;

namespace SignalRWebUI.Areas.Showcase.Controllers
{
    public class CustomerTableController : Controller
    {
        private readonly IHttpClientFactory _httpclientFactory;

        public CustomerTableController(IHttpClientFactory httpclientFactory)
        {
            _httpclientFactory = httpclientFactory;
        }

        [Area("Showcase")]
        [AllowAnonymous]
        public async Task<IActionResult> CustomerTableList()
        {
            var client=_httpclientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7223/api/MenuTables/GetMenuTableList");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData=await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultMenuTableDTO>>(jsonData);
                return View(values);
            }
            return View();
        }
    }
}
