using Microsoft.AspNetCore.Mvc;
using Store.Domain.Core.Contact.IAppServices;
using Store.EndPoint.MVC.Models;

namespace Store.EndPoint.MVC.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ICategoryAppService categoryAppService;

        public CategoryController(ICategoryAppService CategoryAppService)
        {
            categoryAppService = CategoryAppService;
        }
        public async Task<IActionResult> Index()
        {
            var categories=await categoryAppService.GetAllCategories();
            return View(categories.Data);
        }
        [HttpPost]
        public async Task<IActionResult> Create(string title, CancellationToken cancellationToken)
        {
            var result=await categoryAppService.CreateCategory(title,cancellationToken);
            if (result.IsSuccess)
            {
                return RedirectToAction("Index");
            }
            else
            {
                ModelState.AddModelError("", result.Message!);
                var categories = await categoryAppService.GetAllCategories();
                return View("Index",categories.Data);
            }
        }
        public async Task<IActionResult> Delete(int id,CancellationToken cancellationToken)
        {
            var result = await categoryAppService.DeleteCategory(id,cancellationToken);
            if (result.IsSuccess)
            {
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
            var result=await categoryAppService.GetCategoryById(id);
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
