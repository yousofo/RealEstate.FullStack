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
    public class Organization : AuditableEntity
    {
        [StringLength(70)]
        public string Name { get; set; }
        [StringLength(500)]
        public string Description { get; set; }
        public ICollection<OrganizationRole> Roles { get; set; }
        public ICollection<Property> Properties { get; set; }
        public ICollection<AppUser> Users { get; set; }
    }
}
