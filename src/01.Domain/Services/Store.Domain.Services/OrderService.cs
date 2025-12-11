using Microsoft.EntityFrameworkCore.Storage;
using Store.Domain.Core.Contact.IServices;
using Store.Domain.Core.Data;
using Store.Domain.Core.Dtos;
using Store.Domain.Core.Dtos.CartPageDtos;
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

    }
}
