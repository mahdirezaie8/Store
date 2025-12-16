
using Microsoft.EntityFrameworkCore;
using Store.Domain.Core.Data;
using Store.Domain.Core.Dtos;
using Store.Domain.Core.Dtos.ProductDtos;
using Store.Domain.Core.Entities;
using Store.Infra.Db.AppDb;
using System.Threading.Tasks;

namespace Store.Infra.DA.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly AppDbContext dbContext;

        public ProductRepository(AppDbContext DbContext)
        {
            dbContext = DbContext;
        }
        public async Task<List<SowProductDto>> GetAllProducts()
        {
            return await dbContext.Products
                .Select(p => new SowProductDto
                {
                    Id = p.Id,
                    Name = p.Name,
                    Image = p.Image,
                    Price = p.Price,
                    CategoryId = p.CategoryId,
                })
                .ToListAsync();
        }

        public async Task<DetailProductDto?> GetDetailProduct(int productId)
        {
            return await dbContext.Products
                .Where(p => p.Id == productId)
                .Select(p => new DetailProductDto
                {
                    Id = p.Id,
                    Price = p.Price,
                    Count = p.Count,
                    Description = p.Description,
                    Image = p.Image,
                    Name = p.Name,
                })
                .FirstOrDefaultAsync();
        }

        public async Task<bool> ExistProduct(int productId)
        {
            return await dbContext.Products.AnyAsync(p => p.Id == productId);
        }

        public async Task<List<SowProductDto>> GetProductsByCategoryID(int categoryId)
        {
            return await dbContext.Products
                .Where(p => p.CategoryId == categoryId)
                .Select(p => new SowProductDto
                {
                    Id = p.Id,
                    Name = p.Name,
                    Image = p.Image,
                    Price = p.Price,
                    CategoryId = p.CategoryId,
                })
                .ToListAsync();
        }

        public async Task<SowProductDto?> GetProductById(int id)
        {
            return await dbContext.Products
                .Where(p => p.Id == id)
                .Select(p => new SowProductDto
                {
                    Id = p.Id,
                    Price = p.Price,
                    CategoryId = p.CategoryId,
                    Image = p.Image,
                    Name = p.Name
                })
                .FirstOrDefaultAsync();
        }
        public async Task<int> GetCount(int productid)
        {
            return await dbContext.Products
                .Where(p => p.Id == productid)
                .Select(p => p.Count).FirstAsync();
        }
        public async Task UpdateCount(int productid, int count)
        {
            await dbContext.Products
                .Where(p => p.Id == productid)
                .ExecuteUpdateAsync(setter => setter
                .SetProperty(p => p.Count, count));
        }
        public async Task<List<DetailProductDto>> GetDetailAllProduct(CancellationToken cancellationToken, int page, int pagesize)
        {
            if(page==0)
            {
                page = 1;
            }
            return await dbContext.Products
                .OrderBy(p => p.Id)
                .Skip((page - 1) * pagesize)
                .Take(pagesize)
                .Select(p => new DetailProductDto
                {
                    Id = p.Id,
                    Price = p.Price,
                    Count = p.Count,
                    Description = p.Description,
                    Image = p.Image,
                    Name = p.Name,
                }).ToListAsync(cancellationToken);
        }
        public async Task Delete(int productid, CancellationToken cancellationToken)
        {
            await dbContext.Products.Where(p => p.Id == productid).ExecuteDeleteAsync(cancellationToken);
        }
        public async Task Updata()
        {
            await dbContext.SaveChangesAsync();
        }
        public async Task<Product?> GetProduct(int id)
        {
            return await dbContext.Products.FirstOrDefaultAsync(p => p.Id == id);
        }
        public int TotalPage(int pagesize)
        {
            var count = dbContext.Products.Count();
            var total = (int)Math.Ceiling((double)count / pagesize);
            return total;
        }
        public async Task<UpdateProductDto?> GetProductForUpdate(int id)
        {
            return await dbContext.Products
                .Where(p => p.Id == id)
                .Select(p => new UpdateProductDto
                {
                    Id = p.Id,
                    Price = p.Price,
                    Description = p.Description,
                    Image = p.Image,
                    Name = p.Name
                })
                .FirstOrDefaultAsync();
        }
        public async Task<int> Add(Product product,CancellationToken cancellationToken)
        {
            await dbContext.Products.AddAsync(product,cancellationToken);
            await dbContext.SaveChangesAsync();
            return product.Id;
        }
        public async Task<string?> GetProductPathImg(int id)
        {
            return await dbContext.Products
                .Where(p => p.Id == id)
                .Select(p => p.Image)
                .FirstOrDefaultAsync();
        }
    }
}
