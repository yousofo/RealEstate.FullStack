﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Shared
{
    public abstract class AuditableEntityBase : EntityBase
    {
        public DateTime CreatedOn { get; set; }

        //public string CreatedBy { get; set; }

        public DateTime ModifiedOn { get; set; }

        //public string ModifiedBy { get; set; }
    }
}
