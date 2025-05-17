using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Shared;

namespace Infrastructure.Extensions
{
    public static class ConfigurationExtensions
    {
        public static void ConfigureAuditing<T>(this EntityTypeBuilder<T> builder)
                where T : AuditableEntity
        {
            builder.HasOne(e => e.CreatedBy)
                   .WithMany()
                   .HasForeignKey(e => e.CreatedById)
                   .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(e => e.ModifiedBy)
                   .WithMany()
                   .HasForeignKey(e => e.ModifiedById)
                   .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
