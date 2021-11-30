using System;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccess.Concrete.EntityFramework.Mapping;

public class ArticleMap : IEntityTypeConfiguration<Article>
{
	public void Configure(EntityTypeBuilder<Article> builder)
	{
		builder.HasKey(a => a.Id);
		builder.Property(a => a.Id).ValueGeneratedOnAdd();
		builder.Property(a => a.Title).HasMaxLength(100);
		builder.Property(a => a.Title).IsRequired();
		builder.Property(a => a.Content).IsRequired();
		builder.Property(a => a.Content).HasColumnType("NVARCHAR(MAX)");
		builder.Property(a => a.Date).IsRequired();
		builder.Property(a => a.SeoAuthor).IsRequired();
		builder.Property(a => a.SeoAuthor).HasMaxLength(50);
		builder.Property(a => a.SeoDescription).HasMaxLength(150);
		builder.Property(a => a.SeoDescription).IsRequired();
		builder.Property(a => a.SeoTags).IsRequired();
		builder.Property(a => a.SeoTags).HasMaxLength(70);
		builder.Property(a => a.ViewsCount).IsRequired();
		builder.Property(a => a.CommentCount).IsRequired();
		builder.Property(a => a.Thumbnail).IsRequired();
		builder.Property(a => a.Thumbnail).HasMaxLength(250);
		builder.Property(a => a.CreatedByName).IsRequired();
		builder.Property(a => a.CreatedByName).HasMaxLength(50);
		builder.Property(a => a.ModifiedByName).IsRequired();
		builder.Property(a => a.ModifiedByName).HasMaxLength(50);
		builder.Property(a => a.CreatedDate).IsRequired();
		builder.Property(a => a.ModifiedDate).IsRequired();
		builder.Property(a => a.IsActive).IsRequired();
		builder.Property(a => a.IsDeleted).IsRequired();
		builder.Property(a => a.Note).HasMaxLength(500);
		builder.HasOne(a => a.Category).WithMany(c => c.Articles).HasForeignKey(a => a.CategoryId);
		builder.HasOne(a => a.User).WithMany(u => u.Articles).HasForeignKey(a => a.UserId);
		builder.ToTable("Articles");

		builder.HasData(
			new Article
			{
				Id = 1,
				CategoryId = 1,
				Title = "C# 9.0 和 .NET 5 的新增功能",
				Content =
					"Lorem Ipsum 是一种用于排版和印刷行业的混合文本。 自 1500 年代以来，Lorem Ipsum 就一直被用作行业标准的伪造文本，当时一位不知名的印刷商采用了一组字体并对其进行了加扰以创建类型样本书。 它不仅存活了五百年，而且还实现了电子排版的飞跃，几乎没有什么变化。 1960 年代，随着包含 Lorem Ipsum 段落的 Letraset 表的发布，以及最近包含 Lorem Ipsum 版本的桌面出版软件（例如 Aldus PageMaker）的发布，它变得流行起来。",
				Thumbnail = "postImages/defaultThumbnail.jpg",
				SeoDescription = "C# 9.0 和 .NET 5 的新增功能",
				SeoTags = "C#, C# 9, .NET5, .NET Framework, .NET Core",
				SeoAuthor = "Alper Tunga",
				Date = DateTime.Now,
				IsActive = true,
				IsDeleted = false,
				CreatedByName = "InitialCreate",
				CreatedDate = DateTime.Now,
				ModifiedByName = "InitialCreate",
				ModifiedDate = DateTime.Now,
				Note = "C# 9.0 和 .NET 5 的新增功能",
				UserId = 1,
				ViewsCount = 100,
				CommentCount = 0
			},
			new Article
			{
				Id = 2,
				CategoryId = 2,
				Title = "C++ 11 和 19 的新增功能",
				Content =
					"众所周知，重复的页面内容会分散读者的注意力。 使用 Lorem Ipsum 的目的是通过提供更平衡的字母分布来提高可读性，而不是经常输入“此处为文本，此处为文本”。 目前，许多桌面出版包和网页编辑器使用 Lorem Ipsum 作为默认的迁移文本。 此外，当搜索引擎使用关键字“lorem ipsum”进行搜索时，会列出许多仍处于设计阶段的站点。 多年来已经开发了各种版本，有时是偶然的，有时是故意的（例如，幽默）。",
				Thumbnail = "postImages/defaultThumbnail.jpg",
				SeoDescription = "C++ 11 和 19 的新增功能",
				SeoTags = "C++ 11 和 19 的新增功能",
				SeoAuthor = "Alper Tunga",
				Date = DateTime.Now,
				IsActive = true,
				IsDeleted = false,
				CreatedByName = "InitialCreate",
				CreatedDate = DateTime.Now,
				ModifiedByName = "InitialCreate",
				ModifiedDate = DateTime.Now,
				Note = "C++ 11 和 19 的新增功能",
				UserId = 1,
				ViewsCount = 295,
				CommentCount = 0
			},
			new Article
			{
				Id = 3,
				CategoryId = 3,
				Title = "JavaScript ES2019 和 ES2020 的新变化",
				Content =
					"与流行的看法相反，Lorem Ipsum 不是由随机单词组成的。它的根源公元前它有2000年的历史，可以追溯到45年以来的古典拉丁文学。弗吉尼亚州汉普登-悉尼学院的拉丁语教授理查德·麦克林托克 (Richard McClintock) 在检查“consectetur”这个词的古典文学例子时找到了一个明确的来源，“consectetur”是 Lorem Ipsum 段落中最晦涩的词之一。西塞罗 BC 的 Lorm Ipsum。它来自45年写的“de Finibus Bonorum et Malorum”（善恶的极限）的1.10.32和1.10.33章。这本书是关于道德理论的论文，在文艺复兴时期非常流行。 Lorem Ipsum 段落的第一行“Lorem ipsum dolor sat amet”来自第 1.10.32 节中的一行。自 1500 年代以来使用的标准 Lorem Ipsum 文本已为感兴趣的人复制。西塞罗的第 1.10.32 和 1.10.33 章也以原始形式复制，英文版本取自 1914 年 H. Rackham 的翻译。",
				Thumbnail = "postImages/defaultThumbnail.jpg",
				SeoDescription = "JavaScript ES2019 ve ES2020 Yenilikleri",
				SeoTags = "JavaScript ES2019 和 ES2020 的新变化",
				SeoAuthor = "Alper Tunga",
				Date = DateTime.Now,
				IsActive = true,
				IsDeleted = false,
				CreatedByName = "InitialCreate",
				CreatedDate = DateTime.Now,
				ModifiedByName = "InitialCreate",
				ModifiedDate = DateTime.Now,
				Note = "JavaScript ES2019 和 ES2020 的新变化",
				UserId = 1,
				ViewsCount = 12,
				CommentCount = 0
			}
			,
			new Article
			{
				Id = 4,
				CategoryId = 4,
				Title = "Typescript 4.1",
				Content =
					"读者在分析页面上的图形污点时，会被页面上可读的内容分散注意力，这是一个公认的事实。因此，使用Lorem Ipsum或多或少会导致字母的正态分布，这与使用“此处内容，此处内容”不同，使其可读。许多电子出版工具和网页出版商目前使用Lorem Ipsum作为默认文本模板，而Lorem Ipsum search将在他们的童年中找到许多网站。多年来，各种版本不断演变，有时是偶然的，有时是故意的（比如情绪）。",
				Thumbnail = "postImages/defaultThumbnail.jpg",
				SeoDescription = "Typescript 4.1, Typescript, TYPESCRIPT 2021",
				SeoTags = "Typescript 4.1更新",
				SeoAuthor = "Alper Tunga",
				Date = DateTime.Now,
				IsActive = true,
				IsDeleted = false,
				CreatedByName = "InitialCreate",
				CreatedDate = DateTime.Now,
				ModifiedByName = "InitialCreate",
				ModifiedDate = DateTime.Now,
				Note = "Typescript 4.1更新",
				UserId = 1,
				ViewsCount = 666,
				CommentCount = 0
			}
			,
			new Article
			{
				Id = 5,
				CategoryId = 5,
				Title = "Java 和 Android 的未来 | 2021年",
				Content =
					"与流行的看法相反，Lorem Ipsum 不是由随机单词组成的。它的根源公元前它有2000年的历史，可以追溯到45年以来的古典拉丁文学。弗吉尼亚州汉普登-悉尼学院的拉丁语教授理查德·麦克林托克 (Richard McClintock) 在检查“consectetur”这个词的古典文学例子时找到了一个明确的来源，“consectetur”是 Lorem Ipsum 段落中最晦涩的词之一。西塞罗 BC 的 Lorm Ipsum。它来自45年写的“de Finibus Bonorum et Malorum”（善恶的极限）的1.10.32和1.10.33章。这本书是关于道德理论的论文，在文艺复兴时期非常流行。 Lorem Ipsum 段落的第一行“Lorem ipsum dolor sat amet”来自第 1.10.32 节中的一行。自 1500 年代以来使用的标准 Lorem Ipsum 文本已为感兴趣的人复制。西塞罗的第 1.10.32 和 1.10.33 章也以原始形式复制，英文版本取自 1914 年 H. Rackham 的翻译。",
				Thumbnail = "postImages/defaultThumbnail.jpg",
				SeoDescription = "Java, Android, Mobile, Kotlin, Uygulama Geliştirme",
				SeoTags = "Java, Mobil, Kotlin, Android, IOS, SWIFT",
				SeoAuthor = "Alper Tunga",
				Date = DateTime.Now,
				IsActive = true,
				IsDeleted = false,
				CreatedByName = "InitialCreate",
				CreatedDate = DateTime.Now,
				ModifiedByName = "InitialCreate",
				ModifiedDate = DateTime.Now,
				Note = "JAVA",
				UserId = 1,
				ViewsCount = 3225,
				CommentCount = 0
			}
			,
			new Article
			{
				Id = 6,
				CategoryId = 6,
				Title = "使用 Python 进行数据挖掘 | 2021年",
				Content =
					"Lorem IPSUM只是在打印前排版和布局中使用的虚假文本。自15世纪以来，Lorem IPSUM一直是印刷厂的标准假文本，当时一家匿名印刷商将文本拼接在一起，制作了一本文本字体的样本书。它不仅生存了五个世纪，而且在内容不变的情况下适应了计算机办公自动化。它在20世纪60年代通过销售包含Lorem ipsum段落的Letraset页而普及，最近通过将其包含在文本布局应用程序中，如Aldus Pagemaker。",
				Thumbnail = "postImages/defaultThumbnail.jpg",
				SeoDescription = "Python数据生成器",
				SeoTags = "Python，数据机构是如何做到的？",
				SeoAuthor = "Alper Tunga",
				Date = DateTime.Now,
				IsActive = true,
				IsDeleted = false,
				CreatedByName = "InitialCreate",
				CreatedDate = DateTime.Now,
				ModifiedByName = "InitialCreate",
				ModifiedDate = DateTime.Now,
				Note = "Python",
				UserId = 1,
				ViewsCount = 9999,
				CommentCount = 0
			}
			,
			new Article
			{
				Id = 7,
				CategoryId = 7,
				Title = "PHP Laravel 入门指南 | 应用程序接口",
				Content =
					"与普遍的观点相反，lorem ipsum不仅仅是随机文本。它起源于公元前45年的一部古典拉丁文学作品。弗吉尼亚州汉普顿悉尼学院（Hampden Sydney College，Virginia）的一位教授对洛勒姆·伊普苏姆（Lorem Ipsum）的一段话中最晦涩的拉丁语单词Consectetur感兴趣，并通过研究该词在古典文学中的所有用法，发现了洛勒姆·伊普苏姆（Lorem Ipsum）无可争辩的来源。事实上，它来自西塞罗的《Finibus Bonorum and Malorum’s 0de Finibus》第1.10.32和1.10.33节。这本书在文艺复兴时期非常流行，是一篇关于伦理理论的论文。Lorem ipsum的第一行“Lorem ipsum dolor sit amet…”来自第1.10.32节",
				Thumbnail = "postImages/defaultThumbnail.jpg",
				SeoDescription = "PHP Laravel 入门指南 | 应用程序接口",
				SeoTags = "php, laravel, api, oop",
				SeoAuthor = "Alper Tunga",
				Date = DateTime.Now,
				IsActive = true,
				IsDeleted = false,
				CreatedByName = "InitialCreate",
				CreatedDate = DateTime.Now,
				ModifiedByName = "InitialCreate",
				ModifiedDate = DateTime.Now,
				Note = "PHP",
				UserId = 1,
				ViewsCount = 4818,
				CommentCount = 0
			}
			,
			new Article
			{
				Id = 8,
				CategoryId = 8,
				Title = "使用 Kotlin 进行移动编程",
				Content =
					"洛勒姆&#183；伊普苏姆（LoremIpsum）的一些变体可以在这里或那里找到，但其中大部分都是通过添加幽默或随意的单词来改变的，这些单词一秒钟都不像标准文本。如果你想使用Lorem Ipsum的一段话，你必须确保文本中没有任何令人尴尬的东西。互联网上所有的ipsum lorem生成器都倾向于复制相同的无休止的片段，这使得lipsum.com成为唯一真正的ipsumlorem生成器。IIL使用一个由200多个拉丁单词组成的词典，结合多个句子结构，生成一个完美的Ipsum Lorem。由此获得的洛勒姆·伊普苏姆不包含重复，也不包含古怪的单词或幽默感。",
				Thumbnail = "postImages/defaultThumbnail.jpg",
				SeoDescription = "使用 Kotlin 一步一步进行移动编程",
				SeoTags = "kotlin, android, mobil, 编程",
				SeoAuthor = "Alper Tunga",
				Date = DateTime.Now,
				IsActive = true,
				IsDeleted = false,
				CreatedByName = "InitialCreate",
				CreatedDate = DateTime.Now,
				ModifiedByName = "InitialCreate",
				ModifiedDate = DateTime.Now,
				Note = "Kotlin",
				UserId = 1,
				ViewsCount = 750,
				CommentCount = 0
			}
			,
			new Article
			{
				Id = 9,
				CategoryId = 9,
				Title = "IOS Swift软件",
				Content =
					"与流行的观点相反，Lorem Ipsum不仅仅是一个随机的字符序列。它是根据公元45世纪的一部经典拉丁文学改编的，这使它成为一部20岁的作品。弗吉尼亚州汉普顿悉尼学院的拉丁语教授理查德·麦克林托克（Richard McClintock）研究了最黑暗的拉丁语单词之一“Concertetur”，该词来自《奥勒姆·伊普斯姆》（Lorem Ipsum）一段，并在引述该词的各种文本中发现，其来源是《西塞罗》的《德菲尼布斯·博诺勒姆和马洛勒姆》（de Finibus Bonorum et Malorum）第1.10.32节和第1.10.33节。这是一个关于伦理理论的条约，在文艺复兴时期非常流行。Lorem Ipsum的第一行“Lorem Ipsum dolor sit amet..”源自第1.10.32节的一段。",
				Thumbnail = "postImages/defaultThumbnail.jpg",
				SeoDescription = "从Swift到IOS移动编程的最终名称",
				SeoTags = "IOS, android, mobil, 编程",
				SeoAuthor = "Alper Tunga",
				Date = DateTime.Now,
				IsActive = true,
				IsDeleted = false,
				CreatedByName = "InitialCreate",
				CreatedDate = DateTime.Now,
				ModifiedByName = "InitialCreate",
				ModifiedDate = DateTime.Now,
				Note = "Swift",
				UserId = 1,
				ViewsCount = 14900,
				CommentCount = 0
			}
			,
			new Article
			{
				Id = 10,
				CategoryId = 10,
				Title = "让我们用Ruby on Rails对AirBnb Klon进行编码",
				Content =
					"《洛雷姆·伊普苏姆》的段落有无数的变化，但大多数都经历了时间的变化，这是由于插入了讽刺性的段落，或是随机出现了明显不太可能出现的字符序列。如果你决定使用Lorem Ipsum文章，最好确保它没有令人尴尬的内容。一般来说，互联网上的文本生成器倾向于重复预定义的段落，这使得它成为互联网上第一个真正的自动生成器。事实上，它使用了一本包含200多个拉丁词汇的字典，结合一套时间结构模式，生成可信的文本段落。由此产生的文本总是没有重复、笨拙或不合适的词等。",
				Thumbnail = "postImages/defaultThumbnail.jpg",
				SeoDescription = "Ruby、Ruby on Rails 网络编程、AirBnb 克隆",
				SeoTags = "Ruby on Rails、Ruby、Web 编程、AirBnb",
				SeoAuthor = "Alper Tunga",
				Date = DateTime.Now,
				IsActive = true,
				IsDeleted = false,
				CreatedByName = "InitialCreate",
				CreatedDate = DateTime.Now,
				ModifiedByName = "InitialCreate",
				ModifiedDate = DateTime.Now,
				Note = "Ruby",
				UserId = 1,
				ViewsCount = 26777,
				CommentCount = 0
			}
		);
	}
}