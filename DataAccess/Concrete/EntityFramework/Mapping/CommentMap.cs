using System;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccess.Concrete.EntityFramework.Mapping;

public class CommentMap : IEntityTypeConfiguration<Comment>
{
	public void Configure(EntityTypeBuilder<Comment> builder)
	{
		builder.HasKey(c => c.Id);
		builder.Property(c => c.Id).ValueGeneratedOnAdd();
		builder.Property(c => c.Text).IsRequired();
		builder.Property(c => c.Text).HasMaxLength(1000);
		builder.HasOne(c => c.Article).WithMany(a => a.Comments).HasForeignKey(c => c.ArticleId);
		builder.Property(c => c.CreatedByName).IsRequired();
		builder.Property(c => c.CreatedByName).HasMaxLength(50);
		builder.Property(c => c.ModifiedByName).IsRequired();
		builder.Property(c => c.ModifiedByName).HasMaxLength(50);
		builder.Property(c => c.CreatedDate).IsRequired();
		builder.Property(c => c.ModifiedDate).IsRequired();
		builder.Property(c => c.IsActive).IsRequired();
		builder.Property(c => c.IsDeleted).IsRequired();
		builder.Property(c => c.Note).HasMaxLength(500);
		builder.ToTable("Comments");

		builder.HasData(
			new Comment
			{
				Id = 1,
				ArticleId = 1,
				Text =
					"Lorem Ipsum 段落有许多变体。 然而，它们中的大多数已经通过添加幽默或添加随机词进行了修改。 如果您打算使用 Lorem Ipsum 片段，您需要确保文本之间没有隐藏令人尴尬的词。 互联网上的所有 Lorem Ipsum 生成器都会重复预定的文本块。 这使得这个生成器成为互联网上真正的 Lorem Ipsum 生成器。 该生成器使用包含 200 多个拉丁词及其句子结构的字典。 因此，所产生的 Lorem Ipsum 文本没有重复、幽默和不寻常的词。",
				IsActive = true,
				IsDeleted = false,
				CreatedByName = "InitialCreate",
				CreatedDate = DateTime.Now,
				ModifiedByName = "InitialCreate",
				ModifiedDate = DateTime.Now,
				Note = "C# 文章评论"
			},
			new Comment
			{
				Id = 2,
				ArticleId = 2,
				Text =
					"Ang Lorem Ipsum ginagamit和工业模型以Pagty排版印刷。Ang Lorem Ipsum在15世纪中午时是一个普通的模型，noong可能在一公斤的manlilimbag中，并与ginulo Ang Paggka ayos nito upang libro ng的类型进行了交换。Nalagpasan九英寸长的石灰卷，你的九英寸paglaganap电子版nanatiling parehas。20世纪60年代伊藤正午的Sumikate ito noon是pag labas ng Letraset sheets和Mayrong设计师ng Lorem Ipsum，Kamkailan lang告诉mga桌面出版软件tulad ng Aldus Pagemaker ginamit给bersyon ng Lorem Ipsum。",
				IsActive = true,
				IsDeleted = false,
				CreatedByName = "InitialCreate",
				CreatedDate = DateTime.Now,
				ModifiedByName = "InitialCreate",
				ModifiedDate = DateTime.Now,
				Note = "C++ 文章评论"
			},
			new Comment
			{
				Id = 3,
				ArticleId = 3,
				Text =
					"Ang Lorem Ipsum ginagamit和工业模型以Pagty排版印刷。Ang Lorem Ipsum在15世纪中午时是一个普通的模型，noong可能在一公斤的manlilimbag中，并与ginulo Ang Paggka ayos nito upang libro ng的类型进行了交换。Nalagpasan九英寸长的石灰卷，你的九英寸paglaganap电子版nanatiling parehas。20世纪60年代伊藤正午的Sumikate ito noon是pag labas ng Letraset sheets和Mayrong设计师ng Lorem Ipsum，Kamkailan lang告诉mga桌面出版软件tulad ng Aldus Pagemaker ginamit给bersyon ng Lorem Ipsum。",
				IsActive = true,
				IsDeleted = false,
				CreatedByName = "InitialCreate",
				CreatedDate = DateTime.Now,
				ModifiedByName = "InitialCreate",
				ModifiedDate = DateTime.Now,
				Note = "JavaScript 文章评论"
			}
			,
			new Comment
			{
				Id = 4,
				ArticleId = 4,
				Text =
					"Lorem Ipsum只是字体行业中一个简单的文本市场。之后，当一个匿名的排字员走到标准行业的第16位时，Ipsum称之为标准行业，这是一个邪恶的字母，用来创建一个演示文件夹。-好吧，但是我妻子。-[笑]在60年之前，Letraset与Lorem Ipsum建立了联系，最近，通过发布计算器程序，Aldus PageMaker版本包括了Lorem Ipsum的版本。",
				IsActive = true,
				IsDeleted = false,
				CreatedByName = "InitialCreate",
				CreatedDate = DateTime.Now,
				ModifiedByName = "InitialCreate",
				ModifiedDate = DateTime.Now,
				Note = "Typescript 文章评论"
			}
			,
			new Comment
			{
				Id = 5,
				ArticleId = 5,
				Text =
					"Lorem Ipsum只是字体行业中一个简单的文本市场。之后，当一个匿名的排字员走到标准行业的第16位时，Ipsum称之为标准行业，这是一个邪恶的字母，用来创建一个演示文件夹。-好吧，但是我妻子。-[笑]在60年之前，Letraset与Lorem Ipsum建立了联系，最近，通过发布计算器程序，Aldus PageMaker版本包括了Lorem Ipsum的版本。",
				IsActive = true,
				IsDeleted = false,
				CreatedByName = "InitialCreate",
				CreatedDate = DateTime.Now,
				ModifiedByName = "InitialCreate",
				ModifiedDate = DateTime.Now,
				Note = "Java 文章评论"
			}
			,
			new Comment
			{
				Id = 6,
				ArticleId = 6,
				Text =
					"Lorem Ipsum是一种用于印刷和斯洛伐克工业的简单测试文本。自16世纪以来，Lorem Ipsum一直是一种工业标准，当时一位不知名的印刷商拿走了一个字母印刷库，并命令他们制作一份纸质样本。这段文字不仅流传了五个世纪，而且在世界葡萄酒电子素养方面，这一点基本不变。在20世纪60年代，他因使用Lorem Ipsum的breakers发布Letraset传单而广受欢迎，最近还使用了Aldus PageMaker等表格软件，其中还包含一个可变的Lorem Ipsum。",
				IsActive = true,
				IsDeleted = false,
				CreatedByName = "InitialCreate",
				CreatedDate = DateTime.Now,
				ModifiedByName = "InitialCreate",
				ModifiedDate = DateTime.Now,
				Note = "Python 文章评论"
			}
			,
			new Comment
			{
				Id = 7,
				ArticleId = 7,
				Text =
					"Lorem Ipsum：这是测谎仪和设计作品中使用的文本的组合。自16年以来，Lorem Ipsum已成为一般文本的替代品。本世纪初。当时，一个不知名的打印机创建了一段文本来打印一本带有字母样本的书。这不仅存在了五个世纪，而且由于转向计算机文本处理，今天也没有改变。在60年代，它出版了Letraset的信件，其中有Lorem Ipsum文本的片段，在最近的历史中，还出版了Aldus PageMaker等设计程序，这些程序已在Lorem Ipsum文本样本中使用。",
				IsActive = true,
				IsDeleted = false,
				CreatedByName = "InitialCreate",
				CreatedDate = DateTime.Now,
				ModifiedByName = "InitialCreate",
				ModifiedDate = DateTime.Now,
				Note = "Php 文章评论"
			}
			,
			new Comment
			{
				Id = 8,
				ArticleId = 8,
				Text =
					"读者在查看页面布局时会被页面的可读内容分散注意力，这是一个早已确定的事实。使用Lorem Ipsum的意义在于，它的字母分布或多或少是正态的，而不是使用“此处内容，此处内容”，使其看起来像可读的英语。许多桌面发布软件包和网页编辑器现在使用Lorem Ipsum作为默认模型文本，搜索“Lorem Ipsum”将发现许多尚处于起步阶段的网站。多年来，各种版本不断演变，有时出于偶然，有时出于故意（注入幽默等）。",
				IsActive = true,
				IsDeleted = false,
				CreatedByName = "InitialCreate",
				CreatedDate = DateTime.Now,
				ModifiedByName = "InitialCreate",
				ModifiedDate = DateTime.Now,
				Note = "Kotlin 文章评论"
			}
			,
			new Comment
			{
				Id = 9,
				ArticleId = 9,
				Text =
					"Laurem Epsom的文本有很多种，但大多数都是通过在文本中插入一些不寻常的或随机的词来修改的。如果你想使用劳雷姆·埃普索姆的文本，你必须首先确认文本中没有尴尬或不恰当的词或短语。虽然所有Loriam Epsom的在线文本生成器都会根据需要多次重复Loriam Epsom的文本，但我们的生成器使用了200多个单词的字典。一个非本意词，加上一组典型的句子，组成一个接近真实文本的逻辑形式的Loriam Epsom文本。因此，产生的案文不重复、不恰当或类似的词语。这就是为什么他是第一个真正的Laurem Epsom在线文本生成器。",
				IsActive = true,
				IsDeleted = false,
				CreatedByName = "InitialCreate",
				CreatedDate = DateTime.Now,
				ModifiedByName = "InitialCreate",
				ModifiedDate = DateTime.Now,
				Note = "Swift 文章评论"
			}
			,
			new Comment
			{
				Id = 10,
				ArticleId = 10,
				Text =
					"Lorem Ipsum，也称乱数假文或者哑元文本， 是印刷及排版领域所常用的虚拟文字。由于曾经一台匿名的打印机刻意打乱了一盒印刷字体从而造出一本字体样品书，Lorem Ipsum从西元15世纪起就被作为此领域的标准文本使用。它不仅延续了五个世纪，还通过了电子排版的挑战，其雏形却依然保存至今。在1960年代，”Leatraset”公司发布了印刷着Lorem Ipsum段落的纸张，从而广泛普及了它的使用。最近，计算机桌面出版软件”Aldus PageMaker”也通过同样的方式使Lorem Ipsum落入大众的视野。",
				IsActive = true,
				IsDeleted = false,
				CreatedByName = "InitialCreate",
				CreatedDate = DateTime.Now,
				ModifiedByName = "InitialCreate",
				ModifiedDate = DateTime.Now,
				Note = "Ruby 文章评论"
			}
		);
	}
}