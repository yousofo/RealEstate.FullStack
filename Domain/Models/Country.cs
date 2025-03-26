using Domain.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class Country: AuditableEntity
    {
        public string Name { get; set; }
        public string Code { get; set; }



        public ICollection<State> States { get; set; }
    }
}
