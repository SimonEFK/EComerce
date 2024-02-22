namespace HardwareStore.App.Models.ProductFilter
{
    public class SpecificationFilterOption
    {

        public int Id { get; set; }

        public int CategoryId { get; set; }

        public string CategoryName { get; set; }

        public string Name { get; set; }

        public ICollection<SpecificationValueOption> Values { get; set; } = new List<SpecificationValueOption>();
    }
}
