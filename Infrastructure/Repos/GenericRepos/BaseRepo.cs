using Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repos.GenericRepos
{
    public class BaseRepo<T>(ApplicationDbContext context) where T : class
    {
        public IEnumerable<T> GetAll()
        {
            return context.Set<T>().ToList();
        }
        public IEnumerable<T> GetPage(int pageNumber, int pageSize = 20)
        {
            return context.Set<T>().Skip((pageNumber - 1) * pageSize).Take(pageSize).ToList();
        }
        public T? GetById(int id)
        {
            return context.Set<T>().Find(id);
        }
        public void Add(T item)
        {
            context.Add(item);
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
