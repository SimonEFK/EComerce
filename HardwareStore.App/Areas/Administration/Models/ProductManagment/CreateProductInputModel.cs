namespace HardwareStore.App.Areas.Administration.Models.ProductManagment
{
    using HardwareStore.App.Constants;
    using HardwareStore.App.ValidationAttributes;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;

    public class CreateProductInputModel         
    {

        public decimal? Price { get; set; }

        [Required]
        [StringLength(maximumLength: 60, MinimumLength = 6, ErrorMessage = "{0} field must be {2}-{1} characters long")]
        public string Name { get; set; }

        [StringLength(maximumLength: 120, MinimumLength = 6, ErrorMessage = "{0} field must be {2}-{1} characters long")]
        [DisplayName("Name Detailed")]
        public string? NameDetailed { get; set; }

        [ValidCategory(ErrorMessage = "Invalid Category")]
        public int CategoryId { get; set; }

        [ValidManufacturer(ErrorMessage = "Invalid Manufacturer")]
        public int ManufacturerId { get; set; }

        [ValidSpecificationValue(ErrorMessage ="Invalid Specification Values")]
        public HashSet<int> Specifications { get; set; } = new HashSet<int>();

        [Required(ErrorMessage = "Product image is required")]
        [CollectionRegex(ModelConstraints.Image.ImageRegexPattern, ErrorMessage = "Invalid Url Format")]
        public HashSet<string> ImageUrls { get; set; } = new HashSet<string>();

        public ICollection<(string Name, int Id)> CategoryList { get; set; } = new List<(string Name, int Id)>();

        public ICollection<(string Name, int Id)> ManufacturerList { get; set; } = new List<(string Name, int Id)>();

        
    }
}
