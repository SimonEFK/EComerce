namespace HardwareStore.App.Models.ProductFilter
{
    public class FilterModel
    {
        public ICollection<SpecificationFilterOption> Specifications { get; set; } = new List<SpecificationFilterOption>();

        public ICollection<Tuple<string, int>> Manufacturers { get; set; } = new List<Tuple<string, int>>();

        public ICollection<string> SortOrder { get; set; } = new List<string>();
    }
}
