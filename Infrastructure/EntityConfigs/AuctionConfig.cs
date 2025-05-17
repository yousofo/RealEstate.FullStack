using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.EntityConfigs
{
    public class AuctionConfig : IEntityTypeConfiguration<Auction>
    {
        public void Configure(EntityTypeBuilder<Auction> builder)
        {
            builder.HasOne(a => a.Property)
                .WithOne(p => p.Auction)
                .HasForeignKey<Auction>(a => a.PropertyId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
