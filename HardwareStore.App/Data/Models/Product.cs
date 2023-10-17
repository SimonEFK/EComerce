namespace HardwareStore.App.Data.Models
{
    using System.ComponentModel.DataAnnotations.Schema;

    public class Product
    {
        public Product()
        {
            Images = new HashSet<Image>();
            Specifications = new HashSet<ProductSpecificationValues>();
            ProductReviews = new HashSet<ProductReview>();
            PartNumbers = new HashSet<PartNumber>();
            Carts = new HashSet<CartProduct>();
        }

        public int Id { get; set; }

        public string Name { get; set; }

        public string? NameDetailed { get; set; }

        public int CategoryId { get; set; }

        public Category Category { get; set; }

        public int? ManufacturerId { get; set; }

        public Manufacturer? Manufacturer { get; set; }

        public ICollection<PartNumber> PartNumbers { get; set; }

        public ICollection<Image> Images { get; set; }

        //public ICollection<ProductSpecificationValues> Specifications { get; set; }

        public ICollection<ProductReview> ProductReviews { get; set; }

        public ICollection<CartProduct> Carts { get; set; }

        public ICollection<ProductSpecificationValues> Specifications { get; set; }

    }

}
