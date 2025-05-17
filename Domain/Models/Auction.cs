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
    public class Auction:AuditableEntity
    {
        public string? OwnerId { get; set; }
        [ForeignKey("OwnerId")]
        public AppUser Owner {  get; set; }
        // owner is either customer or organization
        public int? OrganizationId { get; set; }
        [ForeignKey("OrganizationId")]
        public Organization Organization {  get; set; }
        //
        public string? WinnerUserId { get; set; }
        [ForeignKey("WinnerUserId")]
        public AppUser WinnerUser {  get; set; }
        //
        public int? WinnerOrganizationId { get; set; }
        [ForeignKey("WinnerOrganizationId")]
        public Organization WinnerOrganization {  get; set; }
        //
        public int PropertyId { get; set; }
        [ForeignKey("PropertyId")]
        public Property Property { get; set; }
        //
        public ICollection<Bid> Bids { get; set; }
        //
        public decimal StartPrice { get; set; } = 0;
        public decimal EndPrice { get; set; }= 0;
        
        
    }
}
