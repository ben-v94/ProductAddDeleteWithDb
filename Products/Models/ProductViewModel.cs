namespace Products.Models
{
    public class ProductViewModel
    {
        public int ID { get; set; }
        public required string Name { get; set; }
        public required string Description { get; set; }
        public required decimal Price { get; set; }
    }
}
