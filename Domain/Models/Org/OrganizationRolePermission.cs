using Domain.Shared;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models.Org
{
    public class OrganizationRolePermission:AuditableEntity
    {
        [StringLength(100)]
 
        public string Title { get; set; }
    }
}
