using Store.Domain.Core.Dtos;
using Store.Domain.Core.Dtos.CategoryDtos;

namespace Store.Domain.Core.Contact.IServices
{
    public interface ICategoryService
    {
        public Task<ResultDto<List<ShowCategory>>> GetAllCategories();
    }
}
