﻿using Application.Interfaces.Repos.GenericRepos;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repos.GenericRepos
{
    public class BaseRepo<T>(ApplicationDbContext context, ILogger logger) : IBaseRepo<T> where T : class
    {
        public virtual IQueryable<T> GetAllQuery()
        {
            return context.Set<T>().AsQueryable();
        }

        public virtual IQueryable<T> GetPageQuery(int pageNumber, int pageSize = 20)
        {
            return  context.Set<T>().Skip((pageNumber - 1) * pageSize).Take(pageSize).AsQueryable();
        }
        public T? GetById(int id)
        {
            return context.Set<T>().Find(id);
        }
        public async Task<bool> AddAsync(T item)
        {
            try
            {
                context.Add(item);
                await context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                logger.LogError("generic repo add exception",ex.Message,ex);
                return false;
            }

        }
        public void Update(T item)
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
