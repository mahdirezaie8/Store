using Store.Domain.Core.Dtos;
using Store.Domain.Core.Dtos.CartPageDtos;

namespace Store.Domain.Core.Contact.IAppServices
{
    public interface IOrderAppService
    {
        public Task<ResultDto<bool>> CreateOrder(CartDto cart, int Userid, bool IsLogin);
    }
}
