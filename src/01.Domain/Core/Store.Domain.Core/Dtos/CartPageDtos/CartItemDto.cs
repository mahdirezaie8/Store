using Store.Domain.Core.Entities;

namespace Store.Domain.Core.Dtos.CartPageDtos
{
    public class CartItemDto
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public string? Image { get; set; }
        public decimal UnitPrice { get; set; }
        public int Quantity { get; set; }
        public decimal Totalprice => UnitPrice * Quantity;
    }
}
