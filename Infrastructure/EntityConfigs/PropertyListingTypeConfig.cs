using Application.Dtos.Read;
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
    public class PropertyListingTypeConfig : IEntityTypeConfiguration<PropertyListingType>
    {
        public void Configure(EntityTypeBuilder<PropertyListingType> builder)
        {
            builder.HasMany(l => l.Properties).WithMany(p => p.ListingTypes);
            builder.HasIndex(l=>l.Title).IsUnique();
            builder
    .HasMany(l => l.Properties)
    .WithMany(p => p.ListingTypes)
    .UsingEntity<Dictionary<int, object>>(
        "PropertyPropertyListingType",
        j => j
            .HasOne<Property>()
            .WithMany()
            .HasForeignKey("ListingTypesId")
            .OnDelete(DeleteBehavior.Restrict),  
        j => j
            .HasOne<PropertyListingType>()
            .WithMany()
            .HasForeignKey("PropertiesId")
            .OnDelete(DeleteBehavior.Restrict)
            );  

        }
    }
}
