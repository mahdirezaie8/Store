using Store.Domain.Core.Dtos;
using Store.Domain.Core.Dtos.UserDtos;

namespace Store.Domain.Core.Contact.IServices
{
    public interface IUserService
    {
        public Task<ResultDto<UserDto>> Login(string username, string password);

        public Task<ResultDto<decimal>> GetWalletAmount(int userId);

        public Task<ResultDto<bool>> UpdateWallet(int userId, decimal amount);
    }
}
