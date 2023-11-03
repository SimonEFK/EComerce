namespace HardwareStore.App.Models.Product
{
    public class ProductExtendedModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string ManufacturerName { get; set; }

        public string ImageUrl { get; set; }

        public IEnumerable<ProductSpecifications> Specifications { get; set; } = new HashSet<ProductSpecifications>();
        
    }
}
