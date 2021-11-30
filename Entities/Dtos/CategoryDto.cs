using Core.Entities.Abstract;
using Entities.Concrete;

namespace Entities.Dtos;

public class CategoryDto : DtoGetBase
{
	public Category Category { get; set; }
}