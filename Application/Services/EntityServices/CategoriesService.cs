using Application.Dtos.Read;
using Application.Interfaces.Repos;
using Application.Interfaces.Services.EntityServices;
using AutoMapper;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.EntityServices
{
    public class CategoriesService(IReposManager manager, IMapper mapper) : ICategoriesService
    {
        public async Task<IEnumerable<CategoryRDTO>> GetAllAsync()
        {
            throw new NotImplementedException();
        }
    }
}
