namespace HardwareStore.App.Areas.Administration.Models
{
    using System.ComponentModel.DataAnnotations;

    public class SpecificationCreateModel
    {
        [StringLength(maximumLength: 50, MinimumLength = 3)]
        public string Name { get; set; }

        public bool Filter { get; set; }

        public string? InfoLevel { get; set; }
    }
}
