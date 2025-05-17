using Domain.Models.Org;
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
    public class OrganizationRoleConfig : IEntityTypeConfiguration<OrganizationRole>
    {
        public void Configure(EntityTypeBuilder<OrganizationRole> builder)
        {
            builder.ConfigureAuditing();
            builder.HasMany(r=>r.Users).WithMany(u=>u.OrganizationRoles);
 
            builder.HasOne(r=>r.Organization)
                .WithMany(p => p.Roles)
                .HasForeignKey(r=>r.OrganizationId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
