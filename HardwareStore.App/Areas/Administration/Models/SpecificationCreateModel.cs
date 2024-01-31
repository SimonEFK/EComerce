namespace HardwareStore.App.Areas.Administration.Models
{
    using System.ComponentModel.DataAnnotations;

    public class SpecificationCreateModel
    {
        [StringLength(maximumLength: 100, MinimumLength = 3, ErrorMessage = "{0} must be {2}-{1} characters long")]
        public string Name { get; set; }

        public bool Filter { get; set; }

        public string? InfoLevel { get; set; }

        public int CategoryId { get; set; }
    }
}
