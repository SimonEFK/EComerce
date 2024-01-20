namespace HardwareStore.App.Areas.Administration.Models
{
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;

    public class CreateProductFormModel
    {
        [Required]
        [StringLength(maximumLength: 120, MinimumLength = 6)]
        public string Name { get; set; }


        [StringLength(maximumLength: 320, MinimumLength = 6)]
        [DisplayName("Name Detailed")]
        public string? NameDetailed { get; set; }

        public int CategoryId { get; set; }

        public int ManufacturerId { get; set; }

        public IEnumerable<string> ImageUrlList { get; set; } = new List<string>();

        public Dictionary<string, List<string>> Specifications { get; set; } = new Dictionary<string, List<string>>();
    }
}
