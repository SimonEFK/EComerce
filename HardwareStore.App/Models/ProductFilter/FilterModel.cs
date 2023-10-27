namespace HardwareStore.App.Models.ProductFilter
{
    public class FilterModel
    {
        public ICollection<SpecificationFilterOption> Specifications { get; set; } = new List<SpecificationFilterOption>();

        public ICollection<string> SortOrder { get; set; } = new List<string>();
    }
}
