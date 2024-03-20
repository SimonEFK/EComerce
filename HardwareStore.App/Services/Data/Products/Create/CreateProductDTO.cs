namespace HardwareStore.App.Services.Data.Products.Create
{
    public class CreateProductDTO
    {
        public string Name { get; set; }

        public string? NameDetailed { get; set; }

        public int CategoryId { get; set; }

        public int ManufacturerId { get; set; }

        public HashSet<int> Specifications { get; set; } = new HashSet<int>();

        public HashSet<string> ImageUrls { get; set; } = new HashSet<string>();
    }
}

