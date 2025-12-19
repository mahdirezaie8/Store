using Microsoft.AspNetCore.Identity;
using Store.Domain.Core.Contact.IServices;
using Store.Domain.Core.Dtos;

namespace Store.Domain.Services
{
    public class IdentityUserservice: IIdentityUserservice
    {
        private readonly UserManager<IdentityUser<int>> _userManager;

        public IdentityUserservice(UserManager<IdentityUser<int>> userManager)
        {
            _userManager = userManager;
        }
        private async Task<ResultDto<IdentityUser<int>>> GetIdentity(int IdentityUserId)
        {
            var identityuser=await _userManager.FindByIdAsync(IdentityUserId.ToString());
            if (identityuser != null)
            {
                return ResultDto<IdentityUser<int>>.Success("success",identityuser);
            }
            else
                return ResultDto<IdentityUser<int>>.Failure("آیدنتیتی پیدا نشد.");
        }
        public async Task<ResultDto<bool>> UpdateIdentity(int identityId,string Username,string email)
        {
            var identityUser=await GetIdentity(identityId);
            if(identityUser.IsSuccess)
            {
                if(Username!=null)
                {
                    identityUser.Data!.UserName = Username;
                }
                if(email!=null)
                {
                    identityUser.Data!.Email = email;
                }
              var result= await _userManager.UpdateAsync(identityUser.Data!);
                if (result.Succeeded)
                {
                    return ResultDto<bool>.Success("success");
                }
                else
                    return ResultDto<bool>.Failure(result.Errors.First().Description);
            }
            else
                return ResultDto<bool>.Failure(identityUser.Message!);
        }
        public async Task<ResultDto<bool>> UpdatePassword(int identityId,string oldpass,string newpass)
        {
            var identityUser = await GetIdentity(identityId);
            if (identityUser.IsSuccess)
            {
                var result= await _userManager.ChangePasswordAsync(identityUser.Data!,oldpass,newpass);
                if (result.Succeeded)
                {
                    return ResultDto<bool>.Success("تغییر پسوورد با موفقیت اندام شد.");
                }
                else
                    return ResultDto<bool>.Failure(result.Errors.First().Description);
            }
            else
                return ResultDto<bool>.Failure(identityUser.Message!);
        }
    }
}
