﻿using System.Threading.Tasks;
using AutoMapper;
using Business.Abstract;
using Business.Utilities;
using Core.Utilities.Results.Abstract;
using Core.Utilities.Results.ComplexTypes;
using Core.Utilities.Results.Concrete;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.Dtos;

namespace Business.Concrete;

public class CategoryManager : ManagerBase, ICategoryService
{
	public CategoryManager(IUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork, mapper)
	{
	}

	public async Task<IDataResult<CategoryDto>> GetAsync(int categoryId)
	{
		var category = await UnitOfWork.Categories.GetAsync(c => c.Id == categoryId);
		if (category != null)
			return new DataResult<CategoryDto>(ResultStatus.Success, new CategoryDto
			{
				Category = category,
				ResultStatus = ResultStatus.Success
			});
		return new DataResult<CategoryDto>(ResultStatus.Error, Messages.Category.NotFound(false), new CategoryDto
		{
			Category = null,
			ResultStatus = ResultStatus.Error,
			Message = Messages.Category.NotFound(false)
		});
	}
	
	public async Task<IDataResult<CategoryUpdateDto>> GetCategoryUpdateDtoAsync(int categoryId)
	{
		var result = await UnitOfWork.Categories.AnyAsync(c => c.Id == categoryId);
		if (result)
		{
			var category = await UnitOfWork.Categories.GetAsync(c => c.Id == categoryId);
			var categoryUpdateDto = Mapper.Map<CategoryUpdateDto>(category);
			return new DataResult<CategoryUpdateDto>(ResultStatus.Success, categoryUpdateDto);
		}

		return new DataResult<CategoryUpdateDto>(ResultStatus.Error, Messages.Category.NotFound(false), null);
	}

	public async Task<IDataResult<CategoryListDto>> GetAllAsync()
	{
		var categories = await UnitOfWork.Categories.GetAllAsync();
		if (categories.Count > -1)
			return new DataResult<CategoryListDto>(ResultStatus.Success, new CategoryListDto
			{
				Categories = categories,
				ResultStatus = ResultStatus.Success
			});
		return new DataResult<CategoryListDto>(ResultStatus.Error, Messages.Category.NotFound(true), new CategoryListDto
		{
			Categories = null,
			ResultStatus = ResultStatus.Error,
			Message = Messages.Category.NotFound(true)
		});
	}

	public async Task<IDataResult<CategoryListDto>> GetAllByNonDeletedAsync()
	{
		var categories = await UnitOfWork.Categories.GetAllAsync(c => !c.IsDeleted);
		if (categories.Count > -1)
			return new DataResult<CategoryListDto>(ResultStatus.Success, new CategoryListDto
			{
				Categories = categories,
				ResultStatus = ResultStatus.Success
			});
		return new DataResult<CategoryListDto>(ResultStatus.Error, Messages.Category.NotFound(true), new CategoryListDto
		{
			Categories = null,
			ResultStatus = ResultStatus.Error,
			Message = Messages.Category.NotFound(true)
		});
	}

	public async Task<IDataResult<CategoryListDto>> GetAllByNonDeletedAndActiveAsync()
	{
		var categories = await UnitOfWork.Categories.GetAllAsync(c => !c.IsDeleted && c.IsActive);
		if (categories.Count > -1)
			return new DataResult<CategoryListDto>(ResultStatus.Success, new CategoryListDto
			{
				Categories = categories,
				ResultStatus = ResultStatus.Success
			});
		return new DataResult<CategoryListDto>(ResultStatus.Error, Messages.Category.NotFound(true), null);
	}

	public async Task<IDataResult<CategoryListDto>> GetAllByDeletedAsync()
	{
		var categories = await UnitOfWork.Categories.GetAllAsync(c => c.IsDeleted);
		if (categories.Count > -1)
			return new DataResult<CategoryListDto>(ResultStatus.Success, new CategoryListDto
			{
				Categories = categories,
				ResultStatus = ResultStatus.Success
			});
		return new DataResult<CategoryListDto>(ResultStatus.Error, Messages.Category.NotFound(true), null);
	}
	
	public async Task<IDataResult<CategoryDto>> AddAsync(CategoryAddDto categoryAddDto, string createdByName)
	{
		var category = Mapper.Map<Category>(categoryAddDto);
		category.CreatedByName = createdByName;
		category.ModifiedByName = createdByName;
		var addedCategory = await UnitOfWork.Categories.AddAsync(category);
		await UnitOfWork.SaveAsync();
		return new DataResult<CategoryDto>(ResultStatus.Success, Messages.Category.Add(categoryAddDto.Name),
			new CategoryDto
			{
				Category = addedCategory,
				ResultStatus = ResultStatus.Success,
				Message = Messages.Category.Add(categoryAddDto.Name)
			});
	}

	public async Task<IDataResult<CategoryDto>> UpdateAsync(CategoryUpdateDto categoryUpdateDto, string modifiedByName)
	{
		var oldCategory = await UnitOfWork.Categories.GetAsync(c => c.Id == categoryUpdateDto.Id);
		var category = Mapper.Map(categoryUpdateDto, oldCategory);
		category.ModifiedByName = modifiedByName;
		var updatedCategory = await UnitOfWork.Categories.UpdateAsync(category);
		await UnitOfWork.SaveAsync();
		return new DataResult<CategoryDto>(ResultStatus.Success, Messages.Category.Update(categoryUpdateDto.Name),
			new CategoryDto
			{
				Category = updatedCategory,
				ResultStatus = ResultStatus.Success,
				Message = Messages.Category.Update(categoryUpdateDto.Name)
			});
	}

	public async Task<IDataResult<CategoryDto>> DeleteAsync(int categoryId, string modifiedByName)
	{
		var category = await UnitOfWork.Categories.GetAsync(c => c.Id == categoryId);
		if (category != null)
		{
			category.IsDeleted = true;
			category.IsActive = false;
			category.ModifiedByName = modifiedByName;
			var deletedCategory = await UnitOfWork.Categories.UpdateAsync(category);
			await UnitOfWork.SaveAsync();
			return new DataResult<CategoryDto>(ResultStatus.Success,
				Messages.Category.Delete(deletedCategory.Name), new CategoryDto
				{
					Category = deletedCategory,
					ResultStatus = ResultStatus.Success,
					Message = Messages.Category.Delete(deletedCategory.Name)
				});
		}

		return new DataResult<CategoryDto>(ResultStatus.Error, Messages.Category.NotFound(false), new CategoryDto
		{
			Category = null,
			ResultStatus = ResultStatus.Error,
			Message = Messages.Category.NotFound(false)
		});
	}

	public async Task<IDataResult<CategoryDto>> UndoDeleteAsync(int categoryId, string modifiedByName)
	{
		var category = await UnitOfWork.Categories.GetAsync(c => c.Id == categoryId);
		if (category != null)
		{
			category.IsDeleted = false;
			category.IsActive = true;
			category.ModifiedByName = modifiedByName;
			var deletedCategory = await UnitOfWork.Categories.UpdateAsync(category);
			await UnitOfWork.SaveAsync();
			return new DataResult<CategoryDto>(ResultStatus.Success,
				Messages.Category.UndoDelete(deletedCategory.Name), new CategoryDto
				{
					Category = deletedCategory,
					ResultStatus = ResultStatus.Success,
					Message = Messages.Category.UndoDelete(deletedCategory.Name)
				});
		}

		return new DataResult<CategoryDto>(ResultStatus.Error, Messages.Category.NotFound(false), new CategoryDto
		{
			Category = null,
			ResultStatus = ResultStatus.Error,
			Message = Messages.Category.NotFound(false)
		});
	}


	public async Task<IResult> HardDeleteAsync(int categoryId)
	{
		var category = await UnitOfWork.Categories.GetAsync(c => c.Id == categoryId);
		if (category != null)
		{
			await UnitOfWork.Categories.DeleteAsync(category);
			await UnitOfWork.SaveAsync();
			return new Result(ResultStatus.Success, Messages.Category.HardDelete(category.Name));
		}

		return new Result(ResultStatus.Error, Messages.Category.NotFound(false), null);
	}

	public async Task<IDataResult<int>> CountAsync()
	{
		var categoriesCount = await UnitOfWork.Categories.CountAsync();
		if (categoriesCount > -1)
			return new DataResult<int>(ResultStatus.Success, categoriesCount);
		return new DataResult<int>(ResultStatus.Error, "遇到了一个意想不到的错误。", -1);
	}

	public async Task<IDataResult<int>> CountByNonDeletedAsync()
	{
		var categoriesCount = await UnitOfWork.Categories.CountAsync(c => c.IsActive);
		if (categoriesCount > -1)
			return new DataResult<int>(ResultStatus.Success, categoriesCount);
		return new DataResult<int>(ResultStatus.Error, "遇到了一个意想不到的错误。", -1);
	}
}