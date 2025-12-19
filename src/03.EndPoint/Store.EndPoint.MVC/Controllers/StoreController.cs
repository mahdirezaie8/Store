using Microsoft.AspNetCore.Mvc;
using Store.Domain.Core.Contact.IAppServices;
using Store.EndPoint.MVC.Extention;
using Store.EndPoint.MVC.Models;
using System.Threading.Tasks;

namespace Store.EndPoint.MVC.Controllers
{
    public class StoreController : Controller
    {
        private readonly IProductAppService productAppService;
        private readonly ICategoryAppService categoryAppService;

        public StoreController(IProductAppService ProductAppService
            ,ICategoryAppService CategoryAppService)
        {
            productAppService = ProductAppService;
            categoryAppService = CategoryAppService;
        }
        public async Task<IActionResult> Index()
        {
            ViewBag.IsLogin= User.UserIsLoggedIn();
            var products =await productAppService.GetAllProduct();
            var categories =await categoryAppService.GetAllCategories();
            ViewBag.Categories = categories.Data;
            if (products.IsSuccess)
            {
                var viewmodel = new List<ProductViewModel>();
                foreach (var product in products.Data)
                {
                    var view = new ProductViewModel
                    {
                        Id = product.Id,
                        Name = product.Name,
                        Price = product.Price,
                        Image = product.Image,
                    };
                    viewmodel.Add(view);
                }
                return View(viewmodel);
            }
            return View();
        }
        public async Task<IActionResult> CategoryIndex(int id)
        {
            ViewBag.IsLogin = User.UserIsLoggedIn();
            var products =await productAppService.GetProductsByCategoryID(id);
            if (products.IsSuccess)
            {
                var viewmodel = new List<ProductViewModel>();
                foreach (var product in products.Data)
                {
                    var view = new ProductViewModel
                    {
                        Id= product.Id,
                        Name = product.Name,
                        Price = product.Price,
                        Image = product.Image,
                    };
                    viewmodel.Add(view);
                }
                return View(viewmodel);
            }
            return View();
        }
        public async Task<IActionResult> Detail(int id)
        {
            var product=await productAppService.GetProductDetail(id);
            if (product.IsSuccess)
            {
                return View(product.Data);
            }
            return View();
        }
    }
}
