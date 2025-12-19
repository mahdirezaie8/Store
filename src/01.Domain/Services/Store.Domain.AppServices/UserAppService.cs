using Store.Domain.Core.Contact.IAppServices;
using Store.Domain.Core.Contact.IServices;
using Store.Domain.Core.Dtos;
using Store.Domain.Core.Dtos.UserDtos;
using System.Threading.Tasks;

namespace Store.Domain.AppServices
{
    public class UserAppService : IUserAppService
    {
        private readonly IUserService userService;
        private readonly IIdentityUserAppService identityUserAppService;

        public UserAppService(IUserService UserService, IIdentityUserAppService IdentityUserAppService)
        {
            userService = UserService;
            identityUserAppService = IdentityUserAppService;
        }

        public async Task<ResultDto<bool>> DeleteUser(int userId, CancellationToken cancellationToken)
        {
            return await userService.DeleteUser(userId, cancellationToken);
        }

        public async Task<ResultDto<List<ShowUserDto>>> GetAllUser(CancellationToken cancellationToken)
        {
            return await userService.GetAllUser(cancellationToken);
        }

        public async Task<ResultDto<bool>> Login(string username, string password)
        {
            return await userService.Login(username, password);
        }

        public async Task<ResultDto<bool>> UpdateUserIsActive(int userId, CancellationToken cancellationToken)
        {
            return await userService.UpdateUserIsActive(userId, cancellationToken);
        }

        public async Task<ResultDto<bool>> UpdateUserWallet(int userid, decimal TotalPrice)
        {
            var userwallet = await userService.GetWalletAmount(userid);
            if (userwallet.IsSuccess)
            {
                var wallet = userwallet.Data;
                if (wallet > TotalPrice)
                {
                    var newwallet = wallet - TotalPrice;
                    var update = await userService.UpdateWallet(userid, newwallet);
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
        public async Task<ResultDto<UserProfile>> GetUserProfile(int userId)
        {
            return await userService.GetUserProfile(userId);
        }
        public async Task<ResultDto<bool>> UpdateProfileUser(UpdateProfileDto updateProfileDto)
        {
            var identityid = await userService.GetIdentityUserId(updateProfileDto.UserId);
            if (!string.IsNullOrEmpty(updateProfileDto.Username) ||
                !string.IsNullOrEmpty(updateProfileDto.Email))
            {
                var result = await identityUserAppService.UpdateIdentity(identityid, updateProfileDto.Username, updateProfileDto.Email);
                if (!result.IsSuccess)
                {
                    return ResultDto<bool>.Failure(result.Message!);
                }
            }
            if(!string.IsNullOrEmpty(updateProfileDto.FullName))
            {
                var result=await userService.UpdateFullName(updateProfileDto.UserId,updateProfileDto.FullName);
                if (!result.IsSuccess)
                {
                    return ResultDto<bool>.Failure(result.Message!);
                }
            }
            if(!string.IsNullOrEmpty(updateProfileDto.NewPassword))
            {
                var result=await identityUserAppService.UpdatePassword(identityid,updateProfileDto.CurrentPassword!,updateProfileDto.NewPassword);
                if(!result.IsSuccess)
                {
                    return ResultDto<bool>.Failure(result.Message!);
                }
            }
            return ResultDto<bool>.Success("آپدیت با موفقیت انجام شد.");
           
        }
    }
}
