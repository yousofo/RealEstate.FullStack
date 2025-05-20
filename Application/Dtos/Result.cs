using Application.Dtos.Errors;
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
        public bool IsSuccess => isSuccess;
        public Error? Error => error;
        public override string ToString()
        {
            return JsonSerializer.Serialize(this,JsonSerializerOptions.Web); //This makes the JSON output more readable by adding indentation (pretty-print).
        }

    }
}
