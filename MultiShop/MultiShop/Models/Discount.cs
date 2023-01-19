namespace MultiShop.Models
{
    public class Discount:BaseEntity
    {
        public double Discountsell { get; set; }

        public ICollection <Product> Products { get; set; }
    }
}
