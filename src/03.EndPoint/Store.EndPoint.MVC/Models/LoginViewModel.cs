using System.ComponentModel.DataAnnotations;

namespace Store.EndPoint.MVC.Models
{
    public class LoginViewModel
    {
        [MinLength(7, ErrorMessage = "حداقل طول یوزرنیم باید ۷ کاراکتر باشد.")]
        public string UserName { get; set; }
        [MinLength(7, ErrorMessage = "حداقل طول پسوورد باید ۷ کاراکتر باشد.")]
        public string Password { get; set; }
    }
}
