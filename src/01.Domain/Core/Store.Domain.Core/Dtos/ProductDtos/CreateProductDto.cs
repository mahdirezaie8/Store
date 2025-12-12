using Microsoft.AspNetCore.Http;
using Store.Domain.Core.Entities;
using System.ComponentModel.DataAnnotations.Schema;

namespace Store.Domain.Core.Dtos.ProductDtos
{
    public class CreateProductDto
    {
        public string Name { get; set; }
        public decimal Price { get; set; }
        public int Count { get; set; }
        public string Description { get; set; }
        public IFormFile? ProfileImage { get; set; }
        public int CategoryId { get; set; }
    }
}
