using Domain.Auth;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Shared
{
    public abstract class AuditableEntity : EntityBase
    {
        public DateTime CreatedOn { get; set; }
        public string CreatedById { get; set; }

        [ForeignKey(nameof(CreatedById))]
        public AppUser CreatedBy { get; set; }
        
        public DateTime? ModifiedOn { get; set; }

        public string? ModifiedById { get; set; }

        [ForeignKey(nameof(ModifiedById))]
        public AppUser? ModifiedBy { get; set; }
        public bool IsDeleted { get; set; } = false;

    }
}
