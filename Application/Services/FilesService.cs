using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public class FilesService
    {
        public static async Task<string?> SaveFileAsync(IFormFile image)
        {
            if (image != null && image.Length > 0)
            {
                var fileName = Guid.NewGuid().ToString() + Path.GetExtension(image.FileName);

                string fullPath = Path.Combine(Environment.CurrentDirectory, "wwwroot", "images", fileName);

                using (var file = File.Create(fullPath))
                {
                    await image.CopyToAsync(file);
                }
                return fileName;

            }
            return null;
        }
    }
}
