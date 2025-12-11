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

    }
}
