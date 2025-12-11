using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Store.Domain.Core.Dtos;
using Store.Domain.Core.Dtos.CartPageDtos;

namespace Store.EndPoint.MVC.Session
{
    public interface ISessionCart
    {
        public CartDto GetCart();
        public void SaveCart(CartDto cart);
        public Task<ResultDto<bool>> Add(CartItemDto cartItemDto);
        public ResultDto<bool> Remove(int productid);
        public void Clear();
        public ResultDto<bool> UpdadeQuntity(int productid, int quantity);
    }
}
