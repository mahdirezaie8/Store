using Store.Domain.Core.Data;
using Store.Domain.Core.Dtos;
using Store.Domain.Core.Dtos.ProductDtos;

namespace Store.Domain.Core.Contact.IServices
{
    public interface IProductService
    {
        public Task<ResultDto<List<SowProductDto>>> GetAllProduct();

        public Task<ResultDto<DetailProductDto>> GetProductDetail(int productId);

        public Task<ResultDto<List<SowProductDto>>> GetProductsByCategoryID(int categoryId);
        public Task<ResultDto<SowProductDto>> GetProductById(int id);
        public Task<ResultDto<bool>> CheckCount(int quantity, int productid, string productname);
        public Task UpdateCount(int productid, int count);
        public Task<int> CountProduct(int productid);
    }
}
