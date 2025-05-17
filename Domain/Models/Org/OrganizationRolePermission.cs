using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models.Org
{
    public class OrganizationRolePermission
    {
        public int OrganizationRoleId { get; set; }
        [ForeignKey("OrganizationRoleId")]
        public OrganizationRole Role { get; set; }

        public int PermissionId { get; set; }
        [ForeignKey("PermissionId")]
        public OrganizationPermission Permission { get; set; }
    }
}
