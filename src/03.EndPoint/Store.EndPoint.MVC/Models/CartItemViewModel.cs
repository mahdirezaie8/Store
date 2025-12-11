using Store.Domain.Core.Dtos.CartPageDtos;

namespace Store.EndPoint.MVC.Models
{
    public class CartItemViewModel
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public string? Image { get; set; }
        public decimal UnitPrice { get; set; }
        public int Quantity { get; set; }
        public decimal Totalprice {  get; set; }
    }
}
