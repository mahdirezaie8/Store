using Store.Domain.Core.Data;
using Store.Domain.Core.Dtos;
using Store.Domain.Core.Dtos.CartPageDtos;
using Store.Domain.Core.Dtos.ProductDtos;

namespace Store.Domain.Core.Contact.IAppServices
{
    public interface IProductAppService
    {
        public Task<ResultDto<List<SowProductDto>>> GetAllProduct();

        public Task<ResultDto<DetailProductDto>> GetProductDetail(int productid);
        public Task<ResultDto<List<SowProductDto>>> GetProductsByCategoryID(int categoryid);
        public Task<ResultDto<SowProductDto>> GetProductById(int id);
        public Task<ResultDto<bool>> CheckCount(int quantity, int productid, string productname);
        public Task UpdateCount(CartDto cartDto);
        public Task<int> CountProduct(int productid);
    }
}
