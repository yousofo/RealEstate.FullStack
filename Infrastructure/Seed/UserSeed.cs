 using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Intrinsics.X86;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Seed
{
    public class UserSeed
    {
        public AppUser user;
        public AppUser admin;
        public UserSeed()
        {
            user = new AppUser
            {
                Id = "1",
                UserName = "youssef1",
                NormalizedUserName = "YOUSSEF1",
                Email = "test@test.com",
                NormalizedEmail = "TEST@TEST.COM",
                EmailConfirmed = true,
                PasswordHash = "AQAAAAIAAYagAAAAEE7iAGoK16nHp2rWZElaHIXjcIv3nJnC2TCVblYlPBfaEXtv5/fCHjb7wIR6HQX8Ag==",//new PasswordHasher<AppUser>().HashPassword(null,"test"),//
                SecurityStamp = "",
                ConcurrencyStamp = "12121212abc",
                FirstName = "Youssef",
                LastName = "Elmoussaoui",
                PhoneNumber = "123456789",
                PhoneNumberConfirmed = true,
                TwoFactorEnabled = false,
                LockoutEnd = null,
                LockoutEnabled = false,
                AccessFailedCount = 0
            };
            admin = new AppUser
            {
                Id = "2",
                UserName = "youssef2",
                NormalizedUserName = "YOUSSEF2",
                Email = "admin@test.com",
                NormalizedEmail = "ADMIN@TEST.COM",
                EmailConfirmed = true,
                PasswordHash = "AQAAAAIAAYagAAAAEE7iAGoK16nHp2rWZElaHIXjcIv3nJnC2TCVblYlPBfaEXtv5/fCHjb7wIR6HQX8Ag==",//new PasswordHasher<AppUser>().HashPassword(null,"test"),//"AQAAAAIAAYagAAAAEE7iAGoK16nHp2rWZElaHIXjcIv3nJnC2TCVblYlPBfaEXtv5/fCHjb7wIR6HQX8Ag=="
                SecurityStamp = "",
                ConcurrencyStamp = "12121212bca",
                FirstName = "Youssef",
                LastName = "Elmoussaoui",
                PhoneNumber = "1234567890",
                PhoneNumberConfirmed = true,
                TwoFactorEnabled = false,
                LockoutEnd = null,
                LockoutEnabled = false,
                AccessFailedCount = 0
            };

        }
    }
}
