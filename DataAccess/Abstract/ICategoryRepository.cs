﻿using System.Threading.Tasks;
using Core.DataAccess.Abstract;
using Entities.Concrete;

namespace DataAccess.Abstract;

public interface ICategoryRepository : IEntityRepository<Category>
{
	Task<Category> GetById(int categoryId);
}