namespace HardwareStore.App.Models.Product
{
    public class ProductModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string NameDetailed { get; set; }

        public string ManufacturerName { get; set; }

        public string CategoryName { get; set; }

        public IEnumerable<string> Images { get; set; } = new HashSet<string>();

        public IEnumerable<ProductSpecifications> Specifications { get; set; } = new List<ProductSpecifications>();
    }
}
