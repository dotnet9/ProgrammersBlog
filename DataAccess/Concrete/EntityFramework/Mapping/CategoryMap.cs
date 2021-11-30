using System;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccess.Concrete.EntityFramework.Mapping;

public class CategoryMap : IEntityTypeConfiguration<Category>
{
	public void Configure(EntityTypeBuilder<Category> builder)
	{
		builder.HasKey(c => c.Id);
		builder.Property(c => c.Id).ValueGeneratedOnAdd();
		builder.Property(c => c.Name).IsRequired();
		builder.Property(c => c.Name).HasMaxLength(70);
		builder.Property(c => c.Description).HasMaxLength(500);
		builder.Property(c => c.CreatedByName).IsRequired();
		builder.Property(c => c.CreatedByName).HasMaxLength(50);
		builder.Property(c => c.ModifiedByName).IsRequired();
		builder.Property(c => c.ModifiedByName).HasMaxLength(50);
		builder.Property(c => c.CreatedDate).IsRequired();
		builder.Property(c => c.ModifiedDate).IsRequired();
		builder.Property(c => c.IsActive).IsRequired();
		builder.Property(c => c.IsDeleted).IsRequired();
		builder.Property(c => c.Note).HasMaxLength(500);
		builder.ToTable("Categories");

		builder.HasData(
			new Category
			{
				Id = 1,
				Name = "C#",
				Description = "关于 C# 编程语言的最新信息",
				IsActive = true,
				IsDeleted = false,
				CreatedByName = "InitialCreate",
				CreatedDate = DateTime.Now,
				ModifiedByName = "InitialCreate",
				ModifiedDate = DateTime.Now,
				Note = "C# Blog"
			},
			new Category
			{
				Id = 2,
				Name = "C++",
				Description = "C++ 编程语言的最新信息",
				IsActive = true,
				IsDeleted = false,
				CreatedByName = "InitialCreate",
				CreatedDate = DateTime.Now,
				ModifiedByName = "InitialCreate",
				ModifiedDate = DateTime.Now,
				Note = "C++ Blog"
			},
			new Category
			{
				Id = 3,
				Name = "JavaScript",
				Description = "JavaScript 编程语言的最新信息",
				IsActive = true,
				IsDeleted = false,
				CreatedByName = "InitialCreate",
				CreatedDate = DateTime.Now,
				ModifiedByName = "InitialCreate",
				ModifiedDate = DateTime.Now,
				Note = "JavaScript Blog"
			},
			new Category
			{
				Id = 4,
				Name = "Typescript",
				Description = "关于 Typescript 编程语言的最新信息",
				IsActive = true,
				IsDeleted = false,
				CreatedByName = "InitialCreate",
				CreatedDate = DateTime.Now,
				ModifiedByName = "InitialCreate",
				ModifiedDate = DateTime.Now,
				Note = "Typescript Blog"
			}
			,
			new Category
			{
				Id = 5,
				Name = "Java",
				Description = "关于 Typescript 编程语言的最新信息",
				IsActive = true,
				IsDeleted = false,
				CreatedByName = "InitialCreate",
				CreatedDate = DateTime.Now,
				ModifiedByName = "InitialCreate",
				ModifiedDate = DateTime.Now,
				Note = "Java Blog"
			}
			,
			new Category
			{
				Id = 6,
				Name = "Python",
				Description = "Python 编程语言的最新信息",
				IsActive = true,
				IsDeleted = false,
				CreatedByName = "InitialCreate",
				CreatedDate = DateTime.Now,
				ModifiedByName = "InitialCreate",
				ModifiedDate = DateTime.Now,
				Note = "Python Blog"
			}
			,
			new Category
			{
				Id = 7,
				Name = "Php",
				Description = "PHP编程语言最新资讯",
				IsActive = true,
				IsDeleted = false,
				CreatedByName = "InitialCreate",
				CreatedDate = DateTime.Now,
				ModifiedByName = "InitialCreate",
				ModifiedDate = DateTime.Now,
				Note = "Php Blog"
			}
			,
			new Category
			{
				Id = 8,
				Name = "Kotlin",
				Description = "关于 Kotlin 编程语言的最新信息",
				IsActive = true,
				IsDeleted = false,
				CreatedByName = "InitialCreate",
				CreatedDate = DateTime.Now,
				ModifiedByName = "InitialCreate",
				ModifiedDate = DateTime.Now,
				Note = "Kotlin Blog"
			}
			,
			new Category
			{
				Id = 9,
				Name = "Swift",
				Description = "Swift 编程语言的最新信息",
				IsActive = true,
				IsDeleted = false,
				CreatedByName = "InitialCreate",
				CreatedDate = DateTime.Now,
				ModifiedByName = "InitialCreate",
				ModifiedDate = DateTime.Now,
				Note = "Swift Blog"
			}
			,
			new Category
			{
				Id = 10,
				Name = "Ruby",
				Description = "Ruby 编程语言的最新信息",
				IsActive = true,
				IsDeleted = false,
				CreatedByName = "InitialCreate",
				CreatedDate = DateTime.Now,
				ModifiedByName = "InitialCreate",
				ModifiedDate = DateTime.Now,
				Note = "Ruby Blog"
			}
		);
	}
}