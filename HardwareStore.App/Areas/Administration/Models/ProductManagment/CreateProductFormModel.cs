namespace HardwareStore.App.Areas.Administration.Models.ProductManagment
{
    using DataAnnotationsExtensions;
    using HardwareStore.App.Services;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;

    public class CreateProductFormModel
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
        public string[] ImageArray { get; set; }
    }
}
