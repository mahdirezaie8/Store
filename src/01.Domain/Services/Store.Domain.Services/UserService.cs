using Store.Domain.Core.Contact.IServices;
using Store.Domain.Core.Data;
using Store.Domain.Core.Dtos;
using Store.Domain.Core.Dtos.UserDtos;

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
                    return ResultDto<UserDto>.Success("لاگین با موفقیت انجام شد.", user);
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

    }
}
