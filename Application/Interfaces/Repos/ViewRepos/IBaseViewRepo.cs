using Application.Dtos;
using Application.ReadOptions;
using Domain.Models.Views;

namespace Infrastructure.Repos
{
    public interface IBaseViewRepo<T>  
    {
        public Task<IEnumerable<T>> GetAllAsync(CancellationToken cancellationToken = default);
        public IQueryable<T> GetAllQuery(PaginatedSearchReq searchReq);
        public Task<PaginatedRes<T>> GetPageAsync(PaginatedSearchReq searchReq, CancellationToken cancellationToken);


    }
}