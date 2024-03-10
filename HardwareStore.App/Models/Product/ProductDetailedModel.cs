namespace HardwareStore.App.Models.Product
{
    public class ProductDetailedModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string NameDetailed { get; set; }

        public string ManufacturerName { get; set; }

        public string CategoryName { get; set; }

        public int CategoryId { get; set; }

        public decimal? Price { get; set; }


        public double ProductReviewsRatingAvg { get; set; }

        public ICollection<string> Images { get; set; } = new HashSet<string>();

        public ICollection<ProductSpecifications> Specifications { get; set; } = new List<ProductSpecifications>();
    }
}
