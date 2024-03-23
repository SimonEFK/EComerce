namespace HardwareStore.App.Areas.Administration.Models.ProductManagment
{
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using HardwareStore.App.Services.Data.Products.Edit;
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
        [DisplayName("Category")]
        public int CategoryId { get; set; }

        [ValidManufacturer(ErrorMessage = "Invalid Manufacturer")]
        [DisplayName("Manufacturer")]
        public int ManufacturerId { get; set; }
        

        public List<EditImageDTO> Images { get; set; } = new List<EditImageDTO>();

        public List<ProductSpecificationEdit> Specifications { get; set; } = new List<ProductSpecificationEdit>();
        
        public ICollection<(string Name, int Id)> CategoryList { get; set; } = new List<(string Name, int Id)>();

        public ICollection<(string Name, int Id)> ManufacturerList { get; set; } = new List<(string Name, int Id)>();
    }
}
