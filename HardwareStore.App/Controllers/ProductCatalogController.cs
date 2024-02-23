namespace HardwareStore.App.Controllers
{
    using AutoMapper;
    using HardwareStore.App.Data;
    using HardwareStore.App.Models;
    using HardwareStore.App.Models.Category;
    using HardwareStore.App.Models.ProductCatalog;
    using HardwareStore.App.Models.ProductFilter;
    using HardwareStore.App.Services.Catalog;
    using HardwareStore.App.Services.Data;
    using HardwareStore.App.Services.Data.Products;
    using HardwareStore.App.Services.ProductFiltering;
    using Microsoft.AspNetCore.Mvc;

    [Route("/Catalog")]
    public class ProductCatalogController : Controller
    {
        private ICatalogService productCatalogService;
        private IGenerateProductFilterOptionService generateProductFilterOptionService;
        private ICategoryDataService categoryDataService;
        private IProductDataService productDataService;


        public ProductCatalogController(ICatalogService productCatalogService, IGenerateProductFilterOptionService generateProductFilterOptionService, ICategoryDataService categoryDataService)
        {
            this.productCatalogService = productCatalogService;
            this.generateProductFilterOptionService = generateProductFilterOptionService;
            this.categoryDataService = categoryDataService;
        }

        public async Task<IActionResult> Index()
        {
            var categories = await categoryDataService.GetCategories<CategoryModel>();
            return View(categories.Where(x => x.ProductsCount > 0).OrderByDescending(x => x.Name).ToList());
        }


        [HttpGet]

        [Route("Products/{category?}")]
        public async Task<IActionResult> Products(BrowseProductInputModel model)
        {

            if (!ModelState.IsValid)
            {
                return RedirectToAction("Index");

            }

            var catalogModel = await this.productCatalogService.GetProducts(
                model.SearchString,
                model.Category,
                model.ManufacturerIds,
                model.SpecificationIds,
                model.SortOrder,
                model.Page);

            TempData["sortOrder"] = model.SortOrder;
            if (model.Category is not null)
            {
                var category = TempData["Category"] = model.Category;
            }

            var filterModel = new FilterModel
            {
                Specifications = catalogModel.SpecificationFilters,
                Manufacturers = catalogModel.Manufacturers,
                SortOrder = catalogModel.SortOrder
            };

            if (model.SpecificationIds.Count > 0)
            {
                TempData["selectedSpecs"] = model.SpecificationIds.SelectMany(x => x.Value).ToList();
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
            var catalogViewModel = new ProductCatalogModel
            {
                Products = catalogModel.Products,
                Pagination = paginationModel,
                ProductFilters = filterModel
            };

            if (model.SearchString is not null)
            {
                TempData["SearchString"] = model.SearchString;
            }

            return View(catalogViewModel);
        }

        [HttpGet]
        [Route("/ComponentDetail/{id}")]
        public async Task<IActionResult> ComponentDetail([FromRoute] int id)
        {

            var product = await productCatalogService.GetProductById(id);
            if (product is null)
            {
                return RedirectToAction(nameof(Index));
            }
            return View(product);
        }
    }
}
