using Application.Options;
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
        public static async Task<string> SaveAsync(IFormFile image,FileType fileType)
        {
            var fileCategory = fileType == FileType.Image ? "images" : "videos";
            
            if (image != null && image.Length > 0)
            {
                var fileName = Guid.NewGuid().ToString() + Path.GetExtension(image.FileName);

                string fullPath = Path.Combine(Environment.CurrentDirectory, "wwwroot", fileCategory, fileName);

                using (var file = File.Create(fullPath))
                {
                    await image.CopyToAsync(file);
                }
                return fileName;

            }
            return string.Empty;
        }
    }
}
