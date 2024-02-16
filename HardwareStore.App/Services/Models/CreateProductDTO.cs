namespace HardwareStore.App.Services.Models
{
    public class CreateProductDTO
    {
        public string Name { get; set; }

        public string? NameDetailed { get; set; }

        public int CategoryId { get; set; }

        public int ManufacturerId { get; set; }

        public Dictionary<string, List<string>> Specifications { get; set; } = new Dictionary<string, List<string>>();

        public HashSet<string> ImageUrls { get; set; } = new HashSet<string>();
    }
}

