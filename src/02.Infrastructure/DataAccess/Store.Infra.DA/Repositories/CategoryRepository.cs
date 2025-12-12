using Microsoft.EntityFrameworkCore;
using Store.Domain.Core.Data;
using Store.Domain.Core.Dtos.CategoryDtos;
using Store.Domain.Core.Entities;
using Store.Infra.Db.AppDb;
using System.Threading.Tasks;

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
        public async Task<int> Add(Category category,CancellationToken cancellationToken)
        {
            await dbContext.Categories.AddAsync(category);
            await dbContext.SaveChangesAsync(cancellationToken);
            return category.Id;
        }
        public async Task Delete(int id,CancellationToken cancellationToken)
        {
            await dbContext.Categories
                .Where(c=>c.Id==id).ExecuteDeleteAsync(cancellationToken);
        }
        public async Task Update(int id,string title)
        {
            await dbContext.Categories
                .Where(c=>c.Id==id)
                .ExecuteUpdateAsync(setter=>setter
                .SetProperty(c=>c.Title,title));
        }
        public async Task<bool> ExistCategory(int id)
        {
            return await dbContext.Categories.AnyAsync(c=>c.Id==id);
        }
        public async Task<bool> ExistTitle(string title)
        {
            return await dbContext.Categories.AnyAsync(c=>c.Title.ToLower()==title.ToLower());
        }
        public async Task<ShowCategory?> GetCategoryById(int id)
        {
            return await dbContext.Categories.Where(c=>c.Id==id).Select(c => new ShowCategory
            {
                Id = c.Id,
                Title = c.Title,
            }).FirstOrDefaultAsync();
        }
    }
}
