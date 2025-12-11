namespace Store.Domain.Core.Entities
{
    public class Order:BaseClass
    {
        public User User { get; set; }
        public int UserId { get; set; }
        public DateTime OrderDate { get; set; }
        public decimal TotalPrice { get; set; }
        public List<OrderItem> OrderItems { get; set; } = [];
    }
}
