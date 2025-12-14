using System.ComponentModel.DataAnnotations;

namespace Store.EndPoint.MVC.Areas.Admin.Models
{
    public class CategoryViewModel
    {
        public int Id { get; set; }
        [MinLength(5, ErrorMessage = "توضیحات باید حداقل 10 کاراکتر باشد.")]
        [MaxLength(300, ErrorMessage = "توضیحات نمی‌تواند بیش از 300 کاراکتر باشد.")]
        public string Title { get; set; }
    }
}
