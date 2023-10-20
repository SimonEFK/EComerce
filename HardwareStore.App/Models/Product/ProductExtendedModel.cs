namespace HardwareStore.App.Models.Product
{
    public class ProductExtendedModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string ManufacturerName { get; set; }

        public string ImageUrl { get; set; }

        public ICollection<ProductSpecifications> Specifications { get; set; }

        //public ICollection<KeyValuePair<string, string>> Specifications { get; set; }
    }
}
