using Store.Domain.Core.Contact.IServices;
using Store.Domain.Core.Data;
using Store.Domain.Core.Dtos;
using Store.Domain.Core.Dtos.ProductDtos;
using System.Threading.Tasks;

namespace Store.Domain.Services
{
    public class ProductService: IProductService
    {
        private readonly IProductRepository _productRepository;

        public ProductService(IProductRepository ProductRepository)
        {
            _productRepository = ProductRepository;
        }
        public async Task<ResultDto<List<SowProductDto>>> GetAllProduct()
        {
            var products = await _productRepository.GetAllProducts();
            if (products.Count > 0)
            {
                return ResultDto<List<SowProductDto>>.Success("success", products);
            }  
            else
            {
                return ResultDto<List<SowProductDto>>.Failure("محصولی یافت نشد.");
            }     
        }

        public async Task<ResultDto<DetailProductDto>> GetProductDetail(int productId)
        {
            var exist = await _productRepository.ExistProduct(productId);
            if (!exist)
            {
                return ResultDto<DetailProductDto>.Failure("محصول وجود ندارد.");
            }
            else
            {
                var product = await _productRepository.GetDetailProduct(productId);
                return ResultDto<DetailProductDto>.Success("success", product);
            }
        }

        public async Task<ResultDto<List<SowProductDto>>> GetProductsByCategoryID(int categoryId)
        {
            var products = await _productRepository.GetProductsByCategoryID(categoryId);
            if (products.Count > 0)
            {
                return ResultDto<List<SowProductDto>>.Success("success", products);
            }
            else
            {
                return ResultDto<List<SowProductDto>>.Failure("محصولی با این دسته بندی یافت نشد.");
            }
        }

        public async Task<ResultDto<SowProductDto>> GetProductById(int id)
        {
            var product = await _productRepository.GetProductById(id);
            if (product != null)
            {
                return ResultDto<SowProductDto>.Success("success", product);
            }
            else
            {
                return ResultDto<SowProductDto>.Failure("محصول یافت نشد.");
            }
        }
        public async Task<ResultDto<bool>> CheckCount(int quantity,int productid,string productname)
        {
            var exist=await _productRepository.ExistProduct(productid);
            if (exist)
            {
                var countproduct=await _productRepository.GetCount(productid);
                if(countproduct>=quantity)
                {
                    return ResultDto<bool>.Success("success");
                }
                else
                {
                    return ResultDto<bool>.Failure($"تعداد این محصول{productname} سبد خرید از موجودی محصول بیشتر است");
                }

            }
            else
            {
                return ResultDto<bool>.Failure("محصول یافت نشد.");
            }
        }
        public async Task UpdateCount(int productid, int count)
        {
            var oldcountproduct=await _productRepository.GetCount(productid);
            var newcount = oldcountproduct - count;
             await _productRepository.UpdateCount(productid, newcount);
        } 
        public async Task<int> CountProduct(int productid)
        {
            return await _productRepository.GetCount(productid);
        }
    }
}
