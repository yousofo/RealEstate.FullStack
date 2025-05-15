using Domain.Auth;
using Domain.Shared;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models.Org
{
    public class OrganizationRole:AuditableEntity
    {
        [StringLength(100)]
        public string Title { get; set; }

        public Organization Organization { get; set; }
        public int OrganizationId { get; set; }
        public ICollection<OrganizationRolePermission> Permissions { get; set; }
        public ICollection<AppUser> Users { get; set; }
    }
}
