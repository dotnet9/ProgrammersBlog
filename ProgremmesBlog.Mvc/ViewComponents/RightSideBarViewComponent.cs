using System.Threading.Tasks;
using Business.Abstract;
using Microsoft.AspNetCore.Mvc;
using ProgrammersBlog.Mvc.Models;

namespace ProgrammersBlog.Mvc.ViewComponents;

public class RightSideBarViewComponent : ViewComponent
{
	private readonly IArticleService _articleService;
	private readonly ICategoryService _categoryService;

	public RightSideBarViewComponent(ICategoryService categoryService, IArticleService articleService)
	{
		_categoryService = categoryService;
		_articleService = articleService;
	}

	public async Task<IViewComponentResult> InvokeAsync()
	{
		var categoriesResult = await _categoryService.GetAllByNonDeletedAndActiveAsync();
		var articlesResult = await _articleService.GetAllByViewCountAsync(false, 5);
		return View(new RightSideBarViewModel
		{
			Categories = categoriesResult.Data.Categories,
			Articles = articlesResult.Data.Articles
		});
	}
}