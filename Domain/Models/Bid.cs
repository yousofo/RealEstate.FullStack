using Domain.Auth;
using Domain.Models.Org;
using Domain.Shared;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class Bid:AuditableEntity
    {
        public int AuctionId { get; set; }
        [ForeignKey("AuctionId")]
        public Auction Auction { get; set; }
        //
        public string? CustomerId { get; set; }
         public AppUser Customer { get; set; }
        //
        public int? OrganizationId { get; set; }
        [ForeignKey("OrganizationId")]
        public Organization Organization { get; set; }
        //
        public decimal Amount {  get; set; }

    }
}
