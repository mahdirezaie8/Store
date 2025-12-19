using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Store.Domain.Core.Contact.IAppServices;
using System.Threading.Tasks;

namespace Store.EndPoint.MVC.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class OrderController : Controller
    {
        private readonly IOrderAppService orderAppService;

        public OrderController(IOrderAppService OrderAppService)
        {
            orderAppService = OrderAppService;
        }
        public async Task<IActionResult> Index(CancellationToken cancellationToken)
        {
            var orders =await orderAppService.GetAllOrder(cancellationToken);
            return View(orders.Data);
        }
        public async Task<IActionResult> Detail(int id,CancellationToken cancellationToken)
        {
            var orderitems=await orderAppService.GetOrderItemByOrderId(id,cancellationToken);
            return View(orderitems.Data);
        }
    }
}
