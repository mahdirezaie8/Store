using Store.Domain.Core.Dtos;
using Store.Domain.Core.Dtos.CartPageDtos;
using Store.Domain.Core.Dtos.OrderDtos;

namespace Store.Domain.Core.Contact.IAppServices
{
    public interface IOrderAppService
    {
        public Task<ResultDto<bool>> CreateOrder(CartDto cart, int Userid, bool IsLogin);
        public Task<ResultDto<List<ShowOrderDto>>> GetAllOrder(CancellationToken cancellationToken);
        public Task<ResultDto<List<ShowOrderItemDto>>> GetOrderItemByOrderId(int orderId, CancellationToken cancellationToken);
    }
}
