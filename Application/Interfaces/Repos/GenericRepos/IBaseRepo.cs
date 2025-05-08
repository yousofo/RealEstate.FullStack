using Application.ReadOptions;
using Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
 
namespace Application.Interfaces.Repos.GenericRepos
{
    public interface IBaseRepo<T> where T : class
    {
        public IQueryable<T> GetAllQuery(PaginatedSearchReq searchReq, DeletionType deletionType, bool trackChanges = false);
        public IQueryable<T> GetPageQuery(PaginatedSearchReq searchReq, DeletionType deletionType, bool trackChanges=false);
        public T? GetById(int id, DeletionType deletionType, bool trackChanges = false);
        public Task<bool> AddAsync(T item, DeletionType deletionType, bool trackChanges = false);
        public void Update(T item, DeletionType deletionType, bool trackChanges = false);
        public void Delete(int id);
    }
}
