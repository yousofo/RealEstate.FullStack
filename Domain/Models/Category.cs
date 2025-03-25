using Domain.Shared;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models;

public class Category :AuditableEntity
{
    [StringLength(100)]
    public string Title { get; set; }
    public int? ParentId { get; set; }
    [ForeignKey(nameof(ParentId))]
    public Category? Parent { get; set; }
    public ICollection<Property> Properties { get; set; }
}

