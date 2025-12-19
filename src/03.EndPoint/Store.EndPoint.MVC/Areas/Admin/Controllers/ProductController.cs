using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Store.Domain.Core.Contact.IAppServices;
using Store.Domain.Core.Dtos.ProductDtos;
using Store.EndPoint.MVC.Areas.Admin.Models;
using Store.EndPoint.MVC.Middlwares;

namespace Store.EndPoint.MVC.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class ProductController : Controller
    {
        private readonly IProductAppService productAppService;
        private readonly ICategoryAppService categoryAppService;
        private readonly ILogger<ProductController> _logger;

        public ProductController(IProductAppService ProductAppService,
            ICategoryAppService CategoryAppService,
            ILogger<ProductController> logger)
        {
            productAppService = ProductAppService;
            categoryAppService = CategoryAppService;
            _logger = logger;
        }
        public async Task<IActionResult> Index(CancellationToken cancellationToken, int page = 1)
        {
            ViewBag.Page = page;
            int pagesize = 10;
            var total = productAppService.TotalPage(pagesize);
            ViewBag.TotalPages = total;
            var products = await productAppService.GetDetailAllProduct(cancellationToken, page, pagesize);
            return View(products.Data);
        }
        [HttpPost]
        public async Task<IActionResult> UpdateCount(int id, int count, int Page)
        {
            var update = await productAppService.UpdateProductCount(count, id);
            if (update.IsSuccess)
            {
                _logger.LogInformation($"information:تعداد محصول با آیدی {id} با موفقیت به تعداد {count} آپدیت شد.");
                return RedirectToAction("Index", new { page = Page });
            }
            else
            {
                TempData["Error"] = update.Message;
                return RedirectToAction("Index", new { page = Page });
            }
        }
        public async Task<IActionResult> Delete(int id, int Page, CancellationToken cancellationToken)
        {
            var result = await productAppService.Delete(id, cancellationToken);
            if (result.IsSuccess)
            {
                _logger.LogInformation($"information:محصول با آیدی {id} با موفقیت حذف شد.");
                return RedirectToAction("Index", new { page = Page });
            }
            else
            {
                TempData["Error"] = result.Message;
                return RedirectToAction("Index", new { page = Page });
            }
        }
        public async Task<IActionResult> Update(int id, int Page)
        {
            ViewBag.Page = Page;
            var product = await productAppService.GetProductForUpdate(id);
            if (product.IsSuccess)
            {
                return View(product.Data);
            }
            else
            {
                TempData["Error"] = product.Message;
                return RedirectToAction("Index", new { page = Page });
            }
        }
        [HttpPost]
        public async Task<IActionResult> Update(UpdateProductDto updateProductDto, int id, int Page, CancellationToken cancellationToken)
        {
            if (!ModelState.IsValid)
            {
                return View(updateProductDto);
            }
            var update = await productAppService.Updateproduct(updateProductDto, id, cancellationToken);
            if (update.IsSuccess)
            {
                _logger.LogInformation($"information:محصول با آیدی {id} با موفقیت آپدیت شد.");
                return RedirectToAction("Index", new { page = Page });
            }
            else
            {
                ModelState.AddModelError("", update.Message!);
                return View(updateProductDto);
            }
        }
        public async Task<IActionResult> Create()
        {
            var categoris = await categoryAppService.GetAllCategories();
            ViewBag.Categories = categoris.Data;
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(CreateProductViewModel createProductViewModel, CancellationToken cancellationToken)
        {
            var newDto = new CreateProductDto()
            {
                CategoryId = createProductViewModel.CategoryId,
                Count = createProductViewModel.Count,
                Description = createProductViewModel.Description,
                Name = createProductViewModel.Name,
                Price = createProductViewModel.Price,
                ProfileImage = createProductViewModel.ProfileImage,
            };
            var result = await productAppService.CreateProduct(newDto, cancellationToken);
            if (result.IsSuccess)
            {
                _logger.LogInformation($"information:محصول جدیدی با اطلاعات {createProductViewModel.Description},,,{createProductViewModel.Name}ایجاد شد.");
                return RedirectToAction("Index", new { page = 1 });
            }
            else
            {
                ModelState.AddModelError("", result.Message!);
                var categoris = await categoryAppService.GetAllCategories();
                ViewBag.Categories = categoris.Data;
                return View();
            }
        }
    }
}

