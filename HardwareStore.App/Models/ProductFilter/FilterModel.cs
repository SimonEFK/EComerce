namespace HardwareStore.App.Models.ProductFilter
{
    public class FilterModel
    {
        public Dictionary<string, List<SpecificationFilterOption>> Specifications { get; set; } = new Dictionary<string, List<SpecificationFilterOption>>();

        public ICollection<Tuple<string, int, int>> Manufacturers { get; set; } = new List<Tuple<string, int, int>>();

        public ICollection<string> SortOrder { get; set; } = new List<string>();
    }
}
