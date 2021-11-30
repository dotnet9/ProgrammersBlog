using Core.Entities.Abstract;
using Entities.Concrete;

namespace Entities.Dtos;

public class ArticleDto : DtoGetBase
{
	public Article Article { get; set; }
}