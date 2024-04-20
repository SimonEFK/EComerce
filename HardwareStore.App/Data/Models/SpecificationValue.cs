namespace HardwareStore.App.Data.Models
{
    using System.ComponentModel.DataAnnotations;
    using static HardwareStore.App.Constants.ModelConstraints.SpecificationValue;
    public class SpecificationValue
    {
        public SpecificationValue()
        {
            
            Products = new List<ProductSpecificationValues>();
        }
        public int Id { get; set; }

        [Required]
        [MaxLength(ValueMaxLength)]
        public string Value { get; set; }

        [MaxLength(MetricMaxLength)]
        public string? Metric { get; set; }

        public int SpecificationId { get; set; }

        public Specification Specification { get; set; }

        public ICollection<ProductSpecificationValues> Products { get; set; }

    }

}