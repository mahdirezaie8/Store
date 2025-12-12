using Microsoft.AspNetCore.Http;

namespace Store.Domain.Core.Contact.IServices
{
    public interface IFileService
    {
        public Task<string> Upload(IFormFile file, string folder);
    }
}
