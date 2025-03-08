using Application.Dtos.Read;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces.Repos
{
    public interface IAuthRepo
    {
        Task<LoginRDTO?> LoginAsync(string email, string password, CancellationToken cancellationToken = default);

    }
}
