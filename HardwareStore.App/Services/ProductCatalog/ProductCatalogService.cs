namespace HardwareStore.App.Services.ProductCatalog
{
    using HardwareStore.App.Models.ProductFilter;
    using HardwareStore.App.Services.Data;
    using HardwareStore.App.Services.Data.Products;

    public class ProductCatalogService : IProductCatalogService
    {
        private readonly IProductDataService _productDataService;
        private readonly ICategoryDataService _categoryDataService;
        private readonly IProductFilterService _filterService;

        public ProductCatalogService(IProductDataService productDataService, ICategoryDataService categoryDataService, IProductFilterService filterService)
        {
            _productDataService = productDataService;
            _categoryDataService = categoryDataService;
            _filterService = filterService;
        }
        public int PageSize { get; set; }
        public async Task<ICollection<SpecificationFilterOption>> GenerateSpecificationOptions(string category)
        {
            return await _filterService.GenerateSpecificationOptions(category);
        }
        public async Task<ICollection<TModel>> GetCategories<TModel>(bool isEmpty = false)
        {
            return await _categoryDataService.GetCategories<TModel>(isEmpty);
        }
        public async Task<TModel?> GetProductById<TModel>(int id)
        {
            return await _productDataService.GetProductById<TModel>(id);
        }
        public async Task<ICollection<TModel>> GetProducts<TModel>(ICollection<int> selectedSpecsIds, string? category, string? searchString, string sortOrder = "newest", int pageNumber = 1)
        {
            var result = await _productDataService.GetProducts<TModel>(selectedSpecsIds, category, searchString, sortOrder, pageNumber);
            PageSize = _productDataService.PageSize;
            return result;
        }

        public ICollection<string> GenerateSortOrderOptions()
        {
            return _filterService.GenerateSortOrderOptions();
        }
    }
}
