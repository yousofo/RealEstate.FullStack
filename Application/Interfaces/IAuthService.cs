using Application.Dtos.Read;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface IAuthService
    {
        Task<LoginRDTO?> LoginAsync(string username, string password,CancellationToken cancellationToken = default); 
    }
}
