using System.ComponentModel.DataAnnotations;

namespace Store.EndPoint.MVC.Models
{
    public class LoginViewModel
    {
        [MinLength(5, ErrorMessage = "حداقل طول یوزرنیم باید 5 کاراکتر باشد.")]
        public string UserName { get; set; }
        [MinLength(5, ErrorMessage = "حداقل طول پسوورد باید 5 کاراکتر باشد.")]
        public string Password { get; set; }
        public bool RememberMe { get; set; }
    }
}
