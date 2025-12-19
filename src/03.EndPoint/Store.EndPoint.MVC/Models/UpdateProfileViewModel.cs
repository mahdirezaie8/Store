using System.ComponentModel.DataAnnotations;

namespace Store.EndPoint.MVC.Models
{
    public class UpdateProfileViewModel
    {
        public int UserId { get; set; }

        [Display(Name = "نام و نام خانوادگی")]
        [MinLength(5, ErrorMessage = "حداقل طول پسوورد باید 5 کاراکتر باشد.")]
        [MaxLength(250, ErrorMessage = "حداکثر 250 کاراکتر باشد")]
        public string? FullName { get; set; }


        [Display(Name = "یوزرنیم")]
        [MinLength(5, ErrorMessage = "حداقل طول پسوورد باید 5 کاراکتر باشد.")]
        public string? UserName { get; set; }

        [Display(Name = "ایمیل")]
        [EmailAddress(ErrorMessage = "فرمت ایمیل صحیح نیست")]
        public string? Email { get; set; }


        [MinLength(5, ErrorMessage = "حداقل طول پسوورد باید 5 کاراکتر باشد.")]
        [MaxLength(250, ErrorMessage = "حداکثر 250 کاراکتر باشد")]
        [DataType(DataType.Password)]
        [Display(Name = "رمز عبور")]
        public string? CurrentPassword { get; set; }


        [MinLength(5, ErrorMessage = "حداقل طول پسوورد باید 5 کاراکتر باشد.")]
        [MaxLength(250, ErrorMessage = "حداکثر 250 کاراکتر باشد")]
        [DataType(DataType.Password)]
        [Display(Name = "رمز عبور جدید")]
        public string? NewPassword { get; set; }


        [Compare("NewPassword", ErrorMessage = "رمز عبور و تکرار آن یکسان نیست")]
        [DataType(DataType.Password)]
        [Display(Name = "تکرار رمز عبور جدید")]
        public string? ConfirmNewPassword { get; set; }
        public decimal? Wallet { get; set; } 
    }
}
