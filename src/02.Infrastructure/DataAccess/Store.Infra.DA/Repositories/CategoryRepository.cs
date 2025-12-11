using Microsoft.EntityFrameworkCore;
using Store.Domain.Core.Data;
using Store.Domain.Core.Dtos.CategoryDtos;
using Store.Infra.Db.AppDb;

namespace Store.Infra.DA.Repositories
{
    public class CategoryRepository: ICategoryRepository
    {
        private readonly AppDbContext dbContext;

        public CategoryRepository(AppDbContext DbContext)
        {
            dbContext = DbContext;
        }
        public async Task<List<ShowCategory>> GetAllCategory()
        {
            return await dbContext.Categories.Select(c=>new ShowCategory
            {
                Id = c.Id,
                Title = c.Title,
            }).ToListAsync();
        }
    }
}
