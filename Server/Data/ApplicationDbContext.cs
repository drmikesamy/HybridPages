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
using HybridPages.Shared.Models.Forms;
using HybridPages.Shared.Enums;
using HybridPages.Shared.Models.Forms.Types;
using Azure;
using Microsoft.AspNetCore.Mvc.ViewFeatures;

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
		public DbSet<InputFieldType> InputFieldTypes { get; set; }
		public DbSet<InputFieldAttributeType> InputFieldAttributeTypes { get; set; }
		public DbSet<InputField> InputFields { get; set; }
		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			optionsBuilder.EnableSensitiveDataLogging();
		}
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
			modelBuilder.Entity<InputFieldAttributeType>().ToTable("InputFieldAttributeTypes")
				.HasData(GetSeedInputTypes().SelectMany(i => i.InputFieldAttributeTypes).DistinctBy(a => a.Id));
			modelBuilder.Entity<InputFieldType>().ToTable("InputFieldTypes")				
				.HasMany(i => i.InputFieldAttributeTypes)
				.WithMany(t => t.InputFieldTypes)
				.UsingEntity<Dictionary<string, object>>(
					"InputFieldAttributeTypeInputFieldType",
					r => r.HasOne<InputFieldAttributeType>().WithMany().HasForeignKey("InputFieldAttributeTypeId"),
					l => l.HasOne<InputFieldType>().WithMany().HasForeignKey("InputFieldTypeId"),
					lt =>
					{
						lt.HasKey("InputFieldAttributeTypeId", "InputFieldTypeId");
						lt.HasData(GetInputsLinkedList());
					})
				.HasData(GetSeedInputTypes().Select(i => new InputFieldType { Id = i.Id, Tag = i.Tag }));
			modelBuilder.Entity<InputField>().ToTable("InputFields");
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
		public List<InputFieldType> GetSeedInputTypes()
		{
			var inputTypes = new List<InputFieldType>
			{
				new InputFieldType { Id = 1,  Tag = "file", InputFieldAttributeTypes = new HashSet<InputFieldAttributeType> {
					new InputFieldAttributeType { Id = 1, AttributeName = "accept" },
					new InputFieldAttributeType { Id = 2, AttributeName = "capture" },
					new InputFieldAttributeType { Id = 3, AttributeName = "multiple" }
				} },
				new InputFieldType { Id = 2,  Tag = "image", InputFieldAttributeTypes = new HashSet<InputFieldAttributeType> {
					new InputFieldAttributeType { Id = 4, AttributeName = "alt" },
					new InputFieldAttributeType { Id = 5, AttributeName = "formaction" },
					new InputFieldAttributeType { Id = 6, AttributeName = "formenctype" },
					new InputFieldAttributeType { Id = 7, AttributeName = "formmethod" },
					new InputFieldAttributeType { Id = 8, AttributeName = "formnovalidate" },
					new InputFieldAttributeType { Id = 9, AttributeName = "formtarget" },
					new InputFieldAttributeType { Id = 10, AttributeName = "height" },
					new InputFieldAttributeType { Id = 11, AttributeName = "src" },
					new InputFieldAttributeType { Id = 12, AttributeName = "width" }
				} },
				new InputFieldType { Id = 3,  Tag = "checkbox", InputFieldAttributeTypes = new HashSet<InputFieldAttributeType> {
					new InputFieldAttributeType { Id = 13, AttributeName = "checked" },
					new InputFieldAttributeType { Id = 14, AttributeName = "required" }
				} },
				new InputFieldType { Id = 4,  Tag = "radio", InputFieldAttributeTypes = new HashSet<InputFieldAttributeType> {
					new InputFieldAttributeType { Id = 13, AttributeName = "checked" },
					new InputFieldAttributeType { Id = 14, AttributeName = "required" }
				} },
				new InputFieldType { Id = 5,  Tag = "submit", InputFieldAttributeTypes = new HashSet<InputFieldAttributeType> {
					new InputFieldAttributeType { Id = 5, AttributeName = "formaction" },
					new InputFieldAttributeType { Id = 6, AttributeName = "formenctype" },
					new InputFieldAttributeType { Id = 7, AttributeName = "formmethod" },
					new InputFieldAttributeType { Id = 8, AttributeName = "formnovalidate" },
					new InputFieldAttributeType { Id = 9, AttributeName = "formtarget" }
				} },
				new InputFieldType { Id = 6,  Tag = "button", InputFieldAttributeTypes = new HashSet<InputFieldAttributeType> {
					new InputFieldAttributeType { Id = 15, AttributeName = "popovertarget" },
					new InputFieldAttributeType { Id = 16, AttributeName = "popovertargetaction" }
				} },
				new InputFieldType { Id = 7,  Tag = "hidden", InputFieldAttributeTypes = new HashSet<InputFieldAttributeType> {
					new InputFieldAttributeType { Id = 17, AttributeName = "dirname" }
				} },
				new InputFieldType { Id = 8,  Tag = "text", InputFieldAttributeTypes = new HashSet<InputFieldAttributeType> {
					new InputFieldAttributeType { Id = 18, AttributeName = "autocapitalize" },
					new InputFieldAttributeType { Id = 19, AttributeName = "autocomplete" },
					new InputFieldAttributeType { Id = 17, AttributeName = "dirname" },
					new InputFieldAttributeType { Id = 20, AttributeName = "list" },
					new InputFieldAttributeType { Id = 21, AttributeName = "maxlength" },
					new InputFieldAttributeType { Id = 22, AttributeName = "minlength" },
					new InputFieldAttributeType { Id = 23, AttributeName = "pattern" },
					new InputFieldAttributeType { Id = 24, AttributeName = "placeholder" },
					new InputFieldAttributeType { Id = 25, AttributeName = "readonly" },
					new InputFieldAttributeType { Id = 14, AttributeName = "required" },
					new InputFieldAttributeType { Id = 26, AttributeName = "size" }
				} },
				new InputFieldType { Id = 9,  Tag = "search", InputFieldAttributeTypes = new HashSet<InputFieldAttributeType> {
					new InputFieldAttributeType { Id = 18, AttributeName = "autocapitalize" },
					new InputFieldAttributeType { Id = 19, AttributeName = "autocomplete" },
					new InputFieldAttributeType { Id = 17, AttributeName = "dirname" },
					new InputFieldAttributeType { Id = 20, AttributeName = "list" },
					new InputFieldAttributeType { Id = 21, AttributeName = "maxlength" },
					new InputFieldAttributeType { Id = 27, AttributeName = "minlength" },
					new InputFieldAttributeType { Id = 23, AttributeName = "pattern" },
					new InputFieldAttributeType { Id = 24, AttributeName = "placeholder" },
					new InputFieldAttributeType { Id = 25, AttributeName = "readonly" },
					new InputFieldAttributeType { Id = 14, AttributeName = "required" },
					new InputFieldAttributeType { Id = 26, AttributeName = "size" }
				} },
				new InputFieldType { Id = 10,  Tag = "url", InputFieldAttributeTypes = new HashSet<InputFieldAttributeType> {
					new InputFieldAttributeType { Id = 19, AttributeName = "autocomplete" },
					new InputFieldAttributeType { Id = 17, AttributeName = "dirname" },
					new InputFieldAttributeType { Id = 20, AttributeName = "list" },
					new InputFieldAttributeType { Id = 21, AttributeName = "maxlength" },
					new InputFieldAttributeType { Id = 22, AttributeName = "minlength" },
					new InputFieldAttributeType { Id = 23, AttributeName = "pattern" },
					new InputFieldAttributeType { Id = 24, AttributeName = "placeholder" },
					new InputFieldAttributeType { Id = 25, AttributeName = "readonly" },
					new InputFieldAttributeType { Id = 14, AttributeName = "required" },
					new InputFieldAttributeType { Id = 26, AttributeName = "size" }
				} },
				new InputFieldType
				{
					Id = 11,
					Tag = "tel",
					InputFieldAttributeTypes = new HashSet<InputFieldAttributeType> {
					new InputFieldAttributeType { Id = 19, AttributeName = "autocomplete" },
					new InputFieldAttributeType { Id = 17, AttributeName = "dirname" },
					new InputFieldAttributeType { Id = 20, AttributeName = "list" },
					new InputFieldAttributeType { Id = 21, AttributeName = "maxlength" },
					new InputFieldAttributeType { Id = 22, AttributeName = "minlength" },
					new InputFieldAttributeType { Id = 23, AttributeName = "pattern" },
					new InputFieldAttributeType { Id = 24, AttributeName = "placeholder" },
					new InputFieldAttributeType { Id = 25, AttributeName = "readonly" },
					new InputFieldAttributeType { Id = 14, AttributeName = "required" },
					new InputFieldAttributeType { Id = 26, AttributeName = "size" }
				}
				},
				new InputFieldType
				{
					Id = 12,
					Tag = "email",
					InputFieldAttributeTypes = new HashSet<InputFieldAttributeType> {
					new InputFieldAttributeType { Id = 19, AttributeName = "autocomplete" },
					new InputFieldAttributeType { Id = 17, AttributeName = "dirname" },
					new InputFieldAttributeType { Id = 20, AttributeName = "list" },
					new InputFieldAttributeType { Id = 21, AttributeName = "maxlength" },
					new InputFieldAttributeType { Id = 22, AttributeName = "minlength" },
					new InputFieldAttributeType { Id = 3, AttributeName = "multiple" },
					new InputFieldAttributeType { Id = 23, AttributeName = "pattern" },
					new InputFieldAttributeType { Id = 24, AttributeName = "placeholder" },
					new InputFieldAttributeType { Id = 25, AttributeName = "readonly" },
					new InputFieldAttributeType { Id = 14, AttributeName = "required" },
					new InputFieldAttributeType { Id = 26, AttributeName = "size" }
				}
				},
				new InputFieldType
				{
					Id = 13,
					Tag = "password",
					InputFieldAttributeTypes = new HashSet<InputFieldAttributeType> {
					new InputFieldAttributeType { Id = 19, AttributeName = "autocomplete" },
					new InputFieldAttributeType { Id = 21, AttributeName = "maxlength" },
					new InputFieldAttributeType { Id = 22, AttributeName = "minlength" },
					new InputFieldAttributeType { Id = 23, AttributeName = "pattern" },
					new InputFieldAttributeType { Id = 24, AttributeName = "placeholder" },
					new InputFieldAttributeType { Id = 25, AttributeName = "readonly" },
					new InputFieldAttributeType { Id = 14, AttributeName = "required" },
					new InputFieldAttributeType { Id = 26, AttributeName = "size" }
				}
				},
				new InputFieldType
				{
					Id = 14,
					Tag = "number",
					InputFieldAttributeTypes = new HashSet<InputFieldAttributeType> {
					new InputFieldAttributeType { Id = 19, AttributeName = "autocomplete" },
					new InputFieldAttributeType { Id = 20, AttributeName = "list" },
					new InputFieldAttributeType { Id = 27, AttributeName = "max" },
					new InputFieldAttributeType { Id = 28, AttributeName = "min" },
					new InputFieldAttributeType { Id = 24, AttributeName = "placeholder" },
					new InputFieldAttributeType { Id = 25, AttributeName = "readonly" },
					new InputFieldAttributeType { Id = 14, AttributeName = "required" },
					new InputFieldAttributeType { Id = 29, AttributeName = "step" }
				} },
				new InputFieldType { Id = 15,  Tag = "range", InputFieldAttributeTypes = new HashSet<InputFieldAttributeType> {
					new InputFieldAttributeType { Id = 27, AttributeName = "max" },
					new InputFieldAttributeType { Id = 28, AttributeName = "min" },
					new InputFieldAttributeType { Id = 29, AttributeName = "step" }
				} },
				new InputFieldType { Id = 16,  Tag = "date", InputFieldAttributeTypes = new HashSet<InputFieldAttributeType> {
					new InputFieldAttributeType { Id = 19, AttributeName = "autocomplete" },
					new InputFieldAttributeType { Id = 20, AttributeName = "list" },
					new InputFieldAttributeType { Id = 27, AttributeName = "max" },
					new InputFieldAttributeType { Id = 28, AttributeName = "min" },
					new InputFieldAttributeType { Id = 25, AttributeName = "readonly" },
					new InputFieldAttributeType { Id = 14, AttributeName = "required" },
					new InputFieldAttributeType { Id = 29, AttributeName = "step" }
				} },
				new InputFieldType { Id = 17,  Tag = "month", InputFieldAttributeTypes = new HashSet<InputFieldAttributeType> {
					new InputFieldAttributeType { Id = 19, AttributeName = "autocomplete" },
					new InputFieldAttributeType { Id = 20, AttributeName = "list" },
					new InputFieldAttributeType { Id = 27, AttributeName = "max" },
					new InputFieldAttributeType { Id = 28, AttributeName = "min" },
					new InputFieldAttributeType { Id = 25, AttributeName = "readonly" },
					new InputFieldAttributeType { Id = 14, AttributeName = "required" },
					new InputFieldAttributeType { Id = 29, AttributeName = "step" }
				} },
				new InputFieldType { Id = 18,  Tag = "week", InputFieldAttributeTypes = new HashSet<InputFieldAttributeType> {
					new InputFieldAttributeType { Id = 19, AttributeName = "autocomplete" },
					new InputFieldAttributeType { Id = 20, AttributeName = "list" },
					new InputFieldAttributeType { Id = 27, AttributeName = "max" },
					new InputFieldAttributeType { Id = 28, AttributeName = "min" },
					new InputFieldAttributeType { Id = 25, AttributeName = "readonly" },
					new InputFieldAttributeType { Id = 14, AttributeName = "required" },
					new InputFieldAttributeType { Id = 29, AttributeName = "step" }
				} },
				new InputFieldType { Id = 19,  Tag = "time", InputFieldAttributeTypes = new HashSet<InputFieldAttributeType> {
					new InputFieldAttributeType { Id = 19, AttributeName = "autocomplete" },
					new InputFieldAttributeType { Id = 20, AttributeName = "list" },
					new InputFieldAttributeType { Id = 27, AttributeName = "max" },
					new InputFieldAttributeType { Id = 28, AttributeName = "min" },
					new InputFieldAttributeType { Id = 25, AttributeName = "readonly" },
					new InputFieldAttributeType { Id = 14, AttributeName = "required" },
					new InputFieldAttributeType { Id = 29, AttributeName = "step" }
				} },
				new InputFieldType { Id = 20,  Tag = "datetime-local", InputFieldAttributeTypes = new HashSet<InputFieldAttributeType> {
					new InputFieldAttributeType { Id = 19, AttributeName = "autocomplete" },
					new InputFieldAttributeType { Id = 20, AttributeName = "list" },
					new InputFieldAttributeType { Id = 27, AttributeName = "max" },
					new InputFieldAttributeType { Id = 28, AttributeName = "min" },
					new InputFieldAttributeType { Id = 25, AttributeName = "readonly" },
					new InputFieldAttributeType { Id = 14, AttributeName = "required" },
					new InputFieldAttributeType { Id = 29, AttributeName = "step" }
				} },
				new InputFieldType { Id = 21,  Tag = "color", InputFieldAttributeTypes = new HashSet<InputFieldAttributeType> {
					new InputFieldAttributeType { Id = 20, AttributeName = "list" }
				} }
			};
			return inputTypes;
		}
		public List<InputFieldTypeInputFieldAttributeType> GetInputsLinkedList()
		{
			var inputFieldTypeAttributeLinks = new List<InputFieldTypeInputFieldAttributeType>();
			long pk = 1;
			List<Tuple<long, long>> lookup = new List<Tuple<long, long>>
			{
				new Tuple<long, long>(1, 1),
				new Tuple<long, long>(1, 2),
				new Tuple<long, long>(1, 3),
				new Tuple<long, long>(2, 4),
				new Tuple<long, long>(2, 5),
				new Tuple<long, long>(2, 6),
				new Tuple<long, long>(2, 7),
				new Tuple<long, long>(2, 8),
				new Tuple<long, long>(2, 9),
				new Tuple<long, long>(2, 10),
				new Tuple<long, long>(2, 11),
				new Tuple<long, long>(2, 12),
				new Tuple<long, long>(3, 13),
				new Tuple<long, long>(3, 14),
				new Tuple<long, long>(4, 13),
				new Tuple<long, long>(4, 14),
				new Tuple<long, long>(5, 5),
				new Tuple<long, long>(5, 6),
				new Tuple<long, long>(5, 7),
				new Tuple<long, long>(5, 8),
				new Tuple<long, long>(5, 9),
				new Tuple<long, long>(6, 15),
				new Tuple<long, long>(6, 16),
				new Tuple<long, long>(7, 17),
				new Tuple<long, long>(8, 18),
				new Tuple<long, long>(8, 19),
				new Tuple<long, long>(8, 17),
				new Tuple<long, long>(8, 20),
				new Tuple<long, long>(8, 21),
				new Tuple<long, long>(8, 22),
				new Tuple<long, long>(8, 23),
				new Tuple<long, long>(8, 24),
				new Tuple<long, long>(8, 25),
				new Tuple<long, long>(8, 14),
				new Tuple<long, long>(8, 26),
				new Tuple<long, long>(9, 18),
				new Tuple<long, long>(9, 19),
				new Tuple<long, long>(9, 17),
				new Tuple<long, long>(9, 20),
				new Tuple<long, long>(9, 21),
				new Tuple<long, long>(9, 27),
				new Tuple<long, long>(10, 19),
				new Tuple<long, long>(10, 17),
				new Tuple<long, long>(10, 20),
				new Tuple<long, long>(10, 21),
				new Tuple<long, long>(10, 22),
				new Tuple<long, long>(10, 23),
				new Tuple<long, long>(10, 24),
				new Tuple<long, long>(10, 25),
				new Tuple<long, long>(10, 14),
				new Tuple<long, long>(10, 26),
				new Tuple<long, long>(11, 19),
				new Tuple<long, long>(11, 17),
				new Tuple<long, long>(11, 20),
				new Tuple<long, long>(11, 21),
				new Tuple<long, long>(11, 22),
				new Tuple<long, long>(11, 23),
				new Tuple<long, long>(11, 24),
				new Tuple<long, long>(11, 25),
				new Tuple<long, long>(11, 14),
				new Tuple<long, long>(11, 26),
				new Tuple<long, long>(12, 19),
				new Tuple<long, long>(12, 17),
				new Tuple<long, long>(12, 20),
				new Tuple<long, long>(12, 21),
				new Tuple<long, long>(12, 22),
				new Tuple<long, long>(12, 23),
				new Tuple<long, long>(12, 24),
				new Tuple<long, long>(12, 25),
				new Tuple<long, long>(12, 14),
				new Tuple<long, long>(12, 26),
				new Tuple<long, long>(13, 19),
				new Tuple<long, long>(13, 21),
				new Tuple<long, long>(13, 22),
				new Tuple<long, long>(13, 23),
				new Tuple<long, long>(13, 24),
				new Tuple<long, long>(13, 25),
				new Tuple<long, long>(13, 14),
				new Tuple<long, long>(13, 26),
				new Tuple<long, long>(14, 19),
				new Tuple<long, long>(14, 20),
				new Tuple<long, long>(14, 27),
				new Tuple<long, long>(14, 28),
				new Tuple<long, long>(14, 24),
				new Tuple<long, long>(14, 25),
				new Tuple<long, long>(14, 14),
				new Tuple<long, long>(14, 29),
				new Tuple<long, long>(15, 19),
				new Tuple<long, long>(15, 20),
				new Tuple<long, long>(15, 27),
				new Tuple<long, long>(15, 28),
				new Tuple<long, long>(15, 25),
				new Tuple<long, long>(15, 14),
				new Tuple<long, long>(15, 29),
				new Tuple<long, long>(16, 19),
				new Tuple<long, long>(16, 20),
				new Tuple<long, long>(16, 27),
				new Tuple<long, long>(16, 28),
				new Tuple<long, long>(16, 25),
				new Tuple<long, long>(16, 14),
				new Tuple<long, long>(16, 29),
				new Tuple<long, long>(17, 19),
				new Tuple<long, long>(17, 20),
				new Tuple<long, long>(17, 27),
				new Tuple<long, long>(17, 28),
				new Tuple<long, long>(17, 25),
				new Tuple<long, long>(17, 14),
				new Tuple<long, long>(17, 29),
				new Tuple<long, long>(18, 19),
				new Tuple<long, long>(18, 20),
				new Tuple<long, long>(18, 27),
				new Tuple<long, long>(18, 28),
				new Tuple<long, long>(18, 25),
				new Tuple<long, long>(18, 14),
				new Tuple<long, long>(18, 29),
				new Tuple<long, long>(19, 19),
				new Tuple<long, long>(19, 20),
				new Tuple<long, long>(19, 27),
				new Tuple<long, long>(19, 28),
				new Tuple<long, long>(19, 25),
				new Tuple<long, long>(19, 14),
				new Tuple<long, long>(19, 29),
				new Tuple<long, long>(20, 19),
				new Tuple<long, long>(20, 20),
				new Tuple<long, long>(20, 27),
				new Tuple<long, long>(20, 28),
				new Tuple<long, long>(20, 25),
				new Tuple<long, long>(20, 14),
				new Tuple<long, long>(20, 29),
				new Tuple<long, long>(21, 20)
			};

			foreach (var item in lookup)
			{
				inputFieldTypeAttributeLinks.Add(new InputFieldTypeInputFieldAttributeType { InputFieldTypeId = item.Item1, InputFieldAttributeTypeId = item.Item2 });
			}

			return inputFieldTypeAttributeLinks;
		}
	}
}