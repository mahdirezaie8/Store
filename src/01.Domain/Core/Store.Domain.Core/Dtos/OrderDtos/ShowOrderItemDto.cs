using Store.Domain.Core.Entities;

namespace Store.Domain.Core.Dtos.OrderDtos
{
    public class ShowOrderItemDto
    {
        public int OrderItemId { get; set; }
        public string Name { get; set; }
        public int ProductId { get; set; }
        public decimal UnitPrice { get; set; }
        public int Quantity { get; set; }
        public string? Image { get; set; }
    }
}
