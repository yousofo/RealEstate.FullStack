using Domain.Models;
using Domain.Models.Org;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Auth
{
    public class AppUser : IdentityUser
    {
        [StringLength(50)]
        public string FirstName { get; set; }= "";
        [StringLength(50)]
        public string LastName { get; set; } = "";

        public ICollection<Property>? Properties { get; set; } = [];
        
        public Album Album { get; set; }
        public List<RefreshToken> RefreshTokens { get; set; } = [];
        public ICollection<Bid> Bids { get; set; }




        //organizations
        public ICollection<OrganizationRole> OrganizationRoles { get; set; }
        [MaxLength(2)]
        public ICollection<Organization> Organizations { get; set; }
    }
}
