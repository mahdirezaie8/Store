namespace Store.Domain.Core.Dtos.CartPageDtos
{
    public class CartDto
    {
        public List<CartItemDto> CartItemDtos { get; set; } = [];
        public decimal TotalPrice =>CartItemDtos.Sum(c=>c.Totalprice);
    }
}
