using Microsoft.EntityFrameworkCore.Storage;
using Store.Domain.Core.Data;
using Store.Domain.Core.Dtos;
using Store.Domain.Core.Dtos.CartPageDtos;
using Store.Domain.Core.Dtos.OrderDtos;
namespace Store.Domain.Core.Contact.IServices
{
    public interface IOrderService
    {
        public Task<ResultDto<bool>> CreateOrder(CartDto cart, int userId);
        public Task<IDbContextTransaction> BeginTransaction();
        public Task<ResultDto<List<ShowOrderDto>>> GetAllOrder(CancellationToken cancellationToken);
        public Task<ResultDto<List<ShowOrderItemDto>>> GetOrderItemByOrderId(int orderId, CancellationToken cancellationToken);
    }
}
