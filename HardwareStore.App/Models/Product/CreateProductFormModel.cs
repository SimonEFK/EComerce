namespace HardwareStore.App.Models.Product
{
    public class CreateProductFormModel
    {
        public string Name { get; set; }

        public string NameDetailed { get; set; }

        public int CategoryId { get; set; }

        public int ManufacturerId { get; set; }

        public IEnumerable<string> ImageUrlList { get; set; } = new List<string>();

        public Dictionary<string, List<string>> Specifications { get; set; } = new Dictionary<string, List<string>>();
    }
}
