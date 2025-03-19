﻿using Domain.Shared;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Auth
{
    [Owned]
    public class RefreshToken : EntityBase
    {
        public string UserId { get; set; }
        //[ForeignKey("UserId")]
        //public AppUser AppUser { get; set; }
        public string Token { get; set; }
        public DateTime ExpiresOn { get; set; }
        public DateTime CreatedOn { get; set; } = DateTime.UtcNow;
        public DateTime? RevokenOn { get; set; }
        public bool IsExpired => DateTime.UtcNow >= ExpiresOn;
        public bool IsValid => RevokenOn is null && !IsExpired;
    }
}
