﻿using Domain.Shared;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class City : AuditableEntity
    {
        public string Name { get; set; }




        public ICollection<Property> Properties { get; set; }
        public int StateId { get; set; }
        public State State { get; set; }
    }
}
