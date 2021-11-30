using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Entities.Concrete;

namespace Entities.Dtos;

public class ArticleAddDto
{
	[DisplayName("标题")]
	[Required(ErrorMessage = "{0} 字段不应为空。")]
	[MaxLength(100, ErrorMessage = "{0} 区域 {1} 它不应大于一个字符。")]
	[MinLength(5, ErrorMessage = "{0} 区域 {1} 它不应少于一个字符。")]
	public string Title { get; set; }

	[DisplayName("内容")]
	[Required(ErrorMessage = "{0} 字段不应为空。")]
	[MinLength(20, ErrorMessage = "{0} 区域 {1} 它不应少于一个字符。")]
	public string Content { get; set; }

	[DisplayName("缩略图")]
	[Required(ErrorMessage = "{0} 字段不应为空。")]
	[MaxLength(250, ErrorMessage = "{0} 区域 {1} 它不应大于一个字符。")]
	[MinLength(5, ErrorMessage = "{0} 区域 {1} 它不应少于一个字符。")]
	public string Thumbnail { get; set; }

	[DisplayName("日期")]
	[Required(ErrorMessage = "{0} 字段不应为空。")]
	[DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
	public DateTime Date { get; set; }

	[DisplayName("SEO作者")]
	[Required(ErrorMessage = "{0} 字段不应为空。")]
	[MaxLength(50, ErrorMessage = "{0} 区域 {1} 它不应大于一个字符。")]
	public string SeoAuthor { get; set; }

	[DisplayName("Se描述")]
	[Required(ErrorMessage = "{0} 字段不应为空。")]
	[MaxLength(150, ErrorMessage = "{0} 区域 {1} 它不应大于一个字符。")]
	public string SeoDescription { get; set; }

	[DisplayName("Seo标签")]
	[Required(ErrorMessage = "{0} 字段不应为空。")]
	[MaxLength(70, ErrorMessage = "{0} 区域 {1} 它不应大于一个字符。")]
	[MinLength(5, ErrorMessage = "{0} 区域 {1} 它不应少于一个字符。")]
	public string SeoTags { get; set; }

	[DisplayName("分类ID")]
	[Required(ErrorMessage = "{0} 字段不应为空。")]
	public int CategoryId { get; set; }

	public Category Category { get; set; }

	[DisplayName("是否活跃")]
	[Required(ErrorMessage = "{0} 字段不应为空。")]
	public bool IsActive { get; set; }
}