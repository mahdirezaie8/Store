using Microsoft.EntityFrameworkCore;
using Store.Domain.Core.Contact.IServices;
using Store.Domain.Core.Data;
using Store.Domain.Core.Dtos;
using Store.Domain.Core.Dtos.ProductDtos;
using Store.Domain.Core.Entities;
using System.Threading;
using System.Threading.Tasks;

namespace Store.Domain.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;
        private readonly IFileService fileService;

        public ProductService(IProductRepository ProductRepository,IFileService FileService)
        {
            _productRepository = ProductRepository;
            fileService = FileService;
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
        public async Task<ResultDto<bool>> CheckCount(int quantity, int productid, string productname)
        {
            var exist = await _productRepository.ExistProduct(productid);
            if (exist)
            {
                var countproduct = await _productRepository.GetCount(productid);
                if (countproduct >= quantity)
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
            var oldcountproduct = await _productRepository.GetCount(productid);
            var newcount = oldcountproduct - count;
            await _productRepository.UpdateCount(productid, newcount);
        }
        public async Task<int> CountProduct(int productid)
        {
            return await _productRepository.GetCount(productid);
        }
        public async Task<ResultDto<List<DetailProductDto>>> GetDetailAllProduct(CancellationToken cancellationToken, int page, int pagesize)
        {
            var products = await _productRepository.GetDetailAllProduct(cancellationToken,page,pagesize);
            if (products.Count > 0)
            {
                return ResultDto<List<DetailProductDto>>.Success("success", products);
            }
            else
                return ResultDto<List<DetailProductDto>>.Failure("محصولی یافت نشد.");
        }
        public async Task<ResultDto<bool>> Updateproduct(UpdateProductDto updateProductDto, int productid, CancellationToken cancellationToken)
        {
            var product = await _productRepository.GetProduct(productid);
            if (product != null && productid == updateProductDto.Id)
            {
                if (updateProductDto.ProfileImage != null)
                {
                    product.Image =await fileService.Upload(updateProductDto.ProfileImage,"Img");
                }
                if (updateProductDto.Name != null)
                {
                    product.Name = updateProductDto.Name;
                }
                if (updateProductDto.Description != null)
                {
                    product.Description = updateProductDto.Description;
                }
                if (updateProductDto.Price.HasValue)
                {
                    product.Price = updateProductDto.Price.Value;
                }
                await _productRepository.Updata();
                return ResultDto<bool>.Success("آپدیت با موفقیت انجام شد.");
            }
            else
                return ResultDto<bool>.Failure("محصول یافت نشد.");
        }
        public async Task<ResultDto<bool>> Delete(int productid, CancellationToken cancellationToken)
        {
            var exist = await _productRepository.ExistProduct(productid);
            if (exist)
            {
                await _productRepository.Delete(productid, cancellationToken);
                return ResultDto<bool>.Success("success");
            }
            else
                return ResultDto<bool>.Failure("محصول پیدا نشد.");

        }
        public async Task<ResultDto<bool>> UpdateProductCount(int count, int productid)
        {
            var exist = await _productRepository.ExistProduct(productid);
            if (exist)
            {
                await _productRepository.UpdateCount(productid, count);
                return ResultDto<bool>.Success("success");
            }
            else
                return ResultDto<bool>.Failure("محصول پیدا نشد.");
        }
        public int TotalPage(int pagesize)
        {
            return _productRepository.TotalPage(pagesize); 
        }
        public async Task<ResultDto<UpdateProductDto>> GetProductForUpdate(int id)
        {
            var product = await _productRepository.GetProductForUpdate(id);
            if (product != null)
            {
                return ResultDto<UpdateProductDto>.Success("success", product);
            }
            else
            {
                return ResultDto<UpdateProductDto>.Failure("محصول یافت نشد.");
            }
        }
        public async Task<ResultDto<bool>> CreateProduct(CreateProductDto createProductDto,CancellationToken cancellationToken)
        {
            if(string.IsNullOrEmpty(createProductDto.Name)
                && string.IsNullOrEmpty(createProductDto.Description)
                &&createProductDto.Count==null
                &&createProductDto.Price==null)
            {
                return ResultDto<bool>.Failure("لطفا تمام فیلد هارو پر عکنید .داشتن عکس الزامی نیست.");
            }
            else
            {
                string image = null;
                if(createProductDto.ProfileImage!=null)
                {
                     image = await fileService.Upload(createProductDto.ProfileImage, "Img");
                }
                var newproduct = new Product
                {
                    Name = createProductDto.Name,
                    Description = createProductDto.Description,
                    Price = createProductDto.Price,
                    CategoryId = createProductDto.CategoryId,
                    Count = createProductDto.Count,
                    Image = image
                };
               var id=await _productRepository.Add(newproduct, cancellationToken);
                return ResultDto<bool>.Success("عملیات با موفقیت انجام شد.");
            }
        }

    }
}
