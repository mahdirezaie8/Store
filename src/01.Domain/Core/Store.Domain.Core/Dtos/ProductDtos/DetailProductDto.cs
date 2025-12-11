namespace Store.Domain.Core.Dtos.ProductDtos
{
    public class DetailProductDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public int Count { get; set; }
        public string Description { get; set; }
        public string? Image { get; set; }
    }
}
