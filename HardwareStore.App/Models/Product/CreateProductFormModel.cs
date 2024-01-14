namespace HardwareStore.App.Models.Product
{
    public class CreateProductFormModel
    {
        public string Name { get; set; }

        public string NameDetailed { get; set; }

        public string Category { get; set; }

        public string Manufacturer { get; set; }

        public IEnumerable<string> ImageUrlList { get; set; } = new List<string>();

        public Dictionary<string, List<string>> Specifications { get; set; } = new Dictionary<string, List<string>>();
    }
}
