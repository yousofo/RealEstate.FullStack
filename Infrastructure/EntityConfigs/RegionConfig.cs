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
    public class RegionConfig : IEntityTypeConfiguration<Region>
    {
        public void Configure(EntityTypeBuilder<Region> builder)
        {
            builder.ConfigureAuditing();

            builder.HasMany(r=>r.Properties)
                .WithOne(p=>p.Region)
                .HasForeignKey(p=>p.RegionId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
