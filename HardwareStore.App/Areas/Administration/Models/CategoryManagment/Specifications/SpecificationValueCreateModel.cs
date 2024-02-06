namespace HardwareStore.App.Areas.Administration.Models.CategoryManagment.Specifications
{
    using System.ComponentModel.DataAnnotations;

    public class SpecificationValueCreateModel
    {
        public int SpecificationId { get; set; }

        [StringLength(maximumLength: 100, MinimumLength = 3, ErrorMessage = "{0} must be {2}-{1} characters long")]
        public string Value { get; set; }

    }
}
