using Infrastructure.Extensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.EntityConfigs
{
    public class VideoConfig :  IEntityTypeConfiguration<Video>
    {
        public void Configure(EntityTypeBuilder<Video> builder)
        {
            builder.ConfigureAuditing();

            builder.HasOne(v => v.Album)
                .WithMany(v => v.Videos)
                .HasForeignKey(v => v.AlbumId)
                .OnDelete(DeleteBehavior.Cascade);

 
        }
    }
}
