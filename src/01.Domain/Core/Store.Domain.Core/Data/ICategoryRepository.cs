using Microsoft.EntityFrameworkCore;
using Store.Domain.Core.Dtos.CategoryDtos;
using Store.Domain.Core.Entities;

namespace Store.Domain.Core.Data
{
    public interface ICategoryRepository
    {
        public Task<List<ShowCategory>> GetAllCategory();
        public Task<int> Add(Category category, CancellationToken cancellationToken);
        public Task Delete(int id, CancellationToken cancellationToken);
        public Task Update(int id, string title);
        public Task<bool> ExistCategory(int id);
        public Task<bool> ExistTitle(string title);
        public Task<ShowCategory?> GetCategoryById(int id);
    }
}
