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

        public async Task<ResultDto<bool>> CreateCategory(string title, CancellationToken cancellationToken)
        {
            return await categoryService.CreateCategory(title, cancellationToken);
        }

        public async Task<ResultDto<bool>> DeleteCategory(int id, CancellationToken cancellationToken)
        {
            return await categoryService.DeleteCategory(id, cancellationToken);
        }

        public async Task<ResultDto<List<ShowCategory>>> GetAllCategories()
        {
            return await categoryService.GetAllCategories();
        }

        public async Task<ResultDto<bool>> UpdateTitle(int id, string title)
        {
            return await categoryService.UpdateTitle(id, title);
        }
        public async Task<ResultDto<ShowCategory>> GetCategoryById(int id)
        {
            return await categoryService.GetCategoryById(id);
        }
    }
}
