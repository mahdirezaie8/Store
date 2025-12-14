using Store.Domain.Core.Contact.IAppServices;
using Store.Domain.Core.Contact.IServices;
using Store.Domain.Core.Dtos;
using Store.Domain.Core.Dtos.UserDtos;
using System.Threading.Tasks;

namespace Store.Domain.AppServices
{
    public class UserAppService:IUserAppService
    {
        private readonly IUserService userService;

        public UserAppService(IUserService UserService)
        {
            userService = UserService;
        }

        public async Task<ResultDto<bool>> DeleteUser(int userId, CancellationToken cancellationToken)
        {
            return await userService.DeleteUser(userId, cancellationToken);
        }

        public async Task<ResultDto<List<ShowUserDto>>> GetAllUser(CancellationToken cancellationToken)
        {
            return await userService.GetAllUser(cancellationToken);
        }

        public async Task<ResultDto<UserDto>> Login(string username, string password)
        {
           return await userService.Login(username, password);
        }

        public async Task<ResultDto<bool>> UpdateUserIsActive(int userId, CancellationToken cancellationToken)
        {
            return await userService.UpdateUserIsActive(userId, cancellationToken);
        }

        public async Task<ResultDto<bool>> UpdateUserWallet(int userid,decimal TotalPrice)
        {
            var userwallet=await userService.GetWalletAmount(userid);
            if(userwallet.IsSuccess)
            {
                var wallet=userwallet.Data;
                if (wallet > TotalPrice)
                {
                    var newwallet = wallet - TotalPrice;
                    var update =await userService.UpdateWallet(userid, newwallet);
                    return ResultDto<bool>.Success("عملیات با موفقیت انجام شد.");
                }
                else
                    return ResultDto<bool>.Failure("موجودی شما کافی نمی باشد.");
            }
            return ResultDto<bool>.Failure("یوزر پیدا نشد.");
        }
        public async Task<ResultDto<bool>> Register(RegisterDto register)
        {
            return await userService.Register(register);
        }
    }
}
