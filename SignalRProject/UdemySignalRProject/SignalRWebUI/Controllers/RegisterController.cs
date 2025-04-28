using EntityLayer.Entities.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SignalRWebUI.DTOs.IdentityDTOs;

namespace SignalRWebUI.Controllers
{
    [AllowAnonymous]
    public class RegisterController : Controller
    {
        private readonly UserManager<AppUser> _userManager;

		public RegisterController(UserManager<AppUser> userManager)
		{
			_userManager = userManager;
		}
        [HttpGet]
		public IActionResult Index()
        {
            return View();
        }
		[HttpPost]
		public async Task<IActionResult> Index(IdentityRegisterDTO r)
		{
			AppUser user = new AppUser()
			{
				NameSurname = r.nameSurname,
				Email = r.mail,
				UserName = r.userName
			};
			var result = await _userManager.CreateAsync(user, r.password);
			if (result.Succeeded)
			{
				return RedirectToAction("Index","Login");
			}
			else
			{
				return View();
			}
		}
	}
}
