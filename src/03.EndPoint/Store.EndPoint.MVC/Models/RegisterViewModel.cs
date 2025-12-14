using System.ComponentModel.DataAnnotations;

namespace Store.EndPoint.MVC.Models
{
    public class RegisterViewModel
    {

        [Required(ErrorMessage = "نام و نام خانوادگی الزامی است")]
        [Display(Name = "نام و نام خانوادگی")]
        [MaxLength(250,ErrorMessage ="حداکثر 250 کاراکتر باشد")]
        [MinLength(5,ErrorMessage ="حداقل 5 کاراکتر باشد")]
        public string FullName { get; set; }

        [Required(ErrorMessage = "نام کاربری الزامی است")]
        [Display(Name = "نام کاربری")]
        [MaxLength(250, ErrorMessage = "حداکثر 250 کاراکتر باشد")]
        [MinLength(5, ErrorMessage = "حداقل 5 کاراکتر باشد")]
        public string Username { get; set; }

        [Required(ErrorMessage = "ایمیل الزامی است")]
        [EmailAddress(ErrorMessage = "فرمت ایمیل صحیح نیست")]
        [Display(Name = "ایمیل")]
        public string Email { get; set; }

        [Required(ErrorMessage = "رمز عبور الزامی است")]
        [MinLength(5, ErrorMessage = "رمز عبور حداقل 5 کاراکتر باشد")]
        [MaxLength(250, ErrorMessage = "حداکثر 250 کاراکتر باشد")]
        [DataType(DataType.Password)]
        [Display(Name = "رمز عبور")]
        public string Password { get; set; }

        [Required(ErrorMessage = "تکرار رمز عبور الزامی است")]
        [Compare("Password", ErrorMessage = "رمز عبور و تکرار آن یکسان نیست")]
        [DataType(DataType.Password)]
        [Display(Name = "تکرار رمز عبور")]
        public string ConfirmPassword { get; set; }
    }
}
