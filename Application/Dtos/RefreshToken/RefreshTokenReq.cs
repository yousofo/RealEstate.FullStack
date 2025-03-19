using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Dtos.RefreshToken;

public record RefreshTokenReq(
    string Token,
    string RefreshToken
);

