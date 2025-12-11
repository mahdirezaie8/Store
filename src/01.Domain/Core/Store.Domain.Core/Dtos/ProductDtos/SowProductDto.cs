namespace Store.Domain.Core.Dtos.ProductDtos
{
    public class SowProductDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string? Image { get; set; }
        public int CategoryId { get; set; }
    }
}
