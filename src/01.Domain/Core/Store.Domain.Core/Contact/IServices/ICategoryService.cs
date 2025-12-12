using Store.Domain.Core.Dtos;
using Store.Domain.Core.Dtos.CategoryDtos;

namespace Store.Domain.Core.Contact.IServices
{
    public interface ICategoryService
    {
        public Task<ResultDto<List<ShowCategory>>> GetAllCategories();
        public Task<ResultDto<bool>> CreateCategory(string title, CancellationToken cancellationToken);
        public Task<ResultDto<bool>> UpdateTitle(int id, string title);
        public Task<ResultDto<bool>> DeleteCategory(int id, CancellationToken cancellationToken);
        public Task<ResultDto<ShowCategory>> GetCategoryById(int id);
    }
}
