using Microsoft.AspNetCore.Mvc;
using Store.Domain.Core.Contact.IAppServices;
using Store.EndPoint.MVC.Areas.Admin.Models;
using Store.EndPoint.MVC.Middlwares;

namespace Store.EndPoint.MVC.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CategoryController : Controller
    {
      
    private readonly ICategoryAppService categoryAppService;
        private readonly ILogger<CategoryController> _logger;

        public CategoryController(ICategoryAppService CategoryAppService,
            ILogger<CategoryController> logger)
        {
            categoryAppService = CategoryAppService;
            _logger = logger;
        }
        public async Task<IActionResult> Index()
        {
            var categories = await categoryAppService.GetAllCategories();
            return View(categories.Data);
        }
        [HttpPost]
        public async Task<IActionResult> Create(string title, CancellationToken cancellationToken)
        {
            var result = await categoryAppService.CreateCategory(title, cancellationToken);
            if (result.IsSuccess)
            {
                _logger.LogInformation($"information:دسته بندی جدیدی به فروشگاه اضافه شد.");
                return RedirectToAction("Index");
            }
            else
            {
                ModelState.AddModelError("", result.Message!);
                var categories = await categoryAppService.GetAllCategories();
                return View("Index", categories.Data);
            }
        }
        public async Task<IActionResult> Delete(int id, CancellationToken cancellationToken)
        {
            var result = await categoryAppService.DeleteCategory(id, cancellationToken);
            if (result.IsSuccess)
            {
                _logger.LogInformation($"information:دسته بندی با آیدی {id} با موفقیت حذف شد.");
                return RedirectToAction("Index");
            }
            else
            {
                ModelState.AddModelError("", result.Message!);
                var categories = await categoryAppService.GetAllCategories();
                return View("Index", categories.Data);
            }
        }
        public async Task<IActionResult> Update(int id)
        {
            var result = await categoryAppService.GetCategoryById(id);
            if (result.IsSuccess)
            {
                var view = new CategoryViewModel
                {
                    Id = result.Data.Id,
                    Title = result.Data.Title,
                };
                return View(view);
            }
            else
            {
                ModelState.AddModelError("", result.Message!);
                var categories = await categoryAppService.GetAllCategories();
                return View("Index", categories.Data);
            }
        }
        [HttpPost]
        public async Task<IActionResult> Update(CategoryViewModel categoryViewModel)
        {
            var success = await categoryAppService.UpdateTitle(categoryViewModel.Id, categoryViewModel.Title);
            if (success.IsSuccess)
            {
                _logger.LogInformation($"information:دسته بندی با آیدی {categoryViewModel.Id} با موفقیت آپدیت شد.");
                return RedirectToAction("Index");
            }
            else
            {
                ModelState.AddModelError("", success.Message!);
                return View(categoryViewModel);
            }

        }
    }
}
