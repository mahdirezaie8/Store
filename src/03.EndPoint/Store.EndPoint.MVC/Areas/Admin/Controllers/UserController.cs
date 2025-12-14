using Microsoft.AspNetCore.Mvc;
using Store.Domain.Core.Contact.IAppServices;
using Store.EndPoint.MVC.Middlwares;

namespace Store.EndPoint.MVC.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class UserController : Controller
    {
        private readonly IUserAppService userAppService;
        private readonly ILogger<UserController> _logger;

        public UserController(IUserAppService UserAppService,
            ILogger<UserController> logger)
        {
            userAppService = UserAppService;
            _logger = logger;
        }
        public async Task<IActionResult> Index(CancellationToken cancellationToken)
        {
            var users = await userAppService.GetAllUser(cancellationToken);
            return View(users.Data);
        }
        public async Task<IActionResult> Delete(int id,CancellationToken cancellationToken)
        {
            var result = await userAppService.DeleteUser(id, cancellationToken);
            if (result.IsSuccess)
            {
                _logger.LogInformation($"information:یوزر آیدی {id} با موفقیت حذف شد.");
                return RedirectToAction("Index");
            }
            else
            {
                TempData["Error"]=result.Message;
                return RedirectToAction("Index");
            }
        }
        public async Task<IActionResult> ToggleActive(int id,CancellationToken cancellationToken)
        {
            var result=await userAppService.UpdateUserIsActive(id,cancellationToken);
            if (result.IsSuccess)
            {
                _logger.LogInformation($"information:یوزر آیدی {id} با موفقیت آپدیت شد.");
                return RedirectToAction("Index");
            }
            else
            {
                TempData["Error"] = result.Message;
                return RedirectToAction("Index");
            }
        }
    }
}
