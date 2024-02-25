namespace HardwareStore.App.Services.Models
{
    using HardwareStore.App.Models.Product;
    using HardwareStore.App.Models.ProductFilter;

    public class CatalogModel
    {
        public ICollection<ProductExtendedModel> Products { get; set; } = new List<ProductExtendedModel>();

        public Dictionary<string, List<SpecificationFilterOption>> SpecificationFilters { get; set; } = new Dictionary<string, List<SpecificationFilterOption>>();

        public ICollection<Tuple<string, int, int>> Manufacturers { get; set; } = new List<Tuple<string, int, int>>();

        public ICollection<string> SortOrder { get; set; } = new List<string>();
    }
}
