﻿using System;
using Business.Abstract;
using Business.Concrete;
using DataAccess.Abstract;
using DataAccess.Concrete;
using DataAccess.Concrete.EntityFramework.Contexts;
using Entities.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Business.Extensions;

public static class ServiceCollectionExtensions
{
	public static IServiceCollection LoadMyServices(this IServiceCollection serviceCollection, string connectionString)
	{
		serviceCollection.AddDbContext<ProgrammersBlogContext>(options => options.UseSqlServer(connectionString));
		serviceCollection.AddIdentity<User, Role>(options =>
		{
			//User Password Options
			options.Password.RequireDigit = false;
			options.Password.RequiredLength = 5;
			options.Password.RequiredUniqueChars = 0;
			options.Password.RequireNonAlphanumeric = false;
			options.Password.RequireLowercase = false;
			options.Password.RequireUppercase = false;

			//User Username and Email Options
			options.User.AllowedUserNameCharacters =
				"abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789-._@+";
			options.User.RequireUniqueEmail = true;
		}).AddEntityFrameworkStores<ProgrammersBlogContext>();
		serviceCollection.Configure<SecurityStampValidatorOptions>(options =>
		{
			options.ValidationInterval = TimeSpan.FromMinutes(15);
		});
		serviceCollection.AddScoped<IUnitOfWork, UnitOfWork>();
		serviceCollection.AddScoped<ICategoryService, CategoryManager>();
		serviceCollection.AddScoped<IArticleService, ArticleManager>();
		serviceCollection.AddScoped<ICommentService, CommentManager>();
		return serviceCollection;
	}
}