using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Org.BouncyCastle.Tsp;
using SignalRWebUI.DTOs.RapidApiDTOs;


namespace SignalRWebUI.Areas.Showcase.Controllers
{
    public class RapidApiController : Controller
    {
        [Area("Showcase")]
        [AllowAnonymous]
        public async Task<IActionResult> Index()
        {
            //Dışardan gelen dünya mutfağındaki yemekleri backendimde consume ettim
            var client = new HttpClient();
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri("https://tasty.p.rapidapi.com/recipes/list?from=0&size=20&tags=under_30_minutes"),
                Headers =
    {
        { "x-rapidapi-key", "f365ad9247mshf04a630f9851b16p13c6aejsn45af46c8e35c" },
        { "x-rapidapi-host", "tasty.p.rapidapi.com" },
    },
            };
            using (var response = await client.SendAsync(request))
            {
                response.EnsureSuccessStatusCode();
                var body = await response.Content.ReadAsStringAsync();
                var root = JsonConvert.DeserializeObject<RootTastyApi>(body);
                var values = root.Results;
                return View(values.ToList());
            }
        }
    }
}
