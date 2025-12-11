using Microsoft.AspNetCore.Mvc;
using Store.Domain.Core.Contact.IAppServices;
using Store.EndPoint.MVC.Extention;
using Store.EndPoint.MVC.Models;
using Store.EndPoint.MVC.Session;

namespace Store.EndPoint.MVC.Controllers
{
    public class AccountController : Controller
    {
        private readonly IUserAppService userAppService;
        private readonly ICookieService cookieService;
        private readonly ISessionCart sessionCart;

        public AccountController(IUserAppService UserAppService,ICookieService CookieService, ISessionCart SessionCart)
        {
            userAppService = UserAppService;
            cookieService = CookieService;
            sessionCart = SessionCart;
        }
        public IActionResult Login()
        {
            if (cookieService.UserIsLoggedIn())
            {
                return RedirectToAction("Index", "Store");
            }
            else
                return View();
        }
        [ValidateAntiForgeryToken]
        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel loginViewModel)
        {
            var success=await userAppService.Login(loginViewModel.UserName, loginViewModel.Password);
            if (success.IsSuccess)
            {
                cookieService.Set("Id", success.Data.Id.ToString());
                cookieService.Set("Username", success.Data.Username);
                return RedirectToAction("Index","Store");
            }
            else
            {
                ModelState.AddModelError("", success.Message!);
                return View();
            }
        }
        public IActionResult Logout()
        {
            cookieService.Delete("Id");
            cookieService.Delete("Username");
            sessionCart.Clear();
            return RedirectToAction("Index","Store");
        }
    }
}
