namespace HardwareStore.App.Models.ProductCatalog
{
    using HardwareStore.App.Models.Product;

    public class ProductCatalogModel
    {
        public PaginationModel Pagination { get; set; }

        public ICollection<ProductExtendedModel> Products { get; set; } = new List<ProductExtendedModel>();
    }
}
