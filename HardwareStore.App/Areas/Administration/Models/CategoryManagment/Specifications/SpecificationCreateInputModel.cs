namespace HardwareStore.App.Areas.Administration.Models.CategoryManagment.Specifications
{
    using System.ComponentModel.DataAnnotations;

    public class SpecificationCreateInputModel
    {
        public int? Id { get; set; } 

        [StringLength(maximumLength: 100, MinimumLength = 3, ErrorMessage = "{0} must be {2}-{1} characters long")]
        public string Name { get; set; }

        public bool Filter { get; set; } = false;

        public bool Essential { get; set; } = false;

        public int? CategoryId { get; set; }
    }
}
