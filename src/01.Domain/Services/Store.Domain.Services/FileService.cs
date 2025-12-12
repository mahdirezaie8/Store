using Microsoft.AspNetCore.Http;
using Store.Domain.Core.Contact.IServices;
using System.Threading.Tasks;

namespace Store.Domain.Services
{
    public class FileService:IFileService
    {
        public async Task<string> Upload(IFormFile file, string folder)
        {

            var uploadsFolder = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "Files", folder);

            if (!Directory.Exists(uploadsFolder))
                Directory.CreateDirectory(uploadsFolder);

            var uniqueFileName = Guid.NewGuid().ToString() + Path.GetExtension(file.FileName);

            var filePath = Path.Combine(uploadsFolder, uniqueFileName);


            using (var stream = new FileStream(filePath, FileMode.Create))
            {
               await file.CopyToAsync(stream);
            }

            return $"{Path.Combine("/Files", folder, uniqueFileName)}";
        }
    }
}
