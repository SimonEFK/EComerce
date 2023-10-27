namespace HardwareStore.App.Controllers
{
    using HardwareStore.App.Models;
    using HardwareStore.App.Models.Product;
    using HardwareStore.App.Models.ProductCatalog;
    using HardwareStore.App.Models.ProductFilter;
    using HardwareStore.App.Services;
    using HardwareStore.App.Services.Data.Products;
    using Microsoft.AspNetCore.Mvc;
    [Route("/catalog")]
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


        [HttpGet]
        [Route("{category?}")]
        public async Task<IActionResult> Products(BrowseProductInputModel model)
        {
            var products = await this.productDataService.GetProducts<ProductExtendedModel>(model.SpecificationIds, model.Category, model.SearchString, model.SortOrder, model.Page);

            var filterModel = new FilterModel();

            filterModel.SortOrder.Add("newest");
            filterModel.SortOrder.Add("oldest");
            TempData["sortOrder"] = model.SortOrder;
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
            if (model.SearchString is not null)
            {
                TempData["SearchString"] = model.SearchString;
            }

            return View(catalogModel);
        }

        [HttpGet]
        [Route("/{action}")]
        public async Task<IActionResult> ComponentDetail(int id)
        {
            var product = await productDataService.GetProductById<ProductDetailedModel>(id);
            return View(product);
        }
    }
}
