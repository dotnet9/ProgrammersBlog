using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Entities.Dtos;

public class UserPasswordChangeDto
{
	[DisplayName("当前密码")]
	[Required(ErrorMessage = "{0} 不应留空。")]
	[MaxLength(30, ErrorMessage = "{0} {1} 它不应大于一个字符。")]
	[MinLength(10, ErrorMessage = "{0} {1} 它不应少于一个字符。")]
	[DataType(DataType.Password)]
	public string CurrentPassword { get; set; }

	[DisplayName("新密码")]
	[Required(ErrorMessage = "{0} 不应留空。")]
	[MaxLength(30, ErrorMessage = "{0} {1} 它不应大于一个字符。")]
	[MinLength(5, ErrorMessage = "{0} {1} 它不应少于一个字符。")]
	[DataType(DataType.Password)]
	public string NewPassword { get; set; }

	[DisplayName("确认密码")]
	[Required(ErrorMessage = "{0} 不应留空。")]
	[MaxLength(30, ErrorMessage = "{0} {1} 它不应大于一个字符。")]
	[MinLength(10, ErrorMessage = "{0} {1} 它不应少于一个字符。")]
	[DataType(DataType.Password)]
	[Compare("NewPassword",
		ErrorMessage =
			"您输入的新密码和确认密码必须一致。")]
	public string RepeatPassword { get; set; }
}