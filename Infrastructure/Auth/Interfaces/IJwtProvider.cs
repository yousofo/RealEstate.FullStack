using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Auth.Interfaces;

public interface IJwtProvider
{
    (string token, int expiresIn) GenerateToken(AppUser user);
}

