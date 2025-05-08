using Application.Dtos;
using Application.ReadOptions;
using Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces.Repos
{
    public interface IBaseRepo<T> where T : class
    {
        public IQueryable<T> GetAllQuery(PaginatedSearchReq searchReq, DeletionType deletionType, bool trackChanges = false);
        public Task<PaginatedRes<T>> GetPageAsync(PaginatedSearchReq searchReq, DeletionType deletionType, bool trackChanges = false);
        public T? GetById(int id, DeletionType deletionType, bool trackChanges = false);
        public Task<bool> AddAsync(T item , bool trackChanges = false);
        public void Update(T item , bool trackChanges = false);
        public void Delete(int id);
    }
}
