﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Dtos.Create
{
    public class CountryCDTO
    {
        [StringLength(30)]
        public string Name { get; set; }
        [StringLength(5)]
        public string Code { get; set; }
    }
}
