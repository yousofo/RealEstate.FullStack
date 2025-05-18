﻿using Application.Dtos.Errors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Application.Dtos
{
    public class Result(bool isSuccess, Error error)
    {
        public bool IsSuccess { get; set; }
        public Error Error { get; set; }
        public override string ToString()
        {
            return JsonSerializer.Serialize(this); //This makes the JSON output more readable by adding indentation (pretty-print).
        }

    }
}
