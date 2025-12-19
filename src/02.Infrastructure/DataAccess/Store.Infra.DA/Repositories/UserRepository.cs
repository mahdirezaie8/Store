using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Store.Domain.Core.Data;
using Store.Domain.Core.Dtos.UserDtos;
using Store.Domain.Core.Entities;
using Store.Infra.Db.AppDb;
using System;
using System.Threading.Tasks;


namespace Store.Infra.DA.Repositories
{
    public class UserRepository : IUserRepository
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
        //public async Task<UserDto?> GetUser(string username, string password)
        //{
        //    return await dbContext.Users
        //        .Where(o => o.Username == username
        //        && password == o.Password).Select(o => new UserDto
        //        {
        //            Id = o.Id,
        //            Username = o.Username,
        //            IsActive = o.IsActive,
        //            Role = o.Role,
        //        }).FirstOrDefaultAsync();
        //}
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
        public async Task UpdateWallet(int userid, decimal amount)
        {
            await dbContext.Users
                 .Where(u => u.Id == userid)
                 .ExecuteUpdateAsync(setter => setter
                 .SetProperty(u => u.Wallet, amount));
        }
        public async Task<List<ShowUserDto>> GetAllUser(CancellationToken cancellationToken)
        {
            return await dbContext.Users.Select(u => new ShowUserDto
            {
                Id= u.Id,
                Username = u.IdentityUser.UserName!,
                FullName = u.FullName,
                IsActive = u.IsActive,
                Email=u.IdentityUser.Email!,
            }).ToListAsync(cancellationToken);
        }
        public async Task<bool> UpdateUserIsActive(int userid,bool isactive,CancellationToken cancellationToken)
        {
           var result= await dbContext.Users
                .Where(u => u.Id == userid)
                .ExecuteUpdateAsync(setter=>setter
                .SetProperty(u => u.IsActive, isactive),cancellationToken);
            return result > 0;
        }
        public async Task<bool> DeleteUser(int userid,CancellationToken cancellationToken)
        {
            var result=await dbContext.Users
                .Where(u => u.Id == userid)
                .ExecuteDeleteAsync(cancellationToken);
            return result > 0;
        }
        public async Task<bool> ExistUserByUsername(string username)
        {
            return await dbContext.Users.AnyAsync(u => u.IdentityUser.UserName == username);
        }
        public async Task<bool> GetIsActiveUser(int userid)
        {
            return await dbContext.Users
                .Where(u=>u.Id == userid)
                .Select(u=> u.IsActive)
                .FirstOrDefaultAsync();
        }
        public async Task<bool> IsActive(string username)
        {
            return await dbContext.Users
                .Where(u=>u.IdentityUser.UserName==username)
                .Select(u=>u.IsActive).FirstAsync();
        }
        public async Task<UserProfile?> GetUserProfile(int userid)
        {
            return await dbContext.Users
                .Where(u => u.Id == userid)
                .Select(u => new UserProfile
                {
                    Id = u.Id,
                    Email = u.IdentityUser.Email!,
                    FullName = u.FullName,
                    Username = u.IdentityUser.UserName!,
                    Wallet=u.Wallet,
                }).FirstOrDefaultAsync();
        }
        public async Task<bool> UpdateFullName(int userid,string fullName)
        {
            var result =await dbContext.Users
                .Where(u => u.Id == userid)
                .ExecuteUpdateAsync(setter => setter
                .SetProperty(u => u.FullName, fullName));
            return result > 0;
        }
        public async Task<int> GetIdentityUserId(int userid)
        {
            return await dbContext.Users
                .Where(u => u.Id == userid)
                .Select(u => u.IdentityUserId)
                .FirstOrDefaultAsync();
        }
    }
}
