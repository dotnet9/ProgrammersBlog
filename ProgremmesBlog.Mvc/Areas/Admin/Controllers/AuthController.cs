using System.Threading.Tasks;
using Entities.Concrete;
using Entities.Dtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace ProgrammersBlog.Mvc.Areas.Admin.Controllers;

[Area("Admin")]
public class AuthController : Controller
{
	private readonly SignInManager<User> _signInManager;
	private readonly UserManager<User> _userManager;

	public AuthController(UserManager<User> userManager, SignInManager<User> signInManager)
	{
		_userManager = userManager;
		_signInManager = signInManager;
	}

	[HttpGet]
	public IActionResult Login()
	{
		return View();
	}

	[HttpPost]
	public async Task<IActionResult> Login(UserLoginDto userLoginDto)
	{
		if (ModelState.IsValid)
		{
			var user = await _userManager.FindByEmailAsync(userLoginDto.Email);
			if (user != null)
			{
				var result = await _signInManager.PasswordSignInAsync(user, userLoginDto.Password,
					userLoginDto.RememberMe, false);
				if (result.Succeeded) return RedirectToAction("Index", "Home");

				ModelState.AddModelError("", "您的电子邮件地址或密码不正确。");
				return View();
			}

			ModelState.AddModelError("", "您的电子邮件地址或密码不正确。");
			return View();
		}

		return View();
	}

	[Authorize]
	[HttpGet]
	public ViewResult AccessDenied()
	{
		return View();
	}

	[Authorize]
	[HttpGet]
	public async Task<IActionResult> Logout()
	{
		await _signInManager.SignOutAsync();
		return RedirectToAction("Index", "Home", new { Area = "" });
	}
}