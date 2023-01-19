using System.ComponentModel.DataAnnotations;

namespace MultiShop.Models
{
    public class Product:BaseEntity
    {
        public int Name { get; set; }
        [Range(0.0,double.MaxValue)]
        public Double CostPrice { get; set; }
        [Range(0.0,double.MaxValue)]
        public Double SellPrice { get; set; }
        public string Description { get; set; }
        public int CategoryId { get; set; }

        public int InformationId { get; set; }
        public int? DiscountId { get; set; }

        public Discount? Discount { get; set; }

        public Category? Category { get; set; }

        public ICollection<ProductColor>? ProductColors { get; set; }

        public ICollection<ProductImage>? ProductImages  { get; set; }

        public ICollection <ProductSize>? ProductSizes { get; set; }

        public  ProductInformation? Information { get; set; }
        public int ProductInformationId { get; set; }

    }
}
