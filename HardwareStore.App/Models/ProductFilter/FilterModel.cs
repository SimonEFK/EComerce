namespace HardwareStore.App.Models.ProductFilter
{
    public class FilterModel
    {
        public ICollection<SpecificationFilterOption> Specifications { get; set; } = new List<SpecificationFilterOption>();
    }
}
