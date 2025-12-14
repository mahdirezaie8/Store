using Store.Domain.Core.Dtos;
using Store.Domain.Core.Dtos.UserDtos;

namespace Store.Domain.Core.Contact.IAppServices
{
    public interface IUserAppService
    {
        public Task<ResultDto<UserDto>> Login(string username, string password);
        public Task<ResultDto<bool>> UpdateUserWallet(int userid, decimal TotalPrice);
        public Task<ResultDto<List<ShowUserDto>>> GetAllUser(CancellationToken cancellationToken);
        public Task<ResultDto<bool>> DeleteUser(int userId, CancellationToken cancellationToken);
        public Task<ResultDto<bool>> UpdateUserIsActive(int userId, CancellationToken cancellationToken);
        public Task<ResultDto<bool>> Register(RegisterDto register);
    }
}
