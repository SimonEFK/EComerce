namespace HardwareStore.App.Services.Catalog
{
    using HardwareStore.App.Models.Product;
    using HardwareStore.App.Services.Models;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface ICatalogService
    {
        int PageSize { get; set; }

        Task<ProductDetailedModel> GetProductById(int id);
        Task<CatalogModel> GetProducts(
            string? searchString,
            int? category,
            ICollection<int> manufacturerIds,
            Dictionary<int,HashSet<int>> selectedSpecsIds,
            string sortOrder = "newest",
            int pageNumber = 1);
        Task<List<ProductSimplifiedModel>> GetLatestProductsAsync(int count = 4);
    }
}