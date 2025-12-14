using Microsoft.EntityFrameworkCore;
using Store.Domain.Core.Dtos.UserDtos;
using Store.Domain.Core.Entities;

namespace Store.Domain.Core.Data
{
    public interface IUserRepository
    {
        public Task<int> Add(User user);
        public Task<UserDto?> GetUser(string username, string password);
        public Task<decimal> GetWalletAmount(int userid);
        public Task<bool> ExistUser(int userid);
        public Task UpdateWallet(int userid, decimal amount);
        public Task<List<ShowUserDto>> GetAllUser(CancellationToken cancellationToken);
        public Task<bool> UpdateUserIsActive(int userid, bool isactive, CancellationToken cancellationToken);
        public Task<bool> DeleteUser(int userid, CancellationToken cancellationToken);
        public Task<bool> ExistUserByUsername(string username);
        public Task<bool> GetIsActiveUser(int userid);
    }
}
