using Store.Domain.Core.Contact.IServices;
using Store.Domain.Core.Data;
using Store.Domain.Core.Dtos;
using Store.Domain.Core.Dtos.CategoryDtos;
using Store.Domain.Core.Entities;
using System.Threading;
using System.Threading.Tasks;

namespace Store.Domain.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _categoryRepository;

        public CategoryService(ICategoryRepository CategoryRepository)
        {
            _categoryRepository = CategoryRepository;
        }
        public async Task<ResultDto<List<ShowCategory>>> GetAllCategories()
        {
            var categories = await _categoryRepository.GetAllCategory();
            if (categories.Count > 0)
            {
                return ResultDto<List<ShowCategory>>.Success("success", categories);
            }
            else
                return ResultDto<List<ShowCategory>>.Failure("دسته بندی یافت نشد.");
        }
        public async Task<ResultDto<bool>> CreateCategory(string title, CancellationToken cancellationToken)
        {
            if (string.IsNullOrEmpty(title))
            {
                return ResultDto<bool>.Failure("لطفا فیلد را پر کنید.");
            }
            else
            {
                var exist = await _categoryRepository.ExistTitle(title);
                if (exist)
                {
                    return ResultDto<bool>.Failure("این دسته بندی وجود دارد.");
                }
                else
                {
                    var newcategory = new Category()
                    {
                        Title = title,
                    };
                    var id = await _categoryRepository.Add(newcategory, cancellationToken);
                    return ResultDto<bool>.Success("عملیات با موفقیت انجام شد.");
                }
            }
        }
        public async Task<ResultDto<bool>> UpdateTitle(int id, string title)
        {
            var existcategory = await _categoryRepository.ExistCategory(id);
            if (existcategory)
            {
                if (string.IsNullOrEmpty(title))
                {
                    return ResultDto<bool>.Failure("لطفا فیلد را پر کنید.");
                }
                else
                {
                    var exist = await _categoryRepository.ExistTitle(title);
                    if (exist)
                    {
                        return ResultDto<bool>.Failure("این عنوان وجود دارد.");
                    }
                    else
                    {
                        await _categoryRepository.Update(id, title);
                        return ResultDto<bool>.Success("عملیات با موفقیت انجام شد.");
                    }
                }
            }
            else
                return ResultDto<bool>.Failure("این دسته بندی وجود ندارد.");
        }
        public async Task<ResultDto<bool>> DeleteCategory(int id,CancellationToken cancellationToken)
        {
            var existcategory = await _categoryRepository.ExistCategory(id);
            if (existcategory)
            {
                await _categoryRepository.Delete(id,cancellationToken);
                return ResultDto<bool>.Success("عملیات با موفقیت انجام شد.");
            }
            else
                return ResultDto<bool>.Failure("این دسته بندی وجود ندارد.");
        }
        public async Task<ResultDto<ShowCategory>> GetCategoryById(int id)
        {
            var existcategory = await _categoryRepository.ExistCategory(id);
            if (existcategory)
            {
                var category=await _categoryRepository.GetCategoryById(id);
                return ResultDto<ShowCategory>.Success("",category);
            }
            else
                return ResultDto<ShowCategory>.Failure("این دسته بندی وجود ندارد.");
        }
    }
}
