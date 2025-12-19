using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Store.EndPoint.MVC.Extention;
using Store.EndPoint.MVC.Session;
using System.Threading.Tasks;

namespace Store.EndPoint.MVC.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class DashboardController : Controller
    {
        private readonly SignInManager<IdentityUser<int>> _signInManager;

        public DashboardController(SignInManager<IdentityUser<int>> signInManager)
        {
            _signInManager = signInManager;
        }
        public IActionResult Index()
        {
            return View();
        }
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Login", "Account", new { area = "" });
        }
    }
}
