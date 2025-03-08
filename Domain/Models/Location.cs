using Domain.Shared;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class Location: EntityBase
    {
        [StringLength(100)]
        public string Title { get; set; }
        public int? ParentId {  get; set; }
        [ForeignKey("ParentId")]
        public Location? Parent { get; set; }
    }
}
