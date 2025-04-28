using EntityLayer.Entities.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace SignalRWebUI.ViewComponents
{
	public class _AdminPageSideBarUser:ViewComponent
	{
		private readonly UserManager<AppUser> _userManager;

		public _AdminPageSideBarUser(UserManager<AppUser> userManager)
		{
			_userManager = userManager;
		}

		public async Task<IViewComponentResult> InvokeAsync()
		{
			var findUser = await _userManager.FindByNameAsync(User.Identity.Name);
		    int userId=findUser.Id;
			var userStatus = _userManager.Users.Where(x => x.Id == userId).Select(x => x.Status).FirstOrDefault();
			var userNameSurname = _userManager.Users.Where(x => x.Id == userId).Select(x => x.NameSurname).FirstOrDefault();
			var userImg = _userManager.Users.Where(x => x.Id == userId).Select(x => x.userImg).FirstOrDefault();
			ViewData["userStatus"] = userStatus;
			ViewData["userName"] = userNameSurname;
			ViewData["userImg"] = userImg;
			return View();
		}
	}
}
