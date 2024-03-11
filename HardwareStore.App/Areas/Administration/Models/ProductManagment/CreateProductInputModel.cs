namespace HardwareStore.App.Areas.Administration.Models.ProductManagment
{
    using HardwareStore.App.Services;
    using HardwareStore.App.ValidationAttributes;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;

    public class CreateProductInputModel
    {
        [Required]
        [StringLength(maximumLength: 60, MinimumLength = 6, ErrorMessage = "{0} field must be {2}-{1} characters long")]
        public string Name { get; set; }

        [StringLength(maximumLength: 120, MinimumLength = 6, ErrorMessage = "{0} field must be {2}-{1} characters long")]
        [DisplayName("Name Detailed")]
        public string? NameDetailed { get; set; }

        [Range(minimum: 1, maximum: int.MaxValue, ErrorMessage = "Invalid Category")]
        public int CategoryId { get; set; }

        [Range(minimum: 1, maximum: int.MaxValue, ErrorMessage = "Invalid Manufacturer")]
        public int ManufacturerId { get; set; }

        public Dictionary<string, List<string>> Specifications { get; set; } = new Dictionary<string, List<string>>();

        [Required(ErrorMessage = "Product image is required")]
        [CollectionRegex(@"^https?:\/\/.*\/.*\.(jpg|jpeg|png|gif|webp|avif)$", ErrorMessage = "Invalid Url Format")]
        public HashSet<string> ImageUrls { get; set; } = new HashSet<string>();

        public ICollection<(string Name, int Id)> CategoryList { get; set; } = new List<(string Name, int Id)>();

        public ICollection<(string Name, int Id)> ManufacturerList { get; set; } = new List<(string Name, int Id)>();
    }
}
