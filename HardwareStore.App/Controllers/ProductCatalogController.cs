namespace HardwareStore.App.Controllers
{
    using HardwareStore.App.Models;
    using HardwareStore.App.Models.Category;
    using HardwareStore.App.Models.Product;
    using HardwareStore.App.Models.ProductCatalog;
    using HardwareStore.App.Models.ProductFilter;
    using HardwareStore.App.Services;
    using HardwareStore.App.Services.Catalog;
    using HardwareStore.App.Services.Data;
    using HardwareStore.App.Services.Data.Products;
    using Microsoft.AspNetCore.Mvc;
    [Route("Catalog")]
    public class ProductCatalogController : Controller
    {
        private ICatalogService productCatalogService;
        private IGenerateProductFilterOptionService generateProductFilterOptionService;
        private ICategoryDataService categoryDataService;
        private IProductDataService productDataService;

        public ProductCatalogController(ICatalogService productCatalogService, IGenerateProductFilterOptionService generateProductFilterOptionService, ICategoryDataService categoryDataService, IProductDataService productDataService)
        {
            this.productCatalogService = productCatalogService;
            this.generateProductFilterOptionService = generateProductFilterOptionService;
            this.categoryDataService = categoryDataService;
            this.productDataService = productDataService;
        }

        public async Task<IActionResult> Index()
        {
            var categories = await categoryDataService.GetCategories<CategoryModel>();
            return View(categories);
        }


        [HttpGet]
        [Route("{category?}")]
        public async Task<IActionResult> Products(BrowseProductInputModel model)
        {
            var products = await this.productCatalogService.GetProducts(
                model.SearchString,
                model.Category,
                model.ManufacturerIds,
                model.SpecificationIds,
                model.SortOrder,
                model.Page);

            if (products.Count == 0)
            {
                return RedirectToAction(nameof(Index));
            }

            var manufacturers = generateProductFilterOptionService.GenerateManufacturerOptions(model.Category);

            var filterModel = new FilterModel()
            {
                SortOrder = generateProductFilterOptionService.GenerateSortOrderOptions(),

            };

            TempData["sortOrder"] = model.SortOrder;
            if (model.Category is not null)
            {
                var specFilters = await this.generateProductFilterOptionService.GenerateSpecificationOptions(model.Category);
                var category = TempData["Category"] = model.Category;
                filterModel.Specifications = specFilters;
                filterModel.Manufacturers = this.generateProductFilterOptionService.GenerateManufacturerOptions(model.Category);

            }
            if (model.SpecificationIds.Count > 0)
            {
                TempData["selectedSpecs"] = model.SpecificationIds.ToList();

            }
            if (model.ManufacturerIds.Count > 0)
            {
                TempData["selectedManufacturers"] = model.ManufacturerIds.ToList();
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

            var product = await productDataService.GetProductById<ProductDetailedModel>(id);
            if (product is null)
            {
                return RedirectToAction(nameof(Index));
            }
            return View(product);
        }
    }
}
