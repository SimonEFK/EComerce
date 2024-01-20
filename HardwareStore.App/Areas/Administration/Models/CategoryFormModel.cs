namespace HardwareStore.App.Areas.Administration.Models
{
    using System.ComponentModel.DataAnnotations;

    public class CategoryFormModel
    {
        [StringLength(maximumLength: 20, MinimumLength = 3)]
        public string Name { get; set; }

        [Required]
        public string Image { get; set; }
    }
}
