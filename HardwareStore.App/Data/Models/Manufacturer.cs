namespace HardwareStore.App.Data.Models
{
    using System.ComponentModel.DataAnnotations;
    using static HardwareStore.App.Constants.ModelConstraints.Manufacturer;

    public class Manufacturer
    {
        public Manufacturer()
        {
            Products = new HashSet<Product>();
        }

        public int Id { get; set; }

        [Required]
        [MaxLength(NameMaxLength)]
        public string Name { get; set; }

        public ICollection<Product> Products { get; set; }

    }
}