using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.Migrations
{
    public partial class InitCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(70)", maxLength: 70, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    CreatedByName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    ModifiedByName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Note = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Picture = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    About = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true),
                    FirstName = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    YoutubeLink = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    TwitterLink = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    InstagramLink = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    FacebookLink = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    LinkedInLink = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    GitHubLink = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    WebsiteLink = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    UserName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<int>(type: "int", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RoleClaims_Roles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Roles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Articles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Content = table.Column<string>(type: "NVARCHAR(MAX)", nullable: false),
                    Thumbnail = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ViewsCount = table.Column<int>(type: "int", nullable: false),
                    CommentCount = table.Column<int>(type: "int", nullable: false),
                    SeoAuthor = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    SeoDescription = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    SeoTags = table.Column<string>(type: "nvarchar(70)", maxLength: 70, nullable: false),
                    CategoryId = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    CreatedByName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    ModifiedByName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Note = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Articles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Articles_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Articles_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserClaims_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_UserLogins_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserRoles",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false),
                    RoleId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_UserRoles_Roles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Roles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserRoles_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserTokens",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_UserTokens_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Comments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Text = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: false),
                    ArticleId = table.Column<int>(type: "int", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    CreatedByName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    ModifiedByName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Note = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Comments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Comments_Articles_ArticleId",
                        column: x => x.ArticleId,
                        principalTable: "Articles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "CreatedByName", "CreatedDate", "Description", "IsActive", "IsDeleted", "ModifiedByName", "ModifiedDate", "Name", "Note" },
                values: new object[,]
                {
                    { 1, "InitialCreate", new DateTime(2021, 11, 30, 16, 5, 16, 680, DateTimeKind.Local).AddTicks(9486), "关于 C# 编程语言的最新信息", true, false, "InitialCreate", new DateTime(2021, 11, 30, 16, 5, 16, 680, DateTimeKind.Local).AddTicks(9487), "C#", "C# Blog" },
                    { 2, "InitialCreate", new DateTime(2021, 11, 30, 16, 5, 16, 680, DateTimeKind.Local).AddTicks(9489), "C++ 编程语言的最新信息", true, false, "InitialCreate", new DateTime(2021, 11, 30, 16, 5, 16, 680, DateTimeKind.Local).AddTicks(9490), "C++", "C++ Blog" },
                    { 3, "InitialCreate", new DateTime(2021, 11, 30, 16, 5, 16, 680, DateTimeKind.Local).AddTicks(9492), "JavaScript 编程语言的最新信息", true, false, "InitialCreate", new DateTime(2021, 11, 30, 16, 5, 16, 680, DateTimeKind.Local).AddTicks(9492), "JavaScript", "JavaScript Blog" },
                    { 4, "InitialCreate", new DateTime(2021, 11, 30, 16, 5, 16, 680, DateTimeKind.Local).AddTicks(9494), "关于 Typescript 编程语言的最新信息", true, false, "InitialCreate", new DateTime(2021, 11, 30, 16, 5, 16, 680, DateTimeKind.Local).AddTicks(9495), "Typescript", "Typescript Blog" },
                    { 5, "InitialCreate", new DateTime(2021, 11, 30, 16, 5, 16, 680, DateTimeKind.Local).AddTicks(9497), "关于 Typescript 编程语言的最新信息", true, false, "InitialCreate", new DateTime(2021, 11, 30, 16, 5, 16, 680, DateTimeKind.Local).AddTicks(9497), "Java", "Java Blog" },
                    { 6, "InitialCreate", new DateTime(2021, 11, 30, 16, 5, 16, 680, DateTimeKind.Local).AddTicks(9499), "Python 编程语言的最新信息", true, false, "InitialCreate", new DateTime(2021, 11, 30, 16, 5, 16, 680, DateTimeKind.Local).AddTicks(9500), "Python", "Python Blog" },
                    { 7, "InitialCreate", new DateTime(2021, 11, 30, 16, 5, 16, 680, DateTimeKind.Local).AddTicks(9502), "PHP编程语言最新资讯", true, false, "InitialCreate", new DateTime(2021, 11, 30, 16, 5, 16, 680, DateTimeKind.Local).AddTicks(9502), "Php", "Php Blog" },
                    { 8, "InitialCreate", new DateTime(2021, 11, 30, 16, 5, 16, 680, DateTimeKind.Local).AddTicks(9509), "关于 Kotlin 编程语言的最新信息", true, false, "InitialCreate", new DateTime(2021, 11, 30, 16, 5, 16, 680, DateTimeKind.Local).AddTicks(9510), "Kotlin", "Kotlin Blog" },
                    { 9, "InitialCreate", new DateTime(2021, 11, 30, 16, 5, 16, 680, DateTimeKind.Local).AddTicks(9512), "Swift 编程语言的最新信息", true, false, "InitialCreate", new DateTime(2021, 11, 30, 16, 5, 16, 680, DateTimeKind.Local).AddTicks(9512), "Swift", "Swift Blog" },
                    { 10, "InitialCreate", new DateTime(2021, 11, 30, 16, 5, 16, 680, DateTimeKind.Local).AddTicks(9514), "Ruby 编程语言的最新信息", true, false, "InitialCreate", new DateTime(2021, 11, 30, 16, 5, 16, 680, DateTimeKind.Local).AddTicks(9515), "Ruby", "Ruby Blog" }
                });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { 1, "2b160202-ba70-4915-9649-06643417b05b", "Category.Create", "CATEGORY.CREATE" },
                    { 2, "c2bdc8ac-4164-4067-9be4-45dd94a13c81", "Category.Read", "CATEGORY.READ" },
                    { 3, "94b7c818-5b91-45aa-ba57-95b72ae69960", "Category.Update", "CATEGORY.UPDATE" },
                    { 4, "f23205ba-2724-4612-a6d3-8c1af41b1d13", "Category.Delete", "CATEGORY.DELETE" },
                    { 5, "6f9571ec-a1b0-49f3-a4fc-4b229c312074", "Article.Create", "ARTICLE.CREATE" },
                    { 6, "a47ca7c3-9b26-40f3-af52-dd6e5840f353", "Article.Read", "ARTICLE.READ" },
                    { 7, "6e977d9a-1bd2-4959-b2c0-a90aa11fff86", "Article.Update", "ARTICLE.UPDATE" },
                    { 8, "118ad42f-8433-4604-b8f5-01a1bc306a52", "Article.Delete", "ARTICLE.DELETE" },
                    { 9, "4f20c540-27b3-45d4-a359-801f7f6560df", "User.Create", "USER.CREATE" },
                    { 10, "c8dbb529-bee8-4cb2-8e74-1d42f70b898e", "User.Read", "USER.READ" },
                    { 11, "b5e336d3-9df6-4f10-bcc1-6ea7535b61b0", "User.Update", "USER.UPDATE" },
                    { 12, "b7f8690e-98ff-43a6-9ed1-ce17b7b1df02", "User.Delete", "USER.DELETE" },
                    { 13, "7007b8b8-fa9d-4b43-aed0-a7d8b7a33d09", "Role.Create", "ROLE.CREATE" },
                    { 14, "a0f6b010-f914-43a3-8665-baaef8edd0f1", "Role.Read", "ROLE.READ" },
                    { 15, "0e5f5827-aecd-4c28-8d1c-a625a2097c19", "Role.Update", "ROLE.UPDATE" },
                    { 16, "791fcfa6-82a9-478d-aaab-1eb78202d1eb", "Role.Delete", "ROLE.DELETE" },
                    { 17, "fe4a6acd-c2f5-4b9a-8253-e2f0de45cb15", "Comment.Create", "COMMENT.CREATE" },
                    { 18, "a3f3e6fe-61b5-4149-ac56-b87df5747342", "Comment.Read", "COMMENT.READ" },
                    { 19, "4ce2d30d-2425-4186-94e0-560639aa2efb", "Comment.Update", "COMMENT.UPDATE" },
                    { 20, "364f54c9-ab50-4bf2-813d-f64fd61e7a95", "Comment.Delete", "COMMENT.DELETE" },
                    { 21, "1a896359-2ad4-45fe-87dc-6b2e5c982702", "AdminArea.Home.Read", "ADMINAREA.HOME.READ" },
                    { 22, "d740194c-2470-4011-8965-6394c3c963af", "SuperAdmin", "SUPERADMIN" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "About", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FacebookLink", "FirstName", "GitHubLink", "InstagramLink", "LastName", "LinkedInLink", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "Picture", "SecurityStamp", "TwitterLink", "TwoFactorEnabled", "UserName", "WebsiteLink", "YoutubeLink" },
                values: new object[,]
                {
                    { 1, "Admin User of ProgrammersBlog", 0, "1e08885e-acde-41fb-bc21-6c5c635fb386", "admin@gmail.com", true, "https://facebook.com/adminuser", "Admin", "https://github.com/adminuser", "https://instagram.com/adminuser", "User", "https://linkedin.com/adminuser", false, null, "ADMIN@GMAIL.COM", "ADMIN", "AQAAAAEAACcQAAAAEA6uK6TkHhUgdHulSnobuoJRZMvqfcE8WpxINytlsOTA7B6Jazy3D4PlP7+n9pWhSg==", "+905555555555", true, "/userImages/defaultUser.png", "e994c7bd-20d6-4b85-83f5-9817b89ceb94", "https://twitter.com/adminuser", false, "admin", "https://programmersblog.com/", "https://youtube.com/adminuser" },
                    { 2, "Editor User of ProgrammersBlog", 0, "f650d5b4-bc9a-4ed6-8634-8a6e8428a802", "editor@gmail.com", true, "https://facebook.com/editoruser", "Admin", "https://github.com/editoruser", "https://instagram.com/editoruser", "User", "https://linkedin.com/editoruser", false, null, "EDITOR@GMAIL.COM", "EDITOR", "AQAAAAEAACcQAAAAEMVIZz5HD+LIVtWdV2OKBJdhK32D2HHYf15hURiy++lN0hYCTp64kdWSOOmZxXJamQ==", "+905555555555", true, "/userImages/defaultUser.png", "31de09b1-1902-417c-8b2a-a0eb9ab03139", "https://twitter.com/editoruser", false, "editor", "https://programmersblog.com/", "https://youtube.com/editoruser" }
                });

            migrationBuilder.InsertData(
                table: "Articles",
                columns: new[] { "Id", "CategoryId", "CommentCount", "Content", "CreatedByName", "CreatedDate", "Date", "IsActive", "IsDeleted", "ModifiedByName", "ModifiedDate", "Note", "SeoAuthor", "SeoDescription", "SeoTags", "Thumbnail", "Title", "UserId", "ViewsCount" },
                values: new object[,]
                {
                    { 1, 1, 0, "Lorem Ipsum 是一种用于排版和印刷行业的混合文本。 自 1500 年代以来，Lorem Ipsum 就一直被用作行业标准的伪造文本，当时一位不知名的印刷商采用了一组字体并对其进行了加扰以创建类型样本书。 它不仅存活了五百年，而且还实现了电子排版的飞跃，几乎没有什么变化。 1960 年代，随着包含 Lorem Ipsum 段落的 Letraset 表的发布，以及最近包含 Lorem Ipsum 版本的桌面出版软件（例如 Aldus PageMaker）的发布，它变得流行起来。", "InitialCreate", new DateTime(2021, 11, 30, 16, 5, 16, 680, DateTimeKind.Local).AddTicks(8256), new DateTime(2021, 11, 30, 16, 5, 16, 680, DateTimeKind.Local).AddTicks(8255), true, false, "InitialCreate", new DateTime(2021, 11, 30, 16, 5, 16, 680, DateTimeKind.Local).AddTicks(8257), "C# 9.0 和 .NET 5 的新增功能", "Alper Tunga", "C# 9.0 和 .NET 5 的新增功能", "C#, C# 9, .NET5, .NET Framework, .NET Core", "postImages/defaultThumbnail.jpg", "C# 9.0 和 .NET 5 的新增功能", 1, 100 },
                    { 2, 2, 0, "众所周知，重复的页面内容会分散读者的注意力。 使用 Lorem Ipsum 的目的是通过提供更平衡的字母分布来提高可读性，而不是经常输入“此处为文本，此处为文本”。 目前，许多桌面出版包和网页编辑器使用 Lorem Ipsum 作为默认的迁移文本。 此外，当搜索引擎使用关键字“lorem ipsum”进行搜索时，会列出许多仍处于设计阶段的站点。 多年来已经开发了各种版本，有时是偶然的，有时是故意的（例如，幽默）。", "InitialCreate", new DateTime(2021, 11, 30, 16, 5, 16, 680, DateTimeKind.Local).AddTicks(8261), new DateTime(2021, 11, 30, 16, 5, 16, 680, DateTimeKind.Local).AddTicks(8260), true, false, "InitialCreate", new DateTime(2021, 11, 30, 16, 5, 16, 680, DateTimeKind.Local).AddTicks(8261), "C++ 11 和 19 的新增功能", "Alper Tunga", "C++ 11 和 19 的新增功能", "C++ 11 和 19 的新增功能", "postImages/defaultThumbnail.jpg", "C++ 11 和 19 的新增功能", 1, 295 },
                    { 3, 3, 0, "与流行的看法相反，Lorem Ipsum 不是由随机单词组成的。它的根源公元前它有2000年的历史，可以追溯到45年以来的古典拉丁文学。弗吉尼亚州汉普登-悉尼学院的拉丁语教授理查德·麦克林托克 (Richard McClintock) 在检查“consectetur”这个词的古典文学例子时找到了一个明确的来源，“consectetur”是 Lorem Ipsum 段落中最晦涩的词之一。西塞罗 BC 的 Lorm Ipsum。它来自45年写的“de Finibus Bonorum et Malorum”（善恶的极限）的1.10.32和1.10.33章。这本书是关于道德理论的论文，在文艺复兴时期非常流行。 Lorem Ipsum 段落的第一行“Lorem ipsum dolor sat amet”来自第 1.10.32 节中的一行。自 1500 年代以来使用的标准 Lorem Ipsum 文本已为感兴趣的人复制。西塞罗的第 1.10.32 和 1.10.33 章也以原始形式复制，英文版本取自 1914 年 H. Rackham 的翻译。", "InitialCreate", new DateTime(2021, 11, 30, 16, 5, 16, 680, DateTimeKind.Local).AddTicks(8264), new DateTime(2021, 11, 30, 16, 5, 16, 680, DateTimeKind.Local).AddTicks(8263), true, false, "InitialCreate", new DateTime(2021, 11, 30, 16, 5, 16, 680, DateTimeKind.Local).AddTicks(8264), "JavaScript ES2019 和 ES2020 的新变化", "Alper Tunga", "JavaScript ES2019 ve ES2020 Yenilikleri", "JavaScript ES2019 和 ES2020 的新变化", "postImages/defaultThumbnail.jpg", "JavaScript ES2019 和 ES2020 的新变化", 1, 12 },
                    { 4, 4, 0, "读者在分析页面上的图形污点时，会被页面上可读的内容分散注意力，这是一个公认的事实。因此，使用Lorem Ipsum或多或少会导致字母的正态分布，这与使用“此处内容，此处内容”不同，使其可读。许多电子出版工具和网页出版商目前使用Lorem Ipsum作为默认文本模板，而Lorem Ipsum search将在他们的童年中找到许多网站。多年来，各种版本不断演变，有时是偶然的，有时是故意的（比如情绪）。", "InitialCreate", new DateTime(2021, 11, 30, 16, 5, 16, 680, DateTimeKind.Local).AddTicks(8267), new DateTime(2021, 11, 30, 16, 5, 16, 680, DateTimeKind.Local).AddTicks(8267), true, false, "InitialCreate", new DateTime(2021, 11, 30, 16, 5, 16, 680, DateTimeKind.Local).AddTicks(8268), "Typescript 4.1更新", "Alper Tunga", "Typescript 4.1, Typescript, TYPESCRIPT 2021", "Typescript 4.1更新", "postImages/defaultThumbnail.jpg", "Typescript 4.1", 1, 666 },
                    { 5, 5, 0, "与流行的看法相反，Lorem Ipsum 不是由随机单词组成的。它的根源公元前它有2000年的历史，可以追溯到45年以来的古典拉丁文学。弗吉尼亚州汉普登-悉尼学院的拉丁语教授理查德·麦克林托克 (Richard McClintock) 在检查“consectetur”这个词的古典文学例子时找到了一个明确的来源，“consectetur”是 Lorem Ipsum 段落中最晦涩的词之一。西塞罗 BC 的 Lorm Ipsum。它来自45年写的“de Finibus Bonorum et Malorum”（善恶的极限）的1.10.32和1.10.33章。这本书是关于道德理论的论文，在文艺复兴时期非常流行。 Lorem Ipsum 段落的第一行“Lorem ipsum dolor sat amet”来自第 1.10.32 节中的一行。自 1500 年代以来使用的标准 Lorem Ipsum 文本已为感兴趣的人复制。西塞罗的第 1.10.32 和 1.10.33 章也以原始形式复制，英文版本取自 1914 年 H. Rackham 的翻译。", "InitialCreate", new DateTime(2021, 11, 30, 16, 5, 16, 680, DateTimeKind.Local).AddTicks(8270), new DateTime(2021, 11, 30, 16, 5, 16, 680, DateTimeKind.Local).AddTicks(8270), true, false, "InitialCreate", new DateTime(2021, 11, 30, 16, 5, 16, 680, DateTimeKind.Local).AddTicks(8271), "JAVA", "Alper Tunga", "Java, Android, Mobile, Kotlin, Uygulama Geliştirme", "Java, Mobil, Kotlin, Android, IOS, SWIFT", "postImages/defaultThumbnail.jpg", "Java 和 Android 的未来 | 2021年", 1, 3225 },
                    { 6, 6, 0, "Lorem IPSUM只是在打印前排版和布局中使用的虚假文本。自15世纪以来，Lorem IPSUM一直是印刷厂的标准假文本，当时一家匿名印刷商将文本拼接在一起，制作了一本文本字体的样本书。它不仅生存了五个世纪，而且在内容不变的情况下适应了计算机办公自动化。它在20世纪60年代通过销售包含Lorem ipsum段落的Letraset页而普及，最近通过将其包含在文本布局应用程序中，如Aldus Pagemaker。", "InitialCreate", new DateTime(2021, 11, 30, 16, 5, 16, 680, DateTimeKind.Local).AddTicks(8274), new DateTime(2021, 11, 30, 16, 5, 16, 680, DateTimeKind.Local).AddTicks(8273), true, false, "InitialCreate", new DateTime(2021, 11, 30, 16, 5, 16, 680, DateTimeKind.Local).AddTicks(8275), "Python", "Alper Tunga", "Python数据生成器", "Python，数据机构是如何做到的？", "postImages/defaultThumbnail.jpg", "使用 Python 进行数据挖掘 | 2021年", 1, 9999 },
                    { 7, 7, 0, "与普遍的观点相反，lorem ipsum不仅仅是随机文本。它起源于公元前45年的一部古典拉丁文学作品。弗吉尼亚州汉普顿悉尼学院（Hampden Sydney College，Virginia）的一位教授对洛勒姆·伊普苏姆（Lorem Ipsum）的一段话中最晦涩的拉丁语单词Consectetur感兴趣，并通过研究该词在古典文学中的所有用法，发现了洛勒姆·伊普苏姆（Lorem Ipsum）无可争辩的来源。事实上，它来自西塞罗的《Finibus Bonorum and Malorum’s 0de Finibus》第1.10.32和1.10.33节。这本书在文艺复兴时期非常流行，是一篇关于伦理理论的论文。Lorem ipsum的第一行“Lorem ipsum dolor sit amet…”来自第1.10.32节", "InitialCreate", new DateTime(2021, 11, 30, 16, 5, 16, 680, DateTimeKind.Local).AddTicks(8277), new DateTime(2021, 11, 30, 16, 5, 16, 680, DateTimeKind.Local).AddTicks(8277), true, false, "InitialCreate", new DateTime(2021, 11, 30, 16, 5, 16, 680, DateTimeKind.Local).AddTicks(8278), "PHP", "Alper Tunga", "PHP Laravel 入门指南 | 应用程序接口", "php, laravel, api, oop", "postImages/defaultThumbnail.jpg", "PHP Laravel 入门指南 | 应用程序接口", 1, 4818 },
                    { 8, 8, 0, "洛勒姆&#183；伊普苏姆（LoremIpsum）的一些变体可以在这里或那里找到，但其中大部分都是通过添加幽默或随意的单词来改变的，这些单词一秒钟都不像标准文本。如果你想使用Lorem Ipsum的一段话，你必须确保文本中没有任何令人尴尬的东西。互联网上所有的ipsum lorem生成器都倾向于复制相同的无休止的片段，这使得lipsum.com成为唯一真正的ipsumlorem生成器。IIL使用一个由200多个拉丁单词组成的词典，结合多个句子结构，生成一个完美的Ipsum Lorem。由此获得的洛勒姆·伊普苏姆不包含重复，也不包含古怪的单词或幽默感。", "InitialCreate", new DateTime(2021, 11, 30, 16, 5, 16, 680, DateTimeKind.Local).AddTicks(8281), new DateTime(2021, 11, 30, 16, 5, 16, 680, DateTimeKind.Local).AddTicks(8280), true, false, "InitialCreate", new DateTime(2021, 11, 30, 16, 5, 16, 680, DateTimeKind.Local).AddTicks(8281), "Kotlin", "Alper Tunga", "使用 Kotlin 一步一步进行移动编程", "kotlin, android, mobil, 编程", "postImages/defaultThumbnail.jpg", "使用 Kotlin 进行移动编程", 1, 750 },
                    { 9, 9, 0, "与流行的观点相反，Lorem Ipsum不仅仅是一个随机的字符序列。它是根据公元45世纪的一部经典拉丁文学改编的，这使它成为一部20岁的作品。弗吉尼亚州汉普顿悉尼学院的拉丁语教授理查德·麦克林托克（Richard McClintock）研究了最黑暗的拉丁语单词之一“Concertetur”，该词来自《奥勒姆·伊普斯姆》（Lorem Ipsum）一段，并在引述该词的各种文本中发现，其来源是《西塞罗》的《德菲尼布斯·博诺勒姆和马洛勒姆》（de Finibus Bonorum et Malorum）第1.10.32节和第1.10.33节。这是一个关于伦理理论的条约，在文艺复兴时期非常流行。Lorem Ipsum的第一行“Lorem Ipsum dolor sit amet..”源自第1.10.32节的一段。", "InitialCreate", new DateTime(2021, 11, 30, 16, 5, 16, 680, DateTimeKind.Local).AddTicks(8284), new DateTime(2021, 11, 30, 16, 5, 16, 680, DateTimeKind.Local).AddTicks(8283), true, false, "InitialCreate", new DateTime(2021, 11, 30, 16, 5, 16, 680, DateTimeKind.Local).AddTicks(8285), "Swift", "Alper Tunga", "从Swift到IOS移动编程的最终名称", "IOS, android, mobil, 编程", "postImages/defaultThumbnail.jpg", "IOS Swift软件", 1, 14900 },
                    { 10, 10, 0, "《洛雷姆·伊普苏姆》的段落有无数的变化，但大多数都经历了时间的变化，这是由于插入了讽刺性的段落，或是随机出现了明显不太可能出现的字符序列。如果你决定使用Lorem Ipsum文章，最好确保它没有令人尴尬的内容。一般来说，互联网上的文本生成器倾向于重复预定义的段落，这使得它成为互联网上第一个真正的自动生成器。事实上，它使用了一本包含200多个拉丁词汇的字典，结合一套时间结构模式，生成可信的文本段落。由此产生的文本总是没有重复、笨拙或不合适的词等。", "InitialCreate", new DateTime(2021, 11, 30, 16, 5, 16, 680, DateTimeKind.Local).AddTicks(8287), new DateTime(2021, 11, 30, 16, 5, 16, 680, DateTimeKind.Local).AddTicks(8286), true, false, "InitialCreate", new DateTime(2021, 11, 30, 16, 5, 16, 680, DateTimeKind.Local).AddTicks(8288), "Ruby", "Alper Tunga", "Ruby、Ruby on Rails 网络编程、AirBnb 克隆", "Ruby on Rails、Ruby、Web 编程、AirBnb", "postImages/defaultThumbnail.jpg", "让我们用Ruby on Rails对AirBnb Klon进行编码", 1, 26777 }
                });

            migrationBuilder.InsertData(
                table: "UserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 2, 1 },
                    { 3, 1 },
                    { 4, 1 },
                    { 5, 1 },
                    { 6, 1 },
                    { 7, 1 },
                    { 8, 1 },
                    { 9, 1 },
                    { 10, 1 },
                    { 11, 1 },
                    { 12, 1 },
                    { 13, 1 },
                    { 14, 1 },
                    { 15, 1 },
                    { 16, 1 },
                    { 17, 1 },
                    { 18, 1 },
                    { 19, 1 },
                    { 20, 1 },
                    { 21, 1 },
                    { 22, 1 },
                    { 1, 2 },
                    { 2, 2 },
                    { 3, 2 },
                    { 4, 2 },
                    { 5, 2 },
                    { 6, 2 },
                    { 7, 2 },
                    { 8, 2 },
                    { 17, 2 },
                    { 18, 2 }
                });

            migrationBuilder.InsertData(
                table: "UserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { 19, 2 });

            migrationBuilder.InsertData(
                table: "UserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { 20, 2 });

            migrationBuilder.InsertData(
                table: "UserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { 21, 2 });

            migrationBuilder.InsertData(
                table: "Comments",
                columns: new[] { "Id", "ArticleId", "CreatedByName", "CreatedDate", "IsActive", "IsDeleted", "ModifiedByName", "ModifiedDate", "Note", "Text" },
                values: new object[,]
                {
                    { 1, 1, "InitialCreate", new DateTime(2021, 11, 30, 16, 5, 16, 681, DateTimeKind.Local).AddTicks(1219), true, false, "InitialCreate", new DateTime(2021, 11, 30, 16, 5, 16, 681, DateTimeKind.Local).AddTicks(1220), "C# 文章评论", "Lorem Ipsum 段落有许多变体。 然而，它们中的大多数已经通过添加幽默或添加随机词进行了修改。 如果您打算使用 Lorem Ipsum 片段，您需要确保文本之间没有隐藏令人尴尬的词。 互联网上的所有 Lorem Ipsum 生成器都会重复预定的文本块。 这使得这个生成器成为互联网上真正的 Lorem Ipsum 生成器。 该生成器使用包含 200 多个拉丁词及其句子结构的字典。 因此，所产生的 Lorem Ipsum 文本没有重复、幽默和不寻常的词。" },
                    { 2, 2, "InitialCreate", new DateTime(2021, 11, 30, 16, 5, 16, 681, DateTimeKind.Local).AddTicks(1222), true, false, "InitialCreate", new DateTime(2021, 11, 30, 16, 5, 16, 681, DateTimeKind.Local).AddTicks(1223), "C++ 文章评论", "Ang Lorem Ipsum ginagamit和工业模型以Pagty排版印刷。Ang Lorem Ipsum在15世纪中午时是一个普通的模型，noong可能在一公斤的manlilimbag中，并与ginulo Ang Paggka ayos nito upang libro ng的类型进行了交换。Nalagpasan九英寸长的石灰卷，你的九英寸paglaganap电子版nanatiling parehas。20世纪60年代伊藤正午的Sumikate ito noon是pag labas ng Letraset sheets和Mayrong设计师ng Lorem Ipsum，Kamkailan lang告诉mga桌面出版软件tulad ng Aldus Pagemaker ginamit给bersyon ng Lorem Ipsum。" },
                    { 3, 3, "InitialCreate", new DateTime(2021, 11, 30, 16, 5, 16, 681, DateTimeKind.Local).AddTicks(1225), true, false, "InitialCreate", new DateTime(2021, 11, 30, 16, 5, 16, 681, DateTimeKind.Local).AddTicks(1225), "JavaScript 文章评论", "Ang Lorem Ipsum ginagamit和工业模型以Pagty排版印刷。Ang Lorem Ipsum在15世纪中午时是一个普通的模型，noong可能在一公斤的manlilimbag中，并与ginulo Ang Paggka ayos nito upang libro ng的类型进行了交换。Nalagpasan九英寸长的石灰卷，你的九英寸paglaganap电子版nanatiling parehas。20世纪60年代伊藤正午的Sumikate ito noon是pag labas ng Letraset sheets和Mayrong设计师ng Lorem Ipsum，Kamkailan lang告诉mga桌面出版软件tulad ng Aldus Pagemaker ginamit给bersyon ng Lorem Ipsum。" },
                    { 4, 4, "InitialCreate", new DateTime(2021, 11, 30, 16, 5, 16, 681, DateTimeKind.Local).AddTicks(1227), true, false, "InitialCreate", new DateTime(2021, 11, 30, 16, 5, 16, 681, DateTimeKind.Local).AddTicks(1228), "Typescript 文章评论", "Lorem Ipsum只是字体行业中一个简单的文本市场。之后，当一个匿名的排字员走到标准行业的第16位时，Ipsum称之为标准行业，这是一个邪恶的字母，用来创建一个演示文件夹。-好吧，但是我妻子。-[笑]在60年之前，Letraset与Lorem Ipsum建立了联系，最近，通过发布计算器程序，Aldus PageMaker版本包括了Lorem Ipsum的版本。" },
                    { 5, 5, "InitialCreate", new DateTime(2021, 11, 30, 16, 5, 16, 681, DateTimeKind.Local).AddTicks(1230), true, false, "InitialCreate", new DateTime(2021, 11, 30, 16, 5, 16, 681, DateTimeKind.Local).AddTicks(1230), "Java 文章评论", "Lorem Ipsum只是字体行业中一个简单的文本市场。之后，当一个匿名的排字员走到标准行业的第16位时，Ipsum称之为标准行业，这是一个邪恶的字母，用来创建一个演示文件夹。-好吧，但是我妻子。-[笑]在60年之前，Letraset与Lorem Ipsum建立了联系，最近，通过发布计算器程序，Aldus PageMaker版本包括了Lorem Ipsum的版本。" },
                    { 6, 6, "InitialCreate", new DateTime(2021, 11, 30, 16, 5, 16, 681, DateTimeKind.Local).AddTicks(1232), true, false, "InitialCreate", new DateTime(2021, 11, 30, 16, 5, 16, 681, DateTimeKind.Local).AddTicks(1233), "Python 文章评论", "Lorem Ipsum是一种用于印刷和斯洛伐克工业的简单测试文本。自16世纪以来，Lorem Ipsum一直是一种工业标准，当时一位不知名的印刷商拿走了一个字母印刷库，并命令他们制作一份纸质样本。这段文字不仅流传了五个世纪，而且在世界葡萄酒电子素养方面，这一点基本不变。在20世纪60年代，他因使用Lorem Ipsum的breakers发布Letraset传单而广受欢迎，最近还使用了Aldus PageMaker等表格软件，其中还包含一个可变的Lorem Ipsum。" },
                    { 7, 7, "InitialCreate", new DateTime(2021, 11, 30, 16, 5, 16, 681, DateTimeKind.Local).AddTicks(1235), true, false, "InitialCreate", new DateTime(2021, 11, 30, 16, 5, 16, 681, DateTimeKind.Local).AddTicks(1235), "Php 文章评论", "Lorem Ipsum：这是测谎仪和设计作品中使用的文本的组合。自16年以来，Lorem Ipsum已成为一般文本的替代品。本世纪初。当时，一个不知名的打印机创建了一段文本来打印一本带有字母样本的书。这不仅存在了五个世纪，而且由于转向计算机文本处理，今天也没有改变。在60年代，它出版了Letraset的信件，其中有Lorem Ipsum文本的片段，在最近的历史中，还出版了Aldus PageMaker等设计程序，这些程序已在Lorem Ipsum文本样本中使用。" },
                    { 8, 8, "InitialCreate", new DateTime(2021, 11, 30, 16, 5, 16, 681, DateTimeKind.Local).AddTicks(1237), true, false, "InitialCreate", new DateTime(2021, 11, 30, 16, 5, 16, 681, DateTimeKind.Local).AddTicks(1238), "Kotlin 文章评论", "读者在查看页面布局时会被页面的可读内容分散注意力，这是一个早已确定的事实。使用Lorem Ipsum的意义在于，它的字母分布或多或少是正态的，而不是使用“此处内容，此处内容”，使其看起来像可读的英语。许多桌面发布软件包和网页编辑器现在使用Lorem Ipsum作为默认模型文本，搜索“Lorem Ipsum”将发现许多尚处于起步阶段的网站。多年来，各种版本不断演变，有时出于偶然，有时出于故意（注入幽默等）。" },
                    { 9, 9, "InitialCreate", new DateTime(2021, 11, 30, 16, 5, 16, 681, DateTimeKind.Local).AddTicks(1240), true, false, "InitialCreate", new DateTime(2021, 11, 30, 16, 5, 16, 681, DateTimeKind.Local).AddTicks(1240), "Swift 文章评论", "Laurem Epsom的文本有很多种，但大多数都是通过在文本中插入一些不寻常的或随机的词来修改的。如果你想使用劳雷姆·埃普索姆的文本，你必须首先确认文本中没有尴尬或不恰当的词或短语。虽然所有Loriam Epsom的在线文本生成器都会根据需要多次重复Loriam Epsom的文本，但我们的生成器使用了200多个单词的字典。一个非本意词，加上一组典型的句子，组成一个接近真实文本的逻辑形式的Loriam Epsom文本。因此，产生的案文不重复、不恰当或类似的词语。这就是为什么他是第一个真正的Laurem Epsom在线文本生成器。" },
                    { 10, 10, "InitialCreate", new DateTime(2021, 11, 30, 16, 5, 16, 681, DateTimeKind.Local).AddTicks(1242), true, false, "InitialCreate", new DateTime(2021, 11, 30, 16, 5, 16, 681, DateTimeKind.Local).AddTicks(1242), "Ruby 文章评论", "Lorem Ipsum，也称乱数假文或者哑元文本， 是印刷及排版领域所常用的虚拟文字。由于曾经一台匿名的打印机刻意打乱了一盒印刷字体从而造出一本字体样品书，Lorem Ipsum从西元15世纪起就被作为此领域的标准文本使用。它不仅延续了五个世纪，还通过了电子排版的挑战，其雏形却依然保存至今。在1960年代，”Leatraset”公司发布了印刷着Lorem Ipsum段落的纸张，从而广泛普及了它的使用。最近，计算机桌面出版软件”Aldus PageMaker”也通过同样的方式使Lorem Ipsum落入大众的视野。" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Articles_CategoryId",
                table: "Articles",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Articles_UserId",
                table: "Articles",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Comments_ArticleId",
                table: "Comments",
                column: "ArticleId");

            migrationBuilder.CreateIndex(
                name: "IX_RoleClaims_RoleId",
                table: "RoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "Roles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_UserClaims_UserId",
                table: "UserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_UserLogins_UserId",
                table: "UserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_UserRoles_RoleId",
                table: "UserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "Users",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "Users",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Comments");

            migrationBuilder.DropTable(
                name: "RoleClaims");

            migrationBuilder.DropTable(
                name: "UserClaims");

            migrationBuilder.DropTable(
                name: "UserLogins");

            migrationBuilder.DropTable(
                name: "UserRoles");

            migrationBuilder.DropTable(
                name: "UserTokens");

            migrationBuilder.DropTable(
                name: "Articles");

            migrationBuilder.DropTable(
                name: "Roles");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
