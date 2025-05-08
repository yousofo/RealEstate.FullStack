using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.EntityConfigs
{
    public class AlbumConfig : IEntityTypeConfiguration<Album>
    {
        public void Configure(EntityTypeBuilder<Album> builder)
        {
            builder.HasIndex(a => new { a.PropertyId, a.UserId }).IsUnique();

            builder.HasOne(a => a.Property)
                .WithOne(p => p.Album)
                .HasPrincipalKey<Property>(p => p.Id)
                .HasForeignKey<Album>(a => a.PropertyId)
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(a => a.User)
                .WithOne(p => p.Album)
                .HasPrincipalKey<AppUser>(u => u.Id)
                .HasForeignKey<Album>(a => a.UserId)
                .OnDelete(DeleteBehavior.Cascade);

        }

    }
}
