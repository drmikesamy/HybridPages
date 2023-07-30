using Duende.IdentityServer.EntityFramework.Options;
using Duende.IdentityServer.Models;
using Microsoft.AspNetCore.ApiAuthorization.IdentityServer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using HybridPages.Server.Models;
using HybridPages.Shared.Interfaces;
using HybridPages.Shared.Models;
using Microsoft.AspNetCore.Identity;
using HybridPages.Shared.Models.Styling;
using System.Collections.Generic;

namespace HybridPages.Server.Data
{
	public class ApplicationDbContext : ApiAuthorizationDbContext<ApplicationUser>
	{
		public ApplicationDbContext(
			DbContextOptions options,
			IOptions<OperationalStoreOptions> operationalStoreOptions) : base(options, operationalStoreOptions)
		{
		}
		public DbSet<UserProfile> UserProfiles { get; set; }
		public DbSet<Post> Posts { get; set; }
		public DbSet<Page> Pages { get; set; }
		public DbSet<PageMeta> PageMeta { get; set; }
		public DbSet<PostMeta> PostMeta { get; set; }
		public DbSet<UserProfileMeta> UserProfileMeta { get; set; }
		public DbSet<BackgroundMesh> BackgroundMeshes { get; set; }
		public DbSet<ColourPoint> ColourPoints { get; set; }
		public DbSet<Style> Styles { get; set; }
		public DbSet<Font> Fonts { get; set; }
		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			base.OnModelCreating(modelBuilder);
			modelBuilder.Entity<UserProfile>().ToTable("UserProfiles");
			modelBuilder.Entity<Post>().ToTable("Posts");
			modelBuilder.Entity<Page>().ToTable("Pages");
			modelBuilder.Entity<PageMeta>().ToTable("PageMeta");
			modelBuilder.Entity<PostMeta>().ToTable("PostMeta");
			modelBuilder.Entity<UserProfileMeta>().ToTable("UserProfileMeta");
			modelBuilder.Entity<Style>().ToTable("Styles");
			modelBuilder.Entity<Font>().ToTable("Fonts")
				.HasData(GetSeedFonts());
			modelBuilder.Entity<BackgroundMesh>().ToTable("BackgroundMeshes");
			modelBuilder.Entity<ColourPoint>().ToTable("ColourPoints");
		}
		public override Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess, CancellationToken cancellationToken = default(CancellationToken))
		{
			var timeNow = DateTime.UtcNow;
			var createdEntities = ChangeTracker.Entries<IBaseEntity>().Where(e => e.State == EntityState.Added).ToList();
			var modifiedEntities = ChangeTracker.Entries<IBaseEntity>().Where(e => e.State == EntityState.Modified).ToList();
			foreach (var createdEntity in createdEntities)
			{
				createdEntity.Entity.CreatedDate = timeNow;
				createdEntity.Entity.ModifiedDate = timeNow;
			}
			foreach (var modifiedEntity in modifiedEntities)
			{
				modifiedEntity.Entity.ModifiedDate = timeNow;
			}
			return base.SaveChangesAsync(acceptAllChangesOnSuccess, cancellationToken);
		}
		public List<Font> GetSeedFonts()
		{
			return new List<Font>
			{
				new Font { Id = 1, FontFace = "Open Sans", FontPath = "/css/fonts/open-sans/OpenSans-Regular.ttf" },
				new Font { Id = 2, FontFace = "Arsenal", FontPath = "/css/fonts/arsenal/Arsenal-Regular.ttf" },
			};
		}
	}
}