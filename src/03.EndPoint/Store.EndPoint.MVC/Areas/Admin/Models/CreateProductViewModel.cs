using System.ComponentModel.DataAnnotations;

namespace Store.EndPoint.MVC.Areas.Admin.Models
{
    public class CreateProductViewModel
    {
        [Required(ErrorMessage = "نام محصول الزامی است.")]
        [MinLength(3, ErrorMessage = "نام محصول باید حداقل 3 کاراکتر باشد.")]
        [MaxLength(400, ErrorMessage = "نام محصول نمی‌تواند بیشتر از 400 کاراکتر باشد.")]
        public string Name { get; set; }


        [Required(ErrorMessage = "قیمت الزامی است.")]
        [Range(100000, 9999999999, ErrorMessage = "قیمت باید بین 10000 تا 999,999,999 تومان باشد.")]
        public decimal Price { get; set; }


        [Required(ErrorMessage = "تعداد موجودی الزامی است.")]
        [Range(0, int.MaxValue, ErrorMessage = "مقدار موجودی نامعتبر است.")]
        public int Count { get; set; }


        [Required(ErrorMessage = "توضیحات محصول الزامی است.")]
        [MinLength(5, ErrorMessage = "توضیحات باید حداقل 5 کاراکتر باشد.")]
        [MaxLength(600, ErrorMessage = "توضیحات نمی‌تواند بیشتر از 600 کاراکتر باشد.")]
        public string Description { get; set; }


        public IFormFile? ProfileImage { get; set; }


        [Required(ErrorMessage = "انتخاب دسته‌بندی الزامی است.")]
        public int CategoryId { get; set; }
    }
}
