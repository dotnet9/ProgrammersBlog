﻿using System.Threading.Tasks;
using Core.DataAccess.Concrete.EntityFramework;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework.Contexts;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Concrete.EntityFramework.Repositories;

public class EfCategoryRepository : EfEntityRepositoryBase<Category>, ICategoryRepository
{
	public EfCategoryRepository(DbContext context) : base(context)
	{
	}

	private ProgrammersBlogContext ProgrammersBlogContext => _context as ProgrammersBlogContext;

	public async Task<Category> GetById(int categoryId)
	{
		return await ProgrammersBlogContext.Categories.SingleOrDefaultAsync(c => c.Id == categoryId);
	}
}