using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using Store.Domain.Core.Data;
using Store.Domain.Core.Entities;
using Store.Infra.Db.AppDb;

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
    }
}
