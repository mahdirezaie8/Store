using Microsoft.EntityFrameworkCore.Storage;
using Store.Domain.Core.Dtos;
using Store.Domain.Core.Dtos.CartPageDtos;
namespace Store.Domain.Core.Contact.IServices
{
    public interface IOrderService
    {
        public Task<ResultDto<bool>> CreateOrder(CartDto cart, int userId);
        public Task<IDbContextTransaction> BeginTransaction();
    }
}
