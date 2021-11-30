using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Entities.Dtos;

public class UserLoginDto
{
	[DisplayName("电子邮件")]
	[Required(ErrorMessage = "{0} 不应留空。")]
	[MaxLength(100, ErrorMessage = "{0} {1} 它不应大于一个字符。")]
	[MinLength(10, ErrorMessage = "{0} {1} 它不应少于一个字符。")]
	[DataType(DataType.EmailAddress)]
	public string Email { get; set; }

	[DisplayName("密码")]
	[Required(ErrorMessage = "{0} 不应留空。")]
	[MaxLength(30, ErrorMessage = "{0} {1} 它不应大于一个字符。")]
	[MinLength(5, ErrorMessage = "{0} {1} 它不应少于一个字符。")]
	[DataType(DataType.Password)]
	public string Password { get; set; }

	[DisplayName("记住我")] public bool RememberMe { get; set; }
}