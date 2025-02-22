using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces.Repos
{
    public interface IBaseRepo<T> where T : class
    {
        public Task<IEnumerable<T>> GetAllAsync();
        public IEnumerable<T> GetPage(int pageNumber, int pageSize = 20);
        public T? GetById(int id);
        public Task<bool> AddAsync(T item);
        public void Update(T item);
        public void Delete(int id);
    }
}
