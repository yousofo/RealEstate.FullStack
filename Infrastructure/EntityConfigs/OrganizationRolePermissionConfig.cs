using Domain.Models.Org;
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
    internal class OrganizationRolePermissionConfig : IEntityTypeConfiguration<OrganizationRolePermission>
    {
        public void Configure(EntityTypeBuilder<OrganizationRolePermission> builder)
        {
            builder.HasKey(x => new { x.OrganizationRoleId, x.PermissionId });

            builder.HasOne(x => x.Role)
                .WithMany(r => r.RolePermissions)
                .HasForeignKey(x => x.OrganizationRoleId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(x => x.Permission)
                .WithMany(p => p.RolePermissions)
                .HasForeignKey(x => x.PermissionId)
                .OnDelete(DeleteBehavior.Restrict); 
        }
    }
}
