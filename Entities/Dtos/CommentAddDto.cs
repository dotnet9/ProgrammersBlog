using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Entities.Dtos;

public class CommentAddDto
{
	[DisplayName("内容")]
	[Required(ErrorMessage = "{0} 不应留空。")]
	[MaxLength(1000, ErrorMessage = "{0} {1} 它不应大于一个字符。")]
	[MinLength(2, ErrorMessage = "{0} {1} 不应少于一个字符。")]
	public string Text { get; set; }

	[DisplayName("创建人")]
	[Required(ErrorMessage = "{0} 不应留空。")]
	[MaxLength(50, ErrorMessage = "{0} {1} 它不应大于一个字符。")]
	[MinLength(2, ErrorMessage = "{0} {1} 不应少于一个字符。")]
	public string CreatedByName { get; set; }

	[Required(ErrorMessage = "{0} 不应留空。")]
	public int ArticleId { get; set; }
}