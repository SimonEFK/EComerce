namespace HardwareStore.App.Areas.Administration.Models
{
    using System.ComponentModel.DataAnnotations;

    public class CategoryEditModel
    {
        [StringLength(maximumLength: 20, MinimumLength = 3, ErrorMessage = "{0} field must be with length {1} - {2} symbols")]
        [Required]
        public string Name { get; set; }

        //[Required(ErrorMessage = "Category image is required")]
        public string? ImageFilePath { get; set; }

        public string? ImageUrl { get; set; }


    }
}
