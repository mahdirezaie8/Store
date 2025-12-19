using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using Store.Domain.Core.Data;
using Store.Domain.Core.Dtos.OrderDtos;
using Store.Domain.Core.Entities;
using Store.Infra.Db.AppDb;
using System.Threading.Tasks;

namespace Store.Infra.DA.Repositories
{
    public class OrderRepository: IOrderRepository
    {
        private readonly AppDbContext appDbContext;

        public OrderRepository(AppDbContext AppDbContext)
        {
            appDbContext = AppDbContext;
        }
        public async Task<int> Create(Order order)
        {
           await appDbContext.Orders.AddAsync(order);
           await appDbContext.SaveChangesAsync();
            return order.Id;
        }
        public async Task<IDbContextTransaction> BeginTransaction()
        {
           return await appDbContext.Database.BeginTransactionAsync();
        }
        public async Task<List<ShowOrderDto>> GetAllOrder(CancellationToken cancellationToken)
        {
            return await appDbContext.Orders
                .OrderByDescending(o=>o.OrderDate)
                .Select(o=>new ShowOrderDto
            {
                    Id = o.Id,
                    UserId = o.UserId,
                    TotalPrice = o.TotalPrice,
                    Email=o.User.IdentityUser.Email!,
                    FullName=o.User.FullName,
                    OrderDate = o.OrderDate,
            }).ToListAsync(cancellationToken);
        }
        public async Task<List<ShowOrderItemDto>> GetOrderItemByOrderId(int orderId,CancellationToken cancellationToken)
        {
            return await appDbContext.OrderItems.Where(o=>o.OrderId == orderId).Select(o=>new ShowOrderItemDto
            {
                OrderItemId = o.Id,
                Image =o.Product.Image,
                ProductId = o.ProductId,
                Name=o.Product.Name,
                UnitPrice=o.UnitPrice,
                Quantity= o.Quantity,
            }).ToListAsync(cancellationToken);
        }
    }
}
