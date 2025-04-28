using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SignalRWebUI.Areas.Showcase.DTOs.SliderDTOs;

namespace SignalRWebUI.Areas.Showcase.ViewComponents.HomePage
{
    public class _HomePageIntroduction:ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public _HomePageIntroduction(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7223/api/Slider");
            if (responseMessage.IsSuccessStatusCode) 
            {
                var jsonData =await responseMessage.Content.ReadAsStringAsync();
                var values= JsonConvert.DeserializeObject<List<ResultSliderDTO>>(jsonData);
                return View(values);
            }
            return View ();
        }
    }
}
