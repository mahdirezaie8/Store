using Store.Domain.Core.Contact.IServices;
using Store.Domain.Core.Data;
using Store.Domain.Core.Dtos;
using Store.Domain.Core.Dtos.CategoryDtos;

namespace Store.Domain.Services
{
    public class CategoryService: ICategoryService
    {
        private readonly ICategoryRepository _categoryRepository;

        public CategoryService(ICategoryRepository CategoryRepository)
        {
            _categoryRepository = CategoryRepository;
        }
        public async Task<ResultDto<List<ShowCategory>>> GetAllCategories()
        {
            var categories =await _categoryRepository.GetAllCategory();
            if (categories.Count > 0)
            {
                return ResultDto<List<ShowCategory>>.Success("success", categories);
            }
            else
                return ResultDto<List<ShowCategory>>.Failure("دسته بندی یافت نشد.");
        }
    }
}
