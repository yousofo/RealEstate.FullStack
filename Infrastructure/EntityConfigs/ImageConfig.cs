using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Infrastructure.Extensions;

namespace Infrastructure.EntityConfigs
{
    public class ImageConfig :  IEntityTypeConfiguration<Image>
    {
        public   void Configure(EntityTypeBuilder<Image> builder)
        {
            builder.ConfigureAuditing();

            builder.HasOne(v => v.Album)
                .WithMany(v => v.Images)
                .HasForeignKey(v => v.AlbumId)
                .OnDelete(DeleteBehavior.Cascade);

 
        }
    }
}
