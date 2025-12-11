using Store.Domain.Core.Contact.IAppServices;
using Store.Domain.Core.Dtos;
using Store.Domain.Core.Dtos.CartPageDtos;
using System.Threading.Tasks;

namespace Store.EndPoint.MVC.Session
{
    public class SessionCart : ISessionCart
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IProductAppService productAppService;

        private ISession session => _httpContextAccessor.HttpContext!.Session;

        public SessionCart(IHttpContextAccessor httpContextAccessor, IProductAppService ProductAppService)
        {
            _httpContextAccessor = httpContextAccessor;
            productAppService = ProductAppService;
        }
        public const string key = "Cart";
        public CartDto GetCart()
        {
            var cart = session.GetObject<CartDto>(key);
            if (cart == null)
            {
                cart = new CartDto();
                session.SetObject(key, cart);
                return cart;
            }
            else
                return cart;
        }
        public void SaveCart(CartDto cart)
        {
            session.SetObject(key, cart);
        }
        public async Task<ResultDto<bool>> Add(CartItemDto cartItemDto)
        {
            var oldcart = GetCart();
            var exiting = oldcart.CartItemDtos.FirstOrDefault(c => c.ProductId == cartItemDto.ProductId);
            var quntity = await productAppService.CountProduct(cartItemDto.ProductId);
            var exitq = exiting?.Quantity ?? 0;
            int newcount = cartItemDto.Quantity + exitq;
            if (newcount <= quntity)
            {
                if (exiting == null)
                {
                    oldcart.CartItemDtos.Add(cartItemDto);
                }
                else
                {
                    exiting.Quantity += cartItemDto.Quantity;
                    exiting.UnitPrice = cartItemDto.UnitPrice;
                }
                SaveCart(oldcart);
                return ResultDto<bool>.Success("عملیات با موفقیت انجام شد.");
            }
            else
            {
                return ResultDto<bool>.Failure("تعداد محصولات از موجودی بیشتر میشود.");
            }
        }
        public ResultDto<bool> Remove(int productid)
        {
            var oldcart = GetCart();
            var exiting = oldcart.CartItemDtos.FirstOrDefault(c => c.ProductId == productid);
            if (exiting == null)
            {
                return ResultDto<bool>.Failure("محصول پیدا نشد.");
            }
            else
            {
                oldcart.CartItemDtos.Remove(exiting);
                SaveCart(oldcart);
                return ResultDto<bool>.Success("حذف با موفقیت انجام شد");
            }
        }
        public void Clear()
        {
            session.Remove(key);
        }
        public ResultDto<bool> UpdadeQuntity(int productid, int quantity)
        {
            var cart = GetCart();
            var exiting = cart.CartItemDtos.FirstOrDefault(c => c.ProductId == productid);
            if (exiting != null)
            {
                if (quantity == 0)
                {
                    Remove(productid);
                }
                else
                {
                    exiting.Quantity = quantity;
                }
                SaveCart(cart);
                return ResultDto<bool>.Success("success");
            }
            return ResultDto<bool>.Failure("محصول یافت نشد.");
        }

    }
}
