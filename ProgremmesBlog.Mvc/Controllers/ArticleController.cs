﻿using System;
using System.Threading.Tasks;
using Business.Abstract;
using Core.Utilities.Results.ComplexTypes;
using Entities.ComplexTypes;
using Microsoft.AspNetCore.Mvc;
using ProgrammersBlog.Mvc.Models;

namespace ProgrammersBlog.Mvc.Controllers;

public class ArticleController : Controller
{
	private readonly IArticleService _articleService;

	public ArticleController(IArticleService articleService)
	{
		_articleService = articleService;
	}

	[HttpGet]
	public async Task<IActionResult> Search(string keyword, int currentPage = 1, int pageSize = 5,
		bool isAscending = false)
	{
		var searchResult = await _articleService.SearchAsync(keyword, currentPage, pageSize, isAscending);
		if (searchResult.ResultStatus == ResultStatus.Success)
			return View(new ArticleSearchViewModel
			{
				ArticleListDto = searchResult.Data,
				Keyword = keyword
			});
		return NotFound();
	}

	[HttpGet]
	public async Task<IActionResult> Detail(int articleId)
	{
		var articleResult = await _articleService.GetAsync(articleId);
		if (articleResult.ResultStatus == ResultStatus.Success)
		{
			var userArticles = await _articleService.GetAllByUserIdOnFilter(articleResult.Data.Article.UserId,
				FilterBy.Category, OrderBy.Date, false, 10, articleResult.Data.Article.CategoryId, DateTime.Now,
				DateTime.Now, 0, 99999, 0, 99999);
			await _articleService.IncreaseViewCountAsync(articleId);
			return View(new ArticleDetailViewModel
			{
				ArticleDto = articleResult.Data,
				ArticleDetailRightSideBarViewModel = new ArticleDetailRightSideBarViewModel
				{
					ArticleListDto = userArticles.Data,
					Header = "用户最常阅读的同类别文章",
					User = articleResult.Data.Article.User
				}
			});
		}

		return NotFound();
	}
}