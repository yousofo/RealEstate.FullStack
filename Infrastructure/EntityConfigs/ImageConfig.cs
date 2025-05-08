using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.EntityConfigs
{
    public class ImageConfig : IEntityTypeConfiguration<Image>
    {
        public void Configure(EntityTypeBuilder<Image> builder)
        {
            builder.HasOne(v => v.Album)
                .WithMany(v => v.Images)
                .HasForeignKey(v => v.AlbumId)
                .OnDelete(DeleteBehavior.Cascade);

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
