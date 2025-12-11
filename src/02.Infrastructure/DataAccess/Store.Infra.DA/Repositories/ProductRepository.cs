using Microsoft.EntityFrameworkCore;
using Store.Domain.Core.Data;
using Store.Domain.Core.Dtos.ProductDtos;
using Store.Infra.Db.AppDb;
using System.Threading.Tasks;

namespace Store.Infra.DA.Repositories
{
    public class ProductRepository:IProductRepository
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
                .Where(p=>p.Id==productid)
                .Select(p => p.Count).FirstAsync();
        }
        public async Task UpdateCount(int productid, int count)
        {
            await dbContext.Products
                .Where(p => p.Id == productid)
                .ExecuteUpdateAsync(setter=>setter
                .SetProperty(p=>p.Count, count));
        }
       
    }
}
