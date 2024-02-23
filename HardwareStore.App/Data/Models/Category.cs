namespace HardwareStore.App.Data.Models
{
    public class Category
    {
        public Category()
        {
            Products = new List<Product>();

        }

        public int Id { get; set; }

        public string Name { get; set; }

        public string? FilePath { get; set; }

        public string? Url { get; set; }



        public ICollection<Product> Products { get; set; }
        public ICollection<Specification> Specifications { get; set; } = new List<Specification>();

    }
}