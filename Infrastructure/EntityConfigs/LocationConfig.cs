using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.EntityConfigs
{
    internal class LocationConfig : IEntityTypeConfiguration<Location>
    {
        public void Configure(EntityTypeBuilder<Location> builder)
        {

            builder.HasOne(a => a.CreatedBy)
                 .WithMany() // No navigation property in AppUser
                 .HasForeignKey(e => e.CreatedById)
                 .OnDelete(DeleteBehavior.Restrict); // Prevent cascade delete

            builder.HasOne(a => a.ModifiedBy)
                .WithMany()
                .HasForeignKey(e => e.ModifiedById)
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(a => a.Parent)
                .WithMany()
                .HasForeignKey(e => e.ParentId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
