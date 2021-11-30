using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Entities.Dtos;

public class CommentUpdateDto
{
	[Required(ErrorMessage = "{0} 不应留空。")]
	public int Id { get; set; }

	[DisplayName("内容")]
	[Required(ErrorMessage = "{0} 不应留空。")]
	[MaxLength(1000, ErrorMessage = "{0} {1} 它不应大于一个字符。")]
	[MinLength(2, ErrorMessage = "{0} {1} 不应少于一个字符。")]
	public string Text { get; set; }

	[DisplayName("是否活跃")]
	[Required(ErrorMessage = "{0} 不应留空。")]
	public bool IsActive { get; set; }

	[Required(ErrorMessage = "{0} 不应留空。")]
	public int ArticleId { get; set; }
}