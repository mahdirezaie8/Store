using Microsoft.EntityFrameworkCore;
using Store.Domain.Core.Dtos;
using Store.Domain.Core.Dtos.ProductDtos;
using Store.Domain.Core.Entities;

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
        public Task<List<DetailProductDto>> GetDetailAllProduct(CancellationToken cancellationToken, int page, int pagesize);
        public Task Delete(int productid, CancellationToken cancellationToken);
        public Task Updata();
        public int TotalPage(int pagesize);
        public Task<UpdateProductDto?> GetProductForUpdate(int id);
        public Task<Product?> GetProduct(int id);
        public Task<int> Add(Product product, CancellationToken cancellationToken);
        public Task<string?> GetProductPathImg(int id);
    }
}
