namespace HardwareStore.App.Models.Review
{
    using HardwareStore.App.ValidationAttributes;
    using System.ComponentModel.DataAnnotations;

    public class ReviewInputModel
    {

        [ValidProduct]
        public int ProductId { get; set; }

        [Range(1, 5)]
        public int? Rating { get; set; }

        [StringLength(maximumLength: 255, MinimumLength = 10, ErrorMessage = "{0} must be atleast {2}-{1} characters long")]
        [Required]
        public string Content { get; set; }

    }
}
