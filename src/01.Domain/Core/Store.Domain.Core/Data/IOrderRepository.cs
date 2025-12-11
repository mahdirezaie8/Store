using Microsoft.EntityFrameworkCore.Storage;
using Store.Domain.Core.Entities;

namespace Store.Domain.Core.Data
{
    public interface IOrderRepository
    {
        public Task<int> Create(Order order);
        public Task<IDbContextTransaction> BeginTransaction();
    }
}
