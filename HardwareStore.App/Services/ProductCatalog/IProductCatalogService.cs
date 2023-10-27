namespace HardwareStore.App.Services.ProductCatalog
{
    using HardwareStore.App.Models.ProductFilter;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface IProductCatalogService
    {
        int PageSize { get; }

        ICollection<string> GenerateSortOrderOptions();

        Task<ICollection<SpecificationFilterOption>> GenerateSpecificationOptions(string category);

        Task<ICollection<TModel>> GetCategories<TModel>(bool isEmpty = false);

        Task<TModel?> GetProductById<TModel>(int id);

        Task<ICollection<TModel>> GetProducts<TModel>(ICollection<int> selectedSpecsIds, string? category, string? searchString, string sortOrder = "newest", int pageNumber = 1);
    }
}