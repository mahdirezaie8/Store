using Store.Domain.Core.Contact.IServices;
using Store.Domain.Core.Data;
using Store.Domain.Core.Dtos;
using Store.Domain.Core.Dtos.UserDtos;
using Store.Domain.Core.Entities;
using Store.Domain.Core.Enums;
using System.Threading.Tasks;

namespace Store.Domain.Services
{
    public class UserService:IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository UserRepository)
        {
            _userRepository = UserRepository;
        }
        public async Task<ResultDto<UserDto>> Login(string username, string password)
        {
            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                return ResultDto<UserDto>.Failure("لطفا فیلدها را پر کنید.");
            }
            else
            {
                var user = await _userRepository.GetUser(username, password);
                if (user == null)
                {
                    return ResultDto<UserDto>.Failure("یوزر پیدا نشد.");
                }
                else
                {
                    if(user.IsActive==true)
                    {
                        return ResultDto<UserDto>.Success("لاگین با موفقیت انجام شد.", user);
                    }
                    else
                        return ResultDto<UserDto>.Failure("یوزر غیر فعال است.");
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
        public async Task<ResultDto<bool>> DeleteUser(int userId,CancellationToken cancellationToken)
        {
            var exist=await _userRepository.ExistUser(userId);
            if(exist)
            {
              var success= await _userRepository.DeleteUser(userId, cancellationToken);
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
        public async Task<ResultDto<bool>> UpdateUserIsActive(int userId,CancellationToken cancellationToken)
        {
            var exist = await _userRepository.ExistUser(userId);
            if (exist)
            {
                var active=await _userRepository.GetIsActiveUser(userId);
                bool isactive=true;
                if (active)
                {
                    isactive=false;
                }
                var success = await _userRepository.UpdateUserIsActive(userId,isactive, cancellationToken);
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
                var existusername=await _userRepository.ExistUserByUsername(register.Username);
                if (existusername)
                {
                    return ResultDto<bool>.Failure("این یوزرنیم توسط شخص دیگری انتخاب شده.");
                }
                else
                {
                    var newuser = new User
                    {
                        Username = register.Username,
                        Email = register.Email,
                        Password = register.Password,
                        FullName = register.FullName,
                        IsActive = true,
                        Wallet = 0,
                        Role = RoleEnum.NormalUser,
                    };
                  var id=await _userRepository.Add(newuser);
                    return ResultDto<bool>.Success("ثبت نام با موفقیت انجام شد.");
                }
            }
        }
    }
}
