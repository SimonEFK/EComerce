namespace HardwareStore.App.Areas.Administration.Models.ProductManagment
{
    using HardwareStore.App.Services;
    using HardwareStore.App.ValidationAttributes;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;

    public class CreateProductInputModel 
        //: IValidatableObject
    {
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

        
        public HashSet<int> Specifications { get; set; } = new HashSet<int>();

        [Required(ErrorMessage = "Product image is required")]
        [CollectionRegex(@"^https?:\/\/.*\/.*\.(jpg|jpeg|png|gif|webp|avif)$", ErrorMessage = "Invalid Url Format")]
        public HashSet<string> ImageUrls { get; set; } = new HashSet<string>();

        public ICollection<(string Name, int Id)> CategoryList { get; set; } = new List<(string Name, int Id)>();

        public ICollection<(string Name, int Id)> ManufacturerList { get; set; } = new List<(string Name, int Id)>();

        //public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        //{
        //    if (this.ImageUrls.Count > 10)
        //    {
        //        yield return new ValidationResult("Way too many images");
        //    }
        //    if (this.Specifications.Count <= 30 && this.Specifications.Count >= 3)
        //    {
        //        yield return new ValidationResult("Specifications must be 3-30 count");
        //    }
        //}
    }
}
