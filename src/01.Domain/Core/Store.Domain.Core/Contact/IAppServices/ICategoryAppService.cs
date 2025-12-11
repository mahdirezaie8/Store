using Store.Domain.Core.Dtos;
using Store.Domain.Core.Dtos.CategoryDtos;

namespace Store.Domain.Core.Contact.IAppServices
{
    public interface ICategoryAppService
    {
        public Task<ResultDto<List<ShowCategory>>> GetAllCategories();
    }
}
