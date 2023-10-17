namespace HardwareStore.App.Data.Models
{
    public class Manufacturer
    {
        public Manufacturer()
        {
            Products = new HashSet<Product>();
        }

        public int Id { get; set; }

        public string Name { get; set; }

        public ICollection<Product> Products { get; set; }

    }
}