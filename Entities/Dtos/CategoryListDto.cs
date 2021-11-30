using System.Collections.Generic;
using Core.Entities.Abstract;
using Entities.Concrete;

namespace Entities.Dtos;

public class CategoryListDto : DtoGetBase
{
	public IList<Category> Categories { get; set; }
}