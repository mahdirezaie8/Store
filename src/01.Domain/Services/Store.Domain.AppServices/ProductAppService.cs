using Store.Domain.Core.Contact.IAppServices;
using Store.Domain.Core.Contact.IServices;
using Store.Domain.Core.Data;
using Store.Domain.Core.Dtos;
using Store.Domain.Core.Dtos.CartPageDtos;
using Store.Domain.Core.Dtos.ProductDtos;
using System.Threading.Tasks;

namespace Store.Domain.AppServices
{
    public class ProductAppService:IProductAppService
    {
        private readonly IProductService productService;

        public ProductAppService(IProductService ProductService)
        {
            productService = ProductService;
        }
        public async Task<ResultDto<List<SowProductDto>>> GetAllProduct()
        {
            return await productService.GetAllProduct();
        }

        public async Task<ResultDto<DetailProductDto>> GetProductDetail(int productid)
        {
            return await productService.GetProductDetail(productid);
        }
        public async Task<ResultDto<List<SowProductDto>>> GetProductsByCategoryID(int categoryid)
        {
            return await productService.GetProductsByCategoryID(categoryid);
        }
        public async Task<ResultDto<SowProductDto>> GetProductById(int id)
        {
            return await productService.GetProductById(id);
        }
        public async Task<ResultDto<bool>> CheckCount(int quantity, int productid, string productname)
        {
            return await productService.CheckCount(quantity, productid,productname);
        }
        public async Task UpdateCount(CartDto cartDto)
        {
            foreach(var item in cartDto.CartItemDtos)
            {
                var productid = item.ProductId;
                var count = item.Quantity;
                await productService.UpdateCount(productid, count);
            }
            
        }
        public async Task<int> CountProduct(int productid)
        {
            return await productService.CountProduct(productid);
        }
        public async Task<ResultDto<List<DetailProductDto>>> GetDetailAllProduct(CancellationToken cancellationToken, int page, int pagesize)
        {
            return await productService.GetDetailAllProduct(cancellationToken, page, pagesize);
        }
        public async Task<ResultDto<bool>> Updateproduct(UpdateProductDto updateProductDto, int productid,CancellationToken cancellationToken)
        {
            return await productService.Updateproduct(updateProductDto, productid, cancellationToken);
        }
        public async Task<ResultDto<bool>> Delete(int productid, CancellationToken cancellationToken)
        {
            return await productService.Delete(productid, cancellationToken);
        }
        public async Task<ResultDto<bool>> UpdateProductCount(int count, int productid)
        {
            return await productService.UpdateProductCount(count, productid);
        }
        public int TotalPage(int pagesize)
        {
            return productService.TotalPage(pagesize);
        }
        public async Task<ResultDto<UpdateProductDto>> GetProductForUpdate(int id)
        {
            return await productService.GetProductForUpdate(id);
        }
        public async Task<ResultDto<bool>> CreateProduct(CreateProductDto createProductDto, CancellationToken cancellationToken)
        {
            return await productService.CreateProduct(createProductDto, cancellationToken);
        }
    }
}
