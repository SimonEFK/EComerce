namespace HardwareStore.App.Controllers
{
    using HardwareStore.App.Models;
    using HardwareStore.App.Models.Category;
    using HardwareStore.App.Models.Product;
    using HardwareStore.App.Models.ProductCatalog;
    using HardwareStore.App.Models.ProductFilter;
    using HardwareStore.App.Services.Data;
    using HardwareStore.App.Services.Data.Products;
    using HardwareStore.App.Services.ProductCatalog;
    using Microsoft.AspNetCore.Mvc;
    [Route("Catalog")]
    public class ProductCatalogController : Controller
    {
        private IProductCatalogService productCatalogService;

        public ProductCatalogController(IProductCatalogService productCatalogService)
        {
            this.productCatalogService = productCatalogService;
        }

        public async Task<IActionResult> Index()
        {
            var categories = await productCatalogService.GetCategories<CategoryModel>();
            return View(categories);
        }


        [HttpGet]
        [Route("{category?}")]
        public async Task<IActionResult> Products(BrowseProductInputModel model)
        {
            var products = await this.productCatalogService.GetProducts<ProductExtendedModel>(
                model.SpecificationIds,
                model.Category,
                model.SearchString,
                model.SortOrder,
                model.Page);

            var filterModel = new FilterModel()
            {
                SortOrder = productCatalogService.GenerateSortOrderOptions()
            };

            TempData["sortOrder"] = model.SortOrder;
            if (model.Category is not null)
            {
                var specFilters = await this.productCatalogService.GenerateSpecificationOptions(model.Category);
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
                PageSize = this.productCatalogService.PageSize
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
        [Route("/ComponentDetail/{id}")]
        public async Task<IActionResult> ComponentDetail([FromRoute] int id)
        {
            var product = await productCatalogService.GetProductById<ProductDetailedModel>(id);
            return View(product);
        }
    }
}
