using Application.Dtos;
using Application.ReadOptions;
using Domain.Models.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces.Services
{
    public interface IBaseViewService<T>  
    {
        public Task<IEnumerable<T>> GetAllAsync(CancellationToken cancellationToken);

        public Task<PaginatedRes<T>> GetPageAsync(PaginatedSearchReq searchReq, CancellationToken cancellationToken );
    }
}
