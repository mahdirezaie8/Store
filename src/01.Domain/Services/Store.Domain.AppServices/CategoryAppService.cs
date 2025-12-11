using Store.Domain.Core.Contact.IAppServices;
using Store.Domain.Core.Contact.IServices;
using Store.Domain.Core.Dtos;
using Store.Domain.Core.Dtos.CategoryDtos;
using System.Threading.Tasks;

namespace Store.Domain.AppServices
{
    public class CategoryAppService: ICategoryAppService
    {
        private readonly ICategoryService categoryService;

        public CategoryAppService(ICategoryService CategoryService)
        {
            categoryService = CategoryService;
        }
        public async Task<ResultDto<List<ShowCategory>>> GetAllCategories()
        {
            return await categoryService.GetAllCategories();
        }
    }
}
