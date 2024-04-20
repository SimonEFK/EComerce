namespace HardwareStore.App.Data.Models
{
    using System.ComponentModel.DataAnnotations;
    using static Constants.ModelConstraints.Specification;
    public class Specification
    {
        public Specification()
        {
            Values = new List<SpecificationValue>();
        }

        public int Id { get; set; }

        [Required]
        [MaxLength(NameMaxLength)]
        public string Name { get; set; }

        public int? CategoryId { get; set; }

        public Category? Category { get; set; }

        public bool Filter { get; set; }

        [MaxLength(InfoLevelMaxLength)]
        public string? InfoLevel { get; set; }

        public ICollection<SpecificationValue> Values { get; set; }

    }
}