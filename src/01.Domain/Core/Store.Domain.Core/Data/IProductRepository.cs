using Store.Domain.Core.Dtos.ProductDtos;

namespace Store.Domain.Core.Data
{
    public interface IProductRepository
    {
        public Task<List<SowProductDto>> GetAllProducts();

        public Task<DetailProductDto?> GetDetailProduct(int productId);

        public Task<bool> ExistProduct(int productId);

        public Task<List<SowProductDto>> GetProductsByCategoryID(int categoryId);
        public Task<SowProductDto?> GetProductById(int id);
        public Task<int> GetCount(int productid);
        public Task UpdateCount(int productid, int count);
    }
}
