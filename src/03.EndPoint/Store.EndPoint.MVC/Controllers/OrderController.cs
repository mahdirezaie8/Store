using Microsoft.AspNetCore.Mvc;
using Store.Domain.Core.Contact.IAppServices;
using Store.Domain.Core.Dtos.CartPageDtos;
using Store.Domain.Core.Entities;
using Store.EndPoint.MVC.Extention;
using Store.EndPoint.MVC.Models;
using Store.EndPoint.MVC.Session;
using System.Threading.Tasks;

namespace Store.EndPoint.MVC.Controllers
{
    public class OrderController : Controller
    {
        private readonly ISessionCart session;
        private readonly IProductAppService productAppService;
        private readonly ICookieService cookieService;
        private readonly IUserAppService userAppService;
        private readonly IOrderAppService orderAppService;

        public OrderController(ISessionCart Session
            , IProductAppService ProductAppService
            , ICookieService CookieService
            , IUserAppService UserAppService
            , IOrderAppService orderAppService)
        {
            session = Session;
            productAppService = ProductAppService;
            cookieService = CookieService;
            userAppService = UserAppService;
            this.orderAppService = orderAppService;
        }
        public IActionResult Index()
        {
            var cart = session.GetCart();
            @ViewBag.Total = cart.TotalPrice;
            if (cart.CartItemDtos.Count() > 0)
            {
                var newviewmodels = new List<CartItemViewModel>();
                foreach (var item in cart.CartItemDtos)
                {
                    var newmodel = new CartItemViewModel
                    {
                        Image = item.Image,
                        ProductId = item.ProductId,
                        ProductName = item.ProductName,
                        UnitPrice = item.UnitPrice,
                        Quantity = item.Quantity,
                        Totalprice = item.Totalprice,
                    };
                    newviewmodels.Add(newmodel);
                }
                return View(newviewmodels);
            }
            return View();
        }
        public async Task<IActionResult> AddProduct(int productId, int quantity)
        {
            var product =await productAppService.GetProductById(productId);
            if (product.IsSuccess)
            { 
                var newcart = new CartItemDto
                {
                    Image = product.Data.Image,
                    ProductId = productId,
                    ProductName = product.Data.Name,
                    UnitPrice = product.Data.Price,
                    Quantity = quantity,
                };
              var result= await session.Add(newcart);
                if (result.IsSuccess)
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    TempData["Error"] = result.Message;
                    return RedirectToAction("Detail", "Store", new { id = productId});
                }
            }
            else
            {
                TempData["Error"] = product.Message;
                return RedirectToAction("Index", "Store");
            }
        }
        public IActionResult Update(int productId, int quantity)
        {
            var success = session.UpdadeQuntity(productId, quantity);
            if (!success.IsSuccess)
            {
                TempData["Error"] = success.Message;
            }

            return RedirectToAction("Index");
        }
        public IActionResult Delete(int productId)
        {
            session.Remove(productId);
            return RedirectToAction("Index");
        }
        [HttpPost]
        public async Task<IActionResult> Checkout()
        {
            var cart = session.GetCart();
            var login = cookieService.UserIsLoggedIn();
            int Userid=cookieService.GetUserId();
            var checkout =await orderAppService.CreateOrder(cart, Userid, login);
            if(checkout.IsSuccess)
            {
                session.Clear();
                return RedirectToAction("Index", "Store");
            }
            else
            {
                TempData["Error"]=checkout.Message;
                return RedirectToAction("Index"); 
            }
        }
    }
}
