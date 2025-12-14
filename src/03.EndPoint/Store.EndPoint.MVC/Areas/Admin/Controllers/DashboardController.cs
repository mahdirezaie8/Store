using Microsoft.AspNetCore.Mvc;
using Store.EndPoint.MVC.Extention;
using Store.EndPoint.MVC.Session;

namespace Store.EndPoint.MVC.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class DashboardController : Controller
    {
        private readonly ICookieService cookieService;

        public DashboardController(ICookieService CookieService)
        {
            cookieService = CookieService;
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Logout()
        {
            cookieService.Delete("Id");
            cookieService.Delete("Username");
            cookieService.Delete("Role");
            return RedirectToAction("Index", "Login");
        }
    }
}
