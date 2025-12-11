namespace Store.Domain.Core.Entities
{
    public class Category:BaseClass
    {
        public string Title { get; set; }
        public List<Product> Products { get; set; } = [];
       
    }
}
