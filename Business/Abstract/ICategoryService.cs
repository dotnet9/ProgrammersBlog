﻿using System.Threading.Tasks;
using Core.Utilities.Results.Abstract;
using Entities.Dtos;

namespace Business.Abstract;

public interface ICategoryService
{
	Task<IDataResult<CategoryDto>> GetAsync(int categoryId);
	Task<IDataResult<CategoryUpdateDto>> GetCategoryUpdateDtoAsync(int categoryId);

	Task<IDataResult<CategoryListDto>> GetAllAsync();
	Task<IDataResult<CategoryListDto>> GetAllByNonDeletedAsync();
	Task<IDataResult<CategoryListDto>> GetAllByNonDeletedAndActiveAsync();
	Task<IDataResult<CategoryListDto>> GetAllByDeletedAsync();
	Task<IDataResult<CategoryDto>> AddAsync(CategoryAddDto categoryAddDto, string createdByName);

	Task<IDataResult<CategoryDto>> UpdateAsync(CategoryUpdateDto categoryUpdateDto, string modifiedByName);
	Task<IDataResult<CategoryDto>> DeleteAsync(int categoryId, string modifiedByName);
	Task<IDataResult<CategoryDto>> UndoDeleteAsync(int categoryId, string modifiedByName);
	Task<IResult> HardDeleteAsync(int categoryId);
	Task<IDataResult<int>> CountAsync();
	Task<IDataResult<int>> CountByNonDeletedAsync();
}