using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations.Schema;

namespace Store.Domain.Core.Entities
{
    public class Product:BaseClass
    {
        public string Name { get; set; }
        public decimal Price { get; set; }
        public int Count { get; set; }
        public string Description { get; set; }
        public string? Image { get; set; }
        [NotMapped]
        public IFormFile? ProfileImage { get; set; }
        public Category Category { get; set; }
        public int CategoryId { get; set; }
        public List<OrderItem> OrderItems { get; set; } = [];

    }
}
