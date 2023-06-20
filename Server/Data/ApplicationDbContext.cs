﻿using Duende.IdentityServer.EntityFramework.Options;
using Duende.IdentityServer.Models;
using Microsoft.AspNetCore.ApiAuthorization.IdentityServer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using HybridPages.Server.Models;
using HybridPages.Shared.Interfaces;
using HybridPages.Shared.Models;
using Microsoft.AspNetCore.Identity;

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
        public DbSet<UserMeta> UserMeta { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<UserProfile>().ToTable("UserProfiles");
            modelBuilder.Entity<Post>().ToTable("Links");
            modelBuilder.Entity<Page>().ToTable("Posts");
            modelBuilder.Entity<PageMeta>().ToTable("PageMeta");
            modelBuilder.Entity<UserMeta>().ToTable("UserMeta");
        }
        public override Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess, CancellationToken cancellationToken = default(CancellationToken))
        {
            var timeNow = DateTime.UtcNow;
            var createdEntities = ChangeTracker.Entries<IBaseEntity>().Where(e => e.State == EntityState.Added).ToList();
            var modifiedEntities = ChangeTracker.Entries<IBaseEntity>().Where(e => e.State == EntityState.Modified).ToList();
            foreach (var createdEntity in createdEntities)
            {
                createdEntity.Entity.CreatedDate = timeNow;
            }
            foreach (var modifiedEntity in modifiedEntities)
            {
                modifiedEntity.Entity.ModifiedDate = timeNow;
            }
            return base.SaveChangesAsync(acceptAllChangesOnSuccess, cancellationToken);
        }
    }
}