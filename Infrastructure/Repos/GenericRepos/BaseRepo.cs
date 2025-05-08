using Application.Interfaces.Repos.GenericRepos;
using Application.ReadOptions;
using Domain.Enums;
using Domain.Shared;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Udemy.Infrastructure.Extensions;

namespace Infrastructure.Repos.GenericRepos
{
    public class BaseRepo<T>(ApplicationDbContext context, ILogger logger) : IBaseRepo<T> where T : AuditableEntity
    {
        public virtual IQueryable<T> GetAllQuery(PaginatedSearchReq searchReq, DeletionType deletionType = DeletionType.NotDeleted, bool trackChanges = false)
        {
            IQueryable<T> query = context.Set<T>();

            //if deletion type not specified

            if (deletionType != DeletionType.All)
            {
                query = query.Where(x => x.IsDeleted == (deletionType == DeletionType.Deleted));
            }

            query = query.Search(searchReq.SearchTerm).Sort(searchReq.OrderBy);

            return trackChanges ? query : query.AsNoTracking();
        }

        public virtual IQueryable<T> GetPageQuery(PaginatedSearchReq searchReq, DeletionType deletionType, bool trackChanges = false)
        {
            var query = GetAllQuery(searchReq, deletionType, trackChanges)
                .Skip((searchReq.PageNumber - 1) * searchReq.PageSize)
                .Take(searchReq.PageSize);

            throw new NotImplementedException();
            //return  context.Set<T>().Skip((pageNumber - 1) * pageSize).Take(pageSize).AsQueryable();
        }
        public T? GetById(int id, DeletionType deletionType, bool trackChanges = false)
        {
            return context.Set<T>().Find(id);
        }
        public async Task<bool> AddAsync(T item, DeletionType deletionType, bool trackChanges = false)
        {
            try
            {
                context.Add(item);
                await context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                logger.LogError("generic repo add exception", ex.Message, ex);
                return false;
            }

        }
        public void Update(T item, DeletionType deletionType, bool trackChanges = false)
        {
            context.Update(item);
        }
        public void Delete(int id)
        {
            T? item = context.Set<T>().Find(id);
            if (item is not null)
            {
                context.Set<T>().Remove(item);
            }
        }
    }
}
