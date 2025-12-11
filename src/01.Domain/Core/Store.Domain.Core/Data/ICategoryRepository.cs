using Store.Domain.Core.Dtos.CategoryDtos;

namespace Store.Domain.Core.Data
{
    public interface ICategoryRepository
    {
        public Task<List<ShowCategory>> GetAllCategory();
    }
}
