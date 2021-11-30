using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Entities.Dtos;

public class CategoryUpdateDto
{
	[Required] public int Id { get; set; }

	[DisplayName("名称")]
	[Required(ErrorMessage = "{0} 不应留空。")]
	[MaxLength(70, ErrorMessage = "{0} {1} 它不应大于一个字符。")]
	[MinLength(3, ErrorMessage = "{0} {1} 它不应少于一个字符。")]
	public string Name { get; set; }

	[DisplayName("描述")]
	[MaxLength(500, ErrorMessage = "{0} {1} 它不应大于一个字符。")]
	[MinLength(3, ErrorMessage = "{0} {1} 它不应少于一个字符。")]
	public string Description { get; set; }

	[DisplayName("备注")]
	[MaxLength(500, ErrorMessage = "{0} {1} 它不应大于一个字符。")]
	[MinLength(3, ErrorMessage = "{0} {1} 它不应少于一个字符。")]
	public string Note { get; set; }

	[DisplayName("是否活跃")]
	[Required(ErrorMessage = "{0} 不应留空。")]
	public bool IsActive { get; set; }

	[DisplayName("是否删除")]
	[Required(ErrorMessage = "{0} 不应留空。")]
	public bool IsDeleted { get; set; }
}