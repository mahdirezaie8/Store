using Microsoft.AspNetCore.Mvc;
using Store.Domain.Core.Contact.IAppServices;
using Store.Domain.Core.Dtos.UserDtos;
using Store.Domain.Core.Enums;
using Store.EndPoint.MVC.Extention;
using Store.EndPoint.MVC.Models;

namespace Store.EndPoint.MVC.Controllers
{
    public class AccountController : Controller
    {
        private readonly IUserAppService userAppService;
        private readonly ICookieService cookieService;
        private readonly ILogger<AccountController> _logger;

        public AccountController(IUserAppService UserAppService,ICookieService CookieService, ILogger<AccountController> logger)
        {
            userAppService = UserAppService;
            cookieService = CookieService;
            _logger = logger;
        }
        public IActionResult Login()
        {
            if (cookieService.UserIsLoggedIn())
            {
                var isAdmin=cookieService.IsAdmin();
                if(isAdmin)
                {
                    return RedirectToAction("Index", "Dashboard", new { area = "Admin" });
                }
                else
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
                cookieService.Set("Role", success.Data.Role.ToString());
                _logger.LogInformation($"information :یوزرنیم {success.Data.Username}با نقش {success.Data.Role}وارد شد.");
                if (success.Data.Role==RoleEnum.Admin)
                {
                    return RedirectToAction("Index", "Dashboard", new { area = "Admin" });
                }
                else
                    return RedirectToAction("Index", "Store");
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
            cookieService.Delete("Role");
            return RedirectToAction("Index","Store");
        }
        public IActionResult Register()
        {
            return View(); 
        }
        [ValidateAntiForgeryToken]
        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel registerViewModel)
        {
            if (!ModelState.IsValid)
            {
                return View(registerViewModel); 
            }
            var newdto = new RegisterDto
            {
                Email = registerViewModel.Email,
                FullName = registerViewModel.FullName,
                Password = registerViewModel.Password,
                Username = registerViewModel.Username,
            };
            var register=await userAppService.Register(newdto);
            if(register.IsSuccess)
            {
                _logger.LogInformation($"information:یوزرنیم {registerViewModel.Username} با نقش نرمال یوزر ثبت نام کرد.");
                return RedirectToAction("Login");
            }
            else
            {
                ModelState.AddModelError("", register.Message!);
                return View(register); 
            }
        }
    }
}
