namespace HardwareStore.App.Data.Models
{
    public class Specification
    {
        public Specification()
        {
            Values = new List<SpecificationValue>();
        }

        public int Id { get; set; }

        public string Name { get; set; }

        public int? CategoryId { get; set; }

        public Category? Category { get; set; }

        public bool Filter { get; set; }

        public string? InfoLevel { get; set; }

        public ICollection<SpecificationValue> Values { get; set; }

    }
}