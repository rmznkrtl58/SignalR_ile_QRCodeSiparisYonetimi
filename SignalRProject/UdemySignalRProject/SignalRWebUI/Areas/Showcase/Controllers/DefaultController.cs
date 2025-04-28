using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
namespace SignalRWebUI.Areas.Showcase.Controllers
{
    [Area("Showcase")]
    [Route("Showcase/[controller]/[action]/{id?}")]
	[AllowAnonymous]
	public class DefaultController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

    }
}
