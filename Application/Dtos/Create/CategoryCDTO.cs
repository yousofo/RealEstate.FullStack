﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Dtos.Create
{
    public class CategoryCDTO
    {
        [StringLength(100), Required]
        public string Title { get; set; }
    }
}
