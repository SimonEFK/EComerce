namespace HardwareStore.App.Services.Catalog
{
    using HardwareStore.App.Models.Product;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface ICatalogService
    {
        ICatalogService ByCategory(int? categoryId);
        ICatalogService ByManufacturer(IEnumerable<int> manufacturerIds);
        ICatalogService FilterBySpecification(Dictionary<int, HashSet<int>> selectedSpecsIds);
        Task<List<ProductSimplifiedModel>> GetLatestProductsAsync(int count = 4);
        Task<ProductDetailedModel> GetProductById(int id);
        ICatalogService GetProducts(string? searchstring);
        ICatalogService Order(string sortOrder);
        ICatalogService Pagination(int pageNumber, int itemsPerPage = 12);
        Task<CatalogModel> ToCatalogModel();
    }
}