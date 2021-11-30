using System.Threading.Tasks;
using Entities.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using ProgrammersBlog.Mvc.Areas.Admin.Models;

namespace ProgrammersBlog.Mvc.Areas.Admin.ViewComponents;

public class AdminMenuViewComponent : ViewComponent
{
	private readonly UserManager<User> _userManager;

	public AdminMenuViewComponent(UserManager<User> userManager)
	{
		_userManager = userManager;
	}

	public async Task<IViewComponentResult> InvokeAsync()
	{
		var user = await _userManager.GetUserAsync(HttpContext.User);
		var roles = await _userManager.GetRolesAsync(user);
		if (user == null) return Content("未找到用户");
		if (roles == null) return Content("未找到角色");
		return View(new UserWithRolesViewModel
		{
			User = user,
			Roles = roles
		});
	}
}