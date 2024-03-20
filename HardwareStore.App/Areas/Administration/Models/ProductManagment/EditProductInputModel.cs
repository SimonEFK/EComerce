namespace HardwareStore.App.Areas.Administration.Models.ProductManagment
{
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using HardwareStore.App.Services.Data.Products;
    using HardwareStore.App.ValidationAttributes;

    public class EditProductInputModel
    {

        public int Id { get; set; }

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

        public List<ProductSpecificationEdit> Specifications { get; set; } = new List<ProductSpecificationEdit>();

        //[Required(ErrorMessage = "Product image is required")]
        //[CollectionRegex(@"^https?:\/\/.*\/.*\.(jpg|jpeg|png|gif|webp|avif)$", ErrorMessage = "Invalid Url Format")]
        //public HashSet<string> ImageUrls { get; set; } = new HashSet<string>();

        public ICollection<(string Name, int Id)> CategoryList { get; set; } = new List<(string Name, int Id)>();

        public ICollection<(string Name, int Id)> ManufacturerList { get; set; } = new List<(string Name, int Id)>();
    }
}
