using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace Store.Domain.Core.Dtos.ProductDtos
{
    public class UpdateProductDto
    {
        public int Id { get; set; }

        [MinLength(3, ErrorMessage = "نام محصول باید حداقل 3 کاراکتر باشد.")]
        [MaxLength(300, ErrorMessage = "نام محصول نباید بیش از 300 کاراکتر باشد.")]
        public string? Name { get; set; }

        [Range(0, double.MaxValue, ErrorMessage = "قیمت باید عددی بزرگتر یا مساوی صفر باشد.")]
        public decimal? Price { get; set; }

        [MinLength(10, ErrorMessage = "توضیحات باید حداقل 10 کاراکتر باشد.")]
        [MaxLength(500, ErrorMessage = "توضیحات نمی‌تواند بیش از ۵۰۰ کاراکتر باشد.")]
        public string? Description { get; set; }

        public string? Image { get; set; }

        [DataType(DataType.Upload)]
        [FileExtensions(Extensions = "jpg,jpeg,png,gif", ErrorMessage = "فرمت فایل باید jpg, jpeg, png یا gif باشد.")]
        public IFormFile? ProfileImage { get; set; }
    }
}
