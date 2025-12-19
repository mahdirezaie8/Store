using Store.Domain.Core.Data;
using Store.Domain.Core.Dtos;
using Store.Domain.Core.Dtos.UserDtos;

namespace Store.Domain.Core.Contact.IServices
{
    public interface IUserService
    {
        public Task<ResultDto<bool>> Login(string username, string password);

        public Task<ResultDto<decimal>> GetWalletAmount(int userId);

        public Task<ResultDto<bool>> UpdateWallet(int userId, decimal amount);
        public Task<ResultDto<List<ShowUserDto>>> GetAllUser(CancellationToken cancellationToken);
        public Task<ResultDto<bool>> DeleteUser(int userId, CancellationToken cancellationToken);
        public Task<ResultDto<bool>> UpdateUserIsActive(int userId, CancellationToken cancellationToken);
        public Task<ResultDto<bool>> Register(RegisterDto register);
        public Task<ResultDto<UserProfile>> GetUserProfile(int userId);
        public Task<ResultDto<bool>> UpdateFullName(int userid, string fullName);
        public Task<int> GetIdentityUserId(int userid);
    }
}
