using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.EntityConfigs
{
    public class ImageLinkConfig : IEntityTypeConfiguration<ImageLink>
    {
        public void Configure(EntityTypeBuilder<ImageLink> builder)
        {

            builder.HasOne(a => a.CreatedBy)
                 .WithMany() // No navigation property in AppUser
                 .HasForeignKey(e => e.CreatedById)
                 .OnDelete(DeleteBehavior.Restrict); // Prevent cascade delete

            builder.HasOne(a => a.ModifiedBy)
                .WithMany()
                .HasForeignKey(e => e.ModifiedById)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
