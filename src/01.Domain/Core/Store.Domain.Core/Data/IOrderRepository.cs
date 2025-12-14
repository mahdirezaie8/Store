using Microsoft.EntityFrameworkCore.Storage;
using Store.Domain.Core.Dtos.OrderDtos;
using Store.Domain.Core.Entities;
using System;

namespace Store.Domain.Core.Data
{
    public interface IOrderRepository
    {
        public Task<int> Create(Order order);
        public Task<IDbContextTransaction> BeginTransaction();
        public Task<List<ShowOrderDto>> GetAllOrder(CancellationToken cancellationToken);
        public Task<List<ShowOrderItemDto>> GetOrderItemByOrderId(int orderId, CancellationToken cancellationToken);
    }
}
