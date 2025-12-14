using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.Extensions.Logging;
using Store.Domain.Core.Contact.IServices;
using Store.Domain.Core.Data;
using Store.Domain.Core.Dtos;
using Store.Domain.Core.Dtos.CartPageDtos;
using Store.Domain.Core.Dtos.OrderDtos;
using Store.Domain.Core.Entities;

namespace Store.Domain.Services
{
    public class OrderService: IOrderService
    {
        private readonly IOrderRepository _orderRepository;

        public OrderService(IOrderRepository OrderRepository)
        {
            _orderRepository = OrderRepository;
        }
        public async Task<ResultDto<bool>> CreateOrder(CartDto cart, int userId)
        {
            if (cart.TotalPrice == 0)
            {
                return ResultDto<bool>.Failure("اطلاعات نادرست است.");
            }
            else
            {
                var newOrder = new Order
                {
                    UserId = userId,
                    TotalPrice = cart.TotalPrice,
                    OrderDate = DateTime.Now,
                    OrderItems = cart.CartItemDtos.Select(o => new OrderItem
                    {
                        ProductId = o.ProductId,
                        UnitPrice = o.UnitPrice,
                        Quantity = o.Quantity
                    }).ToList()
                };

                var newId = await _orderRepository.Create(newOrder);
                return ResultDto<bool>.Success("سفارش با موفقیت ثبت شد.");
            }
        }
        public async Task<IDbContextTransaction> BeginTransaction()
        {
           return await _orderRepository.BeginTransaction();
        }
        public async Task<ResultDto<List<ShowOrderDto>>> GetAllOrder(CancellationToken cancellationToken)
        {
            var orders=await _orderRepository.GetAllOrder(cancellationToken);
            if (orders.Count > 0)
            {
                return ResultDto<List<ShowOrderDto>>.Success("success", orders);
            }
            else
                return ResultDto<List<ShowOrderDto>>.Failure("سفارشی ثبت نشده است.");
        }
        public async Task<ResultDto<List<ShowOrderItemDto>>> GetOrderItemByOrderId(int orderId, CancellationToken cancellationToken)
        {
            var orderitems=await _orderRepository.GetOrderItemByOrderId(orderId, cancellationToken) ;
            if (orderitems.Count > 0)
            {
                return ResultDto<List<ShowOrderItemDto>>.Success("success", orderitems);
            }
            else
                return ResultDto<List<ShowOrderItemDto>>.Failure("سفارشی ثبت نشده است.");
        }
    }
}
