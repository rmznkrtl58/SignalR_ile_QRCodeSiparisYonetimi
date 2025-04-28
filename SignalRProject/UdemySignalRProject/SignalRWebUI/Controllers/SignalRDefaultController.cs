using Microsoft.AspNetCore.Mvc;

namespace SignalRWebUI.Controllers
{
	public class SignalRDefaultController : Controller
	{   //bağlantı kontrolü için
		public IActionResult Index()
		{
			return View();
		}
        public IActionResult Index2()
        {
            return View();
        }
    }
}
