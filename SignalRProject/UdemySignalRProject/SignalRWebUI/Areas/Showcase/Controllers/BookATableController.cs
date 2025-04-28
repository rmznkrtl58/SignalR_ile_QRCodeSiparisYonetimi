using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Newtonsoft.Json;
using SignalRWebUI.DTOs.JsonErrorDTOs;
using SignalRWebUI.DTOs.ReservationDTOs;
using System.Text;

namespace SignalRWebUI.Areas.Showcase.Controllers
{
    [Area("Showcase")]
    [Route("Showcase/[controller]/[action]/{id?}")]
    [AllowAnonymous]
    public class BookATableController : Controller
    {
        IHttpClientFactory _httpClientFactory;

        public BookATableController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            return View();
        }
        //Reservation Process
        [HttpPost]
            public async Task<IActionResult> Index(CreateReservationDTO r)
            {
            r.PersonCount = 2;
            var client = _httpClientFactory.CreateClient();
            var jsonData=JsonConvert.SerializeObject(r);
            StringContent sContent= new StringContent(jsonData,Encoding.UTF8,"application/json");
            var responseMessage = await client.PostAsync("https://localhost:7223/api/Reservation",sContent);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            else
            {
                var errorContent=await responseMessage.Content.ReadFromJsonAsync<ApiValidationErrorResponse>();
                if (errorContent?.Errors!=null)
                {
                    foreach(var error in errorContent.Errors)
                    {
                        foreach(var errorMessage in error.Value)
                        {
                            ModelState.AddModelError(error.Key, errorMessage);
                        }
                    }
                }
                return View(r);
            }
            }
    }
}
