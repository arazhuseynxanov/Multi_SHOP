namespace MultiShop.Models
{
    public class ProductInformation:BaseEntity
    {
        public string Name { get; set; }
        public string Title { get; set; }
        public ICollection<Product> Products { get; set; }
    }
}
