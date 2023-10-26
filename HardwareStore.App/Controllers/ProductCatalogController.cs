namespace HardwareStore.App.Controllers
{
    using HardwareStore.App.Models;
    using HardwareStore.App.Models.Product;
    using HardwareStore.App.Models.ProductCatalog;
    using HardwareStore.App.Models.ProductFilter;
    using HardwareStore.App.Services;
    using HardwareStore.App.Services.Data.Products;
    using Microsoft.AspNetCore.Mvc;
    [Route("catalog/{action=index}")]
    public class ProductCatalogController : Controller
    {
        private IProductDataService productDataService;
        private IProductFilterService productFilterService;

        public ProductCatalogController(IProductDataService productDataService, IProductFilterService productFilterService)
        {
            this.productDataService = productDataService;
            this.productFilterService = productFilterService;
        }

        public IActionResult Index()
        {
            return View();
        }
        public async Task<IActionResult> TestSpecificationService(string category)
        {
            var result = await productFilterService.GenerateSpecificationOptions(category);
            return Json(result);
        }

        [HttpGet]
        [Route("{category?}/{page?}")]
        public async Task<IActionResult> Products(BrowseProductInputModel model)
        {
            var products = await this.productDataService.GetProducts<ProductExtendedModel>(model.SpecificationIds, model.SearchString, model.Category, model.Page);
            var filterModel = new FilterModel();
            if (model.Category is not null)
            {
                var specFilters = await this.productFilterService.GenerateSpecificationOptions(model.Category);
                var category = TempData["Category"] = model.Category;
                filterModel.Specifications = specFilters;

            }
            if (model.SpecificationIds.Count > 0)
            {
                TempData["selectedSpecs"] = model.SpecificationIds.ToList();

            }
            var paginationModel = new PaginationModel
            {
                Page = model.Page,
                PageSize = this.productDataService.PageSize
            };
            var catalogModel = new ProductCatalogModel
            {
                Products = products,
                Pagination = paginationModel,
                ProductFilters = filterModel
            };

            return View(catalogModel);
        }
    }
}
