using Microsoft.AspNetCore.Identity;
using Store.Domain.Core.Contact.IServices;
using Store.Domain.Core.Data;
using Store.Domain.Core.Dtos;
using Store.Domain.Core.Dtos.UserDtos;
using Store.Domain.Core.Entities;

namespace Store.Domain.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly SignInManager<IdentityUser<int>> _signInManager;
        private readonly UserManager<IdentityUser<int>> _userManager;

        public UserService(IUserRepository UserRepository,
            SignInManager<IdentityUser<int>> signInManager,
        UserManager<IdentityUser<int>> userManager)
        {
            _userRepository = UserRepository;
            _signInManager=signInManager;
            _userManager=userManager;   
        }
        public async Task<ResultDto<bool>> Login(string username, string password)
        {
            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                return ResultDto<bool>.Failure("لطفا فیلدها را پر کنید.");
            }
            else
            {
                var login = await _signInManager.PasswordSignInAsync(username, password, false, false);
                if (login.Succeeded)
                {
                    var isactive =await _userRepository.IsActive(username);
                    if (isactive)
                    {
                        return ResultDto<bool>.Success("لاگین با موفقیت انجام شد.");
                    }
                    else
                        return ResultDto<bool>.Failure("یوزر غیر فعال است.");
                }
                else
                {
                    return ResultDto<bool>.Failure("نام کاربری یا رمز عبور اشتباه میباشد.");
                }
            }
        }

        public async Task<ResultDto<decimal>> GetWalletAmount(int userId)
        {
            var existUser = await _userRepository.ExistUser(userId);
            if (!existUser)
            {
                return ResultDto<decimal>.Failure("یوزر پیدا نشد.");
            }
            else
            {
                var amount = await _userRepository.GetWalletAmount(userId);
                return ResultDto<decimal>.Success("success", amount);
            }
        }

        public async Task<ResultDto<bool>> UpdateWallet(int userId, decimal amount)
        {
            var existUser = await _userRepository.ExistUser(userId);
            if (!existUser)
            {
                return ResultDto<bool>.Failure("یوزر پیدا نشد.");
            }
            else
            {
                await _userRepository.UpdateWallet(userId, amount);
                return ResultDto<bool>.Success("success");
            }
        }
        public async Task<ResultDto<List<ShowUserDto>>> GetAllUser(CancellationToken cancellationToken)
        {
            var users = await _userRepository.GetAllUser(cancellationToken);
            if (users.Count > 0)
            {
                return ResultDto<List<ShowUserDto>>.Success("success", users);
            }
            else
                return ResultDto<List<ShowUserDto>>.Failure("یوزری پیدا نشد.");
        }
        public async Task<ResultDto<bool>> DeleteUser(int userId, CancellationToken cancellationToken)
        {
            var exist = await _userRepository.ExistUser(userId);
            if (exist)
            {
                var success = await _userRepository.DeleteUser(userId, cancellationToken);
                if (success)
                {
                    return ResultDto<bool>.Success("success");
                }
                else
                    return ResultDto<bool>.Failure("خطایی رخ داده.");
            }
            else
                return ResultDto<bool>.Failure("یوزر پیدا نشد.");
        }
        public async Task<ResultDto<bool>> UpdateUserIsActive(int userId, CancellationToken cancellationToken)
        {
            var exist = await _userRepository.ExistUser(userId);
            if (exist)
            {
                var active = await _userRepository.GetIsActiveUser(userId);
                bool isactive = true;
                if (active)
                {
                    isactive = false;
                }
                var success = await _userRepository.UpdateUserIsActive(userId, isactive, cancellationToken);
                if (success)
                {
                    return ResultDto<bool>.Success("success");
                }
                else
                    return ResultDto<bool>.Failure("خطایی رخ داده.");
            }
            else
                return ResultDto<bool>.Failure("یوزر پیدا نشد.");
        }
        public async Task<ResultDto<bool>> Register(RegisterDto register)
        {
            if (string.IsNullOrEmpty(register.Username) &&
                string.IsNullOrEmpty(register.Password) &&
                string.IsNullOrEmpty(register.FullName) &&
                string.IsNullOrEmpty(register.Email))
            {
                return ResultDto<bool>.Failure("لطفا فیلد هارو کامل پر کنید");
            }
            else
            {
                var existusername = await _userRepository.ExistUserByUsername(register.Username);
                if (existusername)
                {
                    return ResultDto<bool>.Failure("این یوزرنیم توسط شخص دیگری انتخاب شده.");
                }
                else
                {
                    var user = new IdentityUser<int>
                    {
                        UserName = register.Username,
                        //PhoneNumber = register.Mobile,
                        Email = register.Email,
                    };
                    var result = await _userManager.CreateAsync(user, register.Password);
                    if (result.Succeeded)
                    {
                        var newuser = new User
                        {
                            FullName = register.FullName,
                            IsActive = true,
                            Wallet = 0,
                            IdentityUserId = user.Id,
                        };
                        await _userManager.AddToRoleAsync(user, "NormalUser");
                        var id = await _userRepository.Add(newuser);
                        return ResultDto<bool>.Success("ثبت نام با موفقیت انجام شد.");
                    }
                    else
                        return ResultDto<bool>.Failure(result.Errors.First().Description);
                }
            }
        }
        public async Task<ResultDto<UserProfile>> GetUserProfile(int userId)
        {
            var exist=await _userRepository.ExistUser(userId);
            if (exist)
            {
                var user = await _userRepository.GetUserProfile(userId);
                return ResultDto<UserProfile>.Success("success", user);
            }
            else
                return ResultDto<UserProfile>.Failure("یوزر پیدا نشد.");
        }
        public async Task<ResultDto<bool>> UpdateFullName(int userid, string fullName)
        {
            var result= await _userRepository.UpdateFullName(userid, fullName);
            if (result)
            {
                return ResultDto<bool>.Success("success");
            }
            else
                return ResultDto<bool>.Failure("یوزر پیدا نشد");
        }
        public async Task<int> GetIdentityUserId(int userid)
        {
            return await _userRepository.GetIdentityUserId(userid);
        }
    }
}
