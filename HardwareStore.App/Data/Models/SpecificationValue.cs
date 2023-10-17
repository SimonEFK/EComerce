namespace HardwareStore.App.Data.Models
{
    public class SpecificationValue
    {
        public SpecificationValue()
        {
            //this.ProductSpecificationValues = new HashSet<ProductSpecificationValues>();
            Products = new List<ProductSpecificationValues>();
        }
        public int Id { get; set; }

        public string Value { get; set; }

        public string? Metric { get; set; }

        public int SpecificationId { get; set; }

        public Specification Specification { get; set; }

        public ICollection<ProductSpecificationValues> Products { get; set; }

    }

}