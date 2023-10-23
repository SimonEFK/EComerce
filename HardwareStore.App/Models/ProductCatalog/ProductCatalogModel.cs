namespace HardwareStore.App.Models.ProductCatalog
{
    using HardwareStore.App.Models.Product;
    using HardwareStore.App.Models.ProductFilter;

    public class ProductCatalogModel
    {
        public FilterModel ProductFilters { get; set; }
        public PaginationModel Pagination { get; set; }

        public ICollection<ProductExtendedModel> Products { get; set; } = new List<ProductExtendedModel>();
    }
}
