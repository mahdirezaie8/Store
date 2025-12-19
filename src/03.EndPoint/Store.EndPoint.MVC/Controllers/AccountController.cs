using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Store.Domain.Core.Contact.IAppServices;
using Store.Domain.Core.Dtos.UserDtos;
using Store.Domain.Core.Entities;
using Store.Domain.Core.Enums;
using Store.EndPoint.MVC.Extention;
using Store.EndPoint.MVC.Models;
using System.Threading.Tasks;

namespace Store.EndPoint.MVC.Controllers
{
    public class AccountController : Controller
    {
        private readonly IUserAppService userAppService;
        private readonly ILogger<AccountController> _logger;
        private readonly SignInManager<IdentityUser<int>> _signInManager;
        private readonly UserManager<IdentityUser<int>> _userManager;

        public AccountController(IUserAppService UserAppService,
            ILogger<AccountController> logger,
            SignInManager<IdentityUser<int>> signInManager,
            UserManager<IdentityUser<int>> userManager)
        {
            userAppService = UserAppService;
            _logger = logger;
            _signInManager = signInManager;
            _userManager = userManager;
        }
        public IActionResult Login()
        {
            if (User.UserIsLoggedIn())
            {
                var isAdmin = User.IsAdmin();
                if (isAdmin)
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
            var success = await userAppService.Login(loginViewModel.UserName, loginViewModel.Password);
            if (success.IsSuccess)
            {
                var username = User.GetUserName;
                var role = User.GetUserRole();
                _logger.LogInformation($"information :یوزرنیم {username}با نقش {role}وارد شد.");
                if (User.IsAdmin())
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
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index", "Store");
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
            var register = await userAppService.Register(newdto);
            if (register.IsSuccess)
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
        public async Task<IActionResult> Profile()
        {
            var islodin = User.UserIsLoggedIn();
            if (islodin)
            {
                var userid=User.GetUserId()??0;
                var user =await userAppService.GetUserProfile(userid);
                var view = new UpdateProfileViewModel
                {
                    UserId = user.Data.Id,
                    FullName = user.Data.FullName,
                    Wallet = user.Data.Wallet,
                    UserName = user.Data.Username,
                    Email = user.Data.Email,
                };

                return View(view);
            }
            else
            {
                return RedirectToAction("Login");
            }
        }
        public async Task<IActionResult> UpdateProfile(int id)
        {
            var user = await userAppService.GetUserProfile(id);
            var view = new UpdateProfileViewModel
            {
                UserId = user.Data.Id,
                FullName = user.Data.FullName,
                Wallet = user.Data.Wallet,
                UserName = user.Data.Username,
                Email = user.Data.Email,
                ConfirmNewPassword = "",
                CurrentPassword = "",
                NewPassword = "",
            };

            return View(view);
        }
        [HttpPost]
        public async Task<IActionResult> UpdateProfile(UpdateProfileViewModel updateProfileViewModel)
        {
            if(!ModelState.IsValid)
            {
                return View(updateProfileViewModel);
            }
            else
            {
                var dto = new UpdateProfileDto()
                {
                    UserId=updateProfileViewModel.UserId,
                    CurrentPassword=updateProfileViewModel.CurrentPassword,
                    NewPassword=updateProfileViewModel.NewPassword,
                    Username=updateProfileViewModel.UserName,
                    Email=updateProfileViewModel.Email,
                    FullName=updateProfileViewModel.FullName,
                };
                var result =await userAppService.UpdateProfileUser(dto);
                if (result.IsSuccess)
                {
                    return RedirectToAction("Profile");
                }
                else
                {
                    ModelState.AddModelError("", result.Message!);
                    return View(result.Data);
                }
            }
        }
    }
}

