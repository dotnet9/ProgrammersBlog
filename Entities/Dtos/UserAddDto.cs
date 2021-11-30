using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http;

namespace Entities.Dtos;

public class UserAddDto
{
	[DisplayName("用户名")]
	[Required(ErrorMessage = "{0} 不应留空。")]
	[MaxLength(50, ErrorMessage = "{0} {1} 它不应大于一个字符。")]
	[MinLength(3, ErrorMessage = "{0} {1} 它不得少于一个字符。")]
	public string UserName { get; set; }

	[DisplayName("电子邮件")]
	[Required(ErrorMessage = "{0} 不应留空。")]
	[MaxLength(100, ErrorMessage = "{0} {1} 它不应大于一个字符。")]
	[MinLength(10, ErrorMessage = "{0} {1} 它不得少于一个字符。")]
	[DataType(DataType.EmailAddress)]
	public string Email { get; set; }

	[DisplayName("密码")]
	[Required(ErrorMessage = "{0} 不应留空。")]
	[MaxLength(30, ErrorMessage = "{0} {1} 它不应大于一个字符。")]
	[MinLength(5, ErrorMessage = "{0} {1} 它不得少于一个字符。")]
	[DataType(DataType.Password)]
	public string Password { get; set; }

	[DisplayName("电话号码")]
	[Required(ErrorMessage = "{0} 不应留空。")]
	[MaxLength(13, ErrorMessage = "{0} {1} 它不应大于一个字符。")] // +905555555555 // 13 characters
	[MinLength(13, ErrorMessage = "{0} {1} 它不得少于一个字符。")]
	[DataType(DataType.PhoneNumber)]
	public string PhoneNumber { get; set; }

	[DisplayName("头像文件")]
	[Required(ErrorMessage = "Lütfen, bir {0} seçiniz.")]
	[DataType(DataType.Upload)]
	public IFormFile PictureFile { get; set; }

	public string Picture { get; set; }

	[DisplayName("名")]
	[MaxLength(30, ErrorMessage = "{0} {1} 它不应大于一个字符。")]
	[MinLength(2, ErrorMessage = "{0} {1} 它不得少于一个字符。")]
	public string FirstName { get; set; }

	[DisplayName("姓")]
	[MaxLength(30, ErrorMessage = "{0} {1} 它不应大于一个字符。")]
	[MinLength(2, ErrorMessage = "{0} {1} 它不得少于一个字符。")]
	public string LastName { get; set; }

	[DisplayName("关于")]
	[MaxLength(1000, ErrorMessage = "{0} {1} 它不应大于一个字符。")]
	[MinLength(5, ErrorMessage = "{0} {1} 它不得少于一个字符。")]
	public string About { get; set; }

	[DisplayName("Twitter")]
	[MaxLength(250, ErrorMessage = "{0} {1} 它不应大于一个字符。")]
	[MinLength(20, ErrorMessage = "{0} {1} 它不得少于一个字符。")]
	public string TwitterLink { get; set; }

	[DisplayName("Facebook")]
	[MaxLength(250, ErrorMessage = "{0} {1} 它不应大于一个字符。")]
	[MinLength(20, ErrorMessage = "{0} {1} 它不得少于一个字符。")]
	public string FacebookLink { get; set; }

	[DisplayName("Instagram")]
	[MaxLength(250, ErrorMessage = "{0} {1} 它不应大于一个字符。")]
	[MinLength(20, ErrorMessage = "{0} {1} 它不得少于一个字符。")]
	public string InstagramLink { get; set; }

	[DisplayName("LinkedIn")]
	[MaxLength(250, ErrorMessage = "{0} {1} 它不应大于一个字符。")]
	[MinLength(20, ErrorMessage = "{0} {1} 它不得少于一个字符。")]
	public string LinkedInLink { get; set; }

	[DisplayName("Youtube")]
	[MaxLength(250, ErrorMessage = "{0} {1} 它不应大于一个字符。")]
	[MinLength(20, ErrorMessage = "{0} {1} 它不得少于一个字符。")]
	public string YoutubeLink { get; set; }

	[DisplayName("GitHub")]
	[MaxLength(250, ErrorMessage = "{0} {1} 它不应大于一个字符。")]
	[MinLength(20, ErrorMessage = "{0} {1} 它不得少于一个字符。")]
	public string GitHubLink { get; set; }

	[DisplayName("Website")]
	[MaxLength(250, ErrorMessage = "{0} {1} 它不应大于一个字符。")]
	[MinLength(20, ErrorMessage = "{0} {1} 它不得少于一个字符。")]
	public string WebsiteLink { get; set; }
}