using Domain.Auth;
using Domain.Shared;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models.Org
{
    public class OrganizationRole:AuditableEntity
    {
        [StringLength(100)]
        public string Title { get; set; }

        [ForeignKey("OrganizationId")]
        public Organization Organization { get; set; }
        public int OrganizationId { get; set; }
        public ICollection<OrganizationRolePermission> RolePermissions { get; set; }
        //public IEnumerable<OrganizationPermission> Permissions => RolePermissions.Select(p => p.Permission);
        public ICollection<AppUser> Users { get; set; }
    }
}
