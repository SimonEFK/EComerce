namespace HardwareStore.App.Models.Product
{
    public class ProductSpecifications
    {
        public string Name { get; set; }

        public IEnumerable<string> Values { get; set; } = new HashSet<string>();

    }
}
