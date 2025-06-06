﻿using Application.Dtos.Create;
using Application.Dtos.Read;
using Application.Dtos.Update;
using Application.Interfaces.Repos;
using Application.Interfaces.Services.EntityServices;
using AutoMapper;
using Domain.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.EntityServices
{
    public class CategoriesService(IReposManager manager, IMapper mapper) : BaseService<Category,CategoryRDTO,CategoryCDTO,CategoryUDTO>(manager.Categories,mapper),ICategoriesService
    {
        
    }
}
