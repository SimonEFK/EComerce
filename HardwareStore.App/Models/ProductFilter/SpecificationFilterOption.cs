namespace HardwareStore.App.Models.ProductFilter
{
    public class SpecificationFilterOption
    {
        public string Name { get; set; }

        public ICollection<SpecificationValueOption> Values { get; set; } = new List<SpecificationValueOption>();
    }
}
