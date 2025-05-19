using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.EntityConfigs
{
    public class LocationViewConfig : IEntityTypeConfiguration<LocationView>
    {
        public void Configure(EntityTypeBuilder<LocationView> builder)
        {
            builder.ToView("LocationView").HasNoKey();
        }
    }
}
