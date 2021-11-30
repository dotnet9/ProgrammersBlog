using System.Threading.Tasks;
using Entities.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using ProgrammersBlog.Mvc.Areas.Admin.Models;

namespace ProgrammersBlog.Mvc.Areas.Admin.ViewComponents;

public class UserMenuViewComponent : ViewComponent
{
	private readonly UserManager<User> _userManager;

	public UserMenuViewComponent(UserManager<User> userManager)
	{
		_userManager = userManager;
	}

	public async Task<IViewComponentResult> InvokeAsync()
	{
		var user = await _userManager.GetUserAsync(HttpContext.User);
		if (user == null) return Content("未找到用户");
		return View(new UserViewModel
		{
			User = user
		});
	}
}