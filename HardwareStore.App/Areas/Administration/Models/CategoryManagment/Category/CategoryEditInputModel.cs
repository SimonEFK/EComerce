namespace HardwareStore.App.Areas.Administration.Models.CategoryManagment.Category
{
    using System.ComponentModel.DataAnnotations;

    public class CategoryEditInputModel
    {
        public int Id { get; set; }

        [StringLength(maximumLength: 20, MinimumLength = 3, ErrorMessage = "{0} field must be with length {1} - {2} symbols")]
        [Required]
        public string Name { get; set; }

        public string? FilePath { get; set; }

        [RegularExpression(@"^https?:\/\/.*\/.*\.(jpg|jpeg|png|gif|webp|avif)$", ErrorMessage = "Invalid Url Format")]
        public string? Url { get; set; }

    }
}
