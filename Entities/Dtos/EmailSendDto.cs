using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Entities.Dtos;

public class EmailSendDto
{
	[DisplayName("名称")]
	[Required(ErrorMessage = "{0} 必须的。")]
	[MaxLength(60, ErrorMessage = "{0} 最多 {1} 字符组成。")]
	[MinLength(5, ErrorMessage = "{0} 至少 {1} 字符组成。")]
	public string Name { get; set; }

	[DisplayName("邮件地址")]
	[DataType(DataType.EmailAddress)]
	[Required(ErrorMessage = "{0} 必须的。")]
	[MaxLength(100, ErrorMessage = "{0} 最多 {1} 字符组成。")]
	[MinLength(10, ErrorMessage = "{0} 至少 {1} 字符组成。")]
	public string Email { get; set; }

	[DisplayName("主题")]
	[Required(ErrorMessage = "{0} 必须的。")]
	[MaxLength(125, ErrorMessage = "{0} 最多 {1} 字符组成。")]
	[MinLength(5, ErrorMessage = "{0} 至少 {1} 字符组成。")]
	public string Subject { get; set; }

	[DisplayName("内容")]
	[Required(ErrorMessage = "{0} 必须的。")]
	[MaxLength(1500, ErrorMessage = "{0} 最多 {1} 字符组成。")]
	[MinLength(20, ErrorMessage = "{0} 至少 {1} 字符组成。")]
	public string Message { get; set; }
}