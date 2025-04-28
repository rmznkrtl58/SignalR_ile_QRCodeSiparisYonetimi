using EntityLayer.Entities.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SignalRWebUI.DTOs.IdentityDTOs;


namespace SignalRWebUI.Controllers
{
	public class SettingsController : Controller
	{
		private readonly UserManager<AppUser> _userManager;
		private readonly SignInManager<AppUser> _signInManager;
        public SettingsController(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        [HttpGet]
		public async Task<IActionResult> Index()
		{
			    IdentityUpdateDTO u=new IdentityUpdateDTO();
				var findUser = await _userManager.FindByNameAsync(User.Identity.Name);
				u.nameSurname = findUser.NameSurname;
			    u.userName= findUser.UserName;
				u.mail = findUser.Email;
			    return View(u);
		}
		[HttpPost]
		public async Task<IActionResult> Index(IdentityUpdateDTO u)
		{
			if (u.password==u.confirmPassword)
			{
				var findUser = await _userManager.FindByNameAsync(User.Identity.Name);
				findUser.NameSurname= u.nameSurname;
				findUser.Email = u.mail;
				findUser.UserName = u.userName;
				findUser.PasswordHash = _userManager.PasswordHasher.HashPassword(findUser, u.password);
				await _userManager.UpdateAsync(findUser);
                await _signInManager.SignOutAsync();
                return RedirectToAction("Index", "Login");

            }
			return View();
		}
	}
}
