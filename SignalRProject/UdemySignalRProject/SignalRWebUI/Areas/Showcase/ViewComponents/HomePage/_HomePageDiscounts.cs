using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using NuGet.Packaging.Signing;
using SignalRWebUI.DTOs.DiscountDTOs;

namespace SignalRWebUI.Areas.Showcase.ViewComponents.HomePage
{
    public  class _HomePageDiscounts:ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public _HomePageDiscounts(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7223/api/Discount");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData= await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultDiscountDTO>>(jsonData);
                return View(values);
            }
            return View();
        }
    }
}
