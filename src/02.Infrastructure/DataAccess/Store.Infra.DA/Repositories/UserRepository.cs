using Microsoft.EntityFrameworkCore;
using Store.Domain.Core.Data;
using Store.Domain.Core.Dtos.UserDtos;
using Store.Domain.Core.Entities;
using Store.Infra.Db.AppDb;

namespace Store.Infra.DA.Repositories
{
    public class UserRepository:IUserRepository
    {
        private readonly AppDbContext dbContext;

        public UserRepository(AppDbContext DbContext)
        {
            dbContext = DbContext;
        }
        public async Task<int> Add(User user)
        {
           await dbContext.Users.AddAsync(user);
           await dbContext.SaveChangesAsync();
            return user.Id;
        }
        public async Task<UserDto?> GetUser(string username, string password)
        {
            return await dbContext.Users
                .Where(o => o.Username == username
                && password == o.Password).Select(o => new UserDto
                {
                    Id = o.Id,
                    Username = o.Username,
                }).FirstOrDefaultAsync();
        }
        public async Task<decimal> GetWalletAmount(int userid)
        {
            return await dbContext.Users
                .Where(u => u.Id == userid)
                .Select(u => u.Wallet).FirstAsync();
        }
        public async Task<bool> ExistUser(int userid)
        {
            return await dbContext.Users.AnyAsync(u => u.Id == userid);
        }
        public async Task UpdateWallet(int userid,decimal amount)
        {
           await dbContext.Users
                .Where(u=>u.Id == userid)
                .ExecuteUpdateAsync(setter=>setter
                .SetProperty(u=>u.Wallet, amount));
        }
    }
}
