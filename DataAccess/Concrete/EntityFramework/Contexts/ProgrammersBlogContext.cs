using DataAccess.Concrete.EntityFramework.Mapping;
using Entities.Concrete;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Concrete.EntityFramework.Contexts;

public class
	ProgrammersBlogContext : IdentityDbContext<User, Role, int, UserClaim, UserRole, UserLogin, RoleClaim, UserToken>
{
	public ProgrammersBlogContext(DbContextOptions<ProgrammersBlogContext> options) : base(options)
	{
	}

	public DbSet<Article> Articles { get; set; }
	public DbSet<Category> Categories { get; set; }
	public DbSet<Comment> Comments { get; set; }

	protected override void OnModelCreating(ModelBuilder modelBuilder)
	{
		modelBuilder.ApplyConfiguration(new ArticleMap());
		modelBuilder.ApplyConfiguration(new CategoryMap());
		modelBuilder.ApplyConfiguration(new CommentMap());
		modelBuilder.ApplyConfiguration(new RoleMap());
		modelBuilder.ApplyConfiguration(new UserMap());
		modelBuilder.ApplyConfiguration(new RoleClaimMapping());
		modelBuilder.ApplyConfiguration(new UserClaimMapping());
		modelBuilder.ApplyConfiguration(new UserLoginMapping());
		modelBuilder.ApplyConfiguration(new UserRoleMap());
		modelBuilder.ApplyConfiguration(new UserTokenMapping());
	}
}