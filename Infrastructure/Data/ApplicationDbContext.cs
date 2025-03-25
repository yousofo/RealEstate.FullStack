using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Models;
using Domain.Auth;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Infrastructure.Seed;
using Domain.Shared;
using Microsoft.AspNetCore.Http;
using System.Security.Claims;

namespace Infrastructure.Data
{
    public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options, IHttpContextAccessor httpContextAccessor) : IdentityDbContext<AppUser>(options)
    {

        //migration: 4 business entities
        public DbSet<Property> Properties { get; set; }
        public DbSet<Location> Locations { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<ImageLink> ImageLinks { get; set; }





        protected override void OnModelCreating(ModelBuilder builder)
        {

            base.OnModelCreating(builder);



            //migration: 4
            builder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);



            //migration: 1 // for refresh tokens 
            builder.Entity<AppUser>().OwnsMany(e => e.RefreshTokens, b =>
            {
                b.ToTable("RefreshTokens").WithOwner().HasForeignKey(e => e.UserId);
                //b.WithOwner().HasForeignKey(e => e.UserId);
                b.HasKey(e => new { e.Id, e.UserId });
            });



            //migration: 2 // for seeding roles
            builder.Entity<IdentityRole>().HasData(
                new IdentityRole<string> { Id = "1", Name = "Admin", NormalizedName = "ADMIN" },
                new IdentityRole<string> { Id = "2", Name = "Employee", NormalizedName = "EMPLOYEE" },
                new IdentityRole<string> { Id = "3", Name = "User", NormalizedName = "USER" },
                new IdentityRole<string> { Id = "4", Name = "Seller", NormalizedName = "SELLER" }
            );



            //migration: 3 // for seeding users & roles
            if (Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") == "Development")
            {
                var userSeed = new UserSeed();

                builder.Entity<AppUser>().HasData(
                   userSeed.user, userSeed.admin
                  );

                //assign users roles
                builder.Entity<IdentityUserRole<string>>().HasData(
                new IdentityUserRole<string> { RoleId = "1", UserId = "1" },
                new IdentityUserRole<string> { RoleId = "3", UserId = "2" }
                );

            }


        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            var entities = ChangeTracker.Entries<AuditableEntity>()
                .Where(x => x.Entity is AuditableEntity && (x.State == EntityState.Added || x.State == EntityState.Modified));

            foreach (var entity in entities)
            {
                var currentUserId = httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
                if (entity.State == EntityState.Added)
                {
                    entity.Property(p => p.CreatedById).CurrentValue = "";
                }
                else if (entity.State == EntityState.Modified)
                {
                    entity.Property(p => p.ModifiedById).CurrentValue = "";
                    entity.Property(p => p.ModifiedOn).CurrentValue = DateTime.UtcNow;
                }
            }

            return base.SaveChangesAsync(cancellationToken);
        }
    }
}
