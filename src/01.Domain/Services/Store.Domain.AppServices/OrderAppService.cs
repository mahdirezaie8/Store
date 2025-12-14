using Store.Domain.Core.Contact.IAppServices;
using Store.Domain.Core.Contact.IServices;
using Store.Domain.Core.Dtos;
using Store.Domain.Core.Dtos.CartPageDtos;
using Store.Domain.Core.Entities;
using System.Data.Common;
using System.Threading.Tasks;
using System.Transactions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using Store.Domain.Core.Dtos.OrderDtos;

namespace Store.Domain.AppServices
{
    public class OrderAppService: IOrderAppService
    {
        private readonly IOrderService orderService;
        private readonly IProductAppService productAppService;
        private readonly IUserAppService userAppService;

        public OrderAppService(IOrderService OrderService
            ,IProductAppService ProductAppService,IUserAppService UserAppService)
        {
            orderService = OrderService;
            productAppService = ProductAppService;
            userAppService = UserAppService;
        }
        public async Task<ResultDto<bool>> CreateOrder(CartDto cart, int Userid,bool IsLogin)
        {
            if (cart.CartItemDtos.Count() > 0)
            {
                var login = IsLogin;
                if (login)
                {
                    using var transaction =await orderService.BeginTransaction();
                    try
                    {
                        foreach (var item in cart.CartItemDtos)
                        {
                            var productid = item.ProductId;
                            var count = item.Quantity;
                            var productname = item.ProductName;
                            var result = await productAppService.CheckCount(count,productid, productname);
                            if (!result.IsSuccess)
                            {
                                var message = result.Message;
                                return ResultDto<bool>.Failure(message!);
                            }

                        }
                        var success = await userAppService.UpdateUserWallet(Userid, cart.TotalPrice);
                        if (success.IsSuccess)
                        {

                            var neworder = await orderService.CreateOrder(cart, Userid);
                            if (neworder.IsSuccess)
                            {
                               await productAppService.UpdateCount(cart);
                                await transaction.CommitAsync();
                                return ResultDto<bool>.Success("عملیات با موفقیت انجام شد.");
                            }
                            else
                            {
                                await transaction.RollbackAsync();
                                var message = neworder.Message;
                                return ResultDto<bool>.Failure(message!);
                            }
                        }
                        else
                        {
                            await transaction.RollbackAsync();
                            var message = success.Message;
                            return ResultDto<bool>.Failure(message!);
                        }
                        
                    }
                    catch (Exception)
                    {
                        await transaction.RollbackAsync();
                        return ResultDto<bool>.Failure("خطای غیرمنتظره! مبلغ برگشت داده شد.");
                    }
                }
                else
                {
                    return ResultDto<bool>.Failure("برای ثبت خرید باید لاگین کنید");
                }
            }
            else
            {
                return ResultDto<bool>.Failure("محصولی برای ثبت ندارید");
            }
        }

        public async Task<ResultDto<List<ShowOrderDto>>> GetAllOrder(CancellationToken cancellationToken)
        {
            return await orderService.GetAllOrder(cancellationToken);
        }

        public async Task<ResultDto<List<ShowOrderItemDto>>> GetOrderItemByOrderId(int orderId, CancellationToken cancellationToken)
        {
            return await orderService.GetOrderItemByOrderId(orderId, cancellationToken);
        }
    }
}
