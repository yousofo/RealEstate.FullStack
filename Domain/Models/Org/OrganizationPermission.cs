using Domain.Shared;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models.Org
{
    public class OrganizationPermission : AuditableEntity
    {
        [StringLength(100)]

        public string Title { get; set; }
        public ICollection<OrganizationRolePermission> RolePermissions { get; set; }

        //public IEnumerable<OrganizationRole> Roles => RolePermissions.Select(p => p.Role);
    }
}
