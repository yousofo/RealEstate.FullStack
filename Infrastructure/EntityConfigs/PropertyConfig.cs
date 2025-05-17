using Infrastructure.Extensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.EntityConfigs
{
    public class PropertyConfig :  IEntityTypeConfiguration<Property>
    {

        public   void Configure(EntityTypeBuilder<Property> builder)
        {
            builder.ConfigureAuditing();
            builder.Property(e => e.Price).HasPrecision(18, 4);

            builder.HasOne(e=>e.Owner)
                .WithMany(e => e.Properties)
                .HasForeignKey(e => e.OwnerId)
                .OnDelete(DeleteBehavior.Cascade);
 

            //builder.HasOne(p=>p.City)
            //    .WithMany(c=>c.Properties)
            //    .HasForeignKey(p => p.CityId)
            //    .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
