namespace HardwareStore.App.Controllers
{
    using HardwareStore.App.Models;
    using HardwareStore.App.Models.Category;
    using HardwareStore.App.Models.ProductCatalog;
    using HardwareStore.App.Models.ProductFilter;
    using HardwareStore.App.Models.Review;
    using HardwareStore.App.Services.Catalog;
    using HardwareStore.App.Services.Data;
    using HardwareStore.App.Services.Data.Products;
    using HardwareStore.App.Services.ProductFiltering;
    using HardwareStore.App.Services.ProductReview;
    using Microsoft.AspNetCore.Mvc;

    [Route("/Catalog")]
    public class ProductCatalogController : Controller
    {
        private ICatalogService productCatalogService;
        private IGenerateProductFilterOptionService generateProductFilterOptionService;
        private ICategoryDataService categoryDataService;
        private IProductDataService productDataService;
        private IProductReviewService reviewService;

        public ProductCatalogController(ICatalogService productCatalogService, IGenerateProductFilterOptionService generateProductFilterOptionService, ICategoryDataService categoryDataService, IProductReviewService reviewService)
        {
            this.productCatalogService = productCatalogService;
            this.generateProductFilterOptionService = generateProductFilterOptionService;
            this.categoryDataService = categoryDataService;
            this.reviewService = reviewService;
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

            ViewData["sortOrder"] = model.SortOrder;
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
                ViewData["selectedSpecs"] = model.SpecificationIds.SelectMany(x => x.Value).ToList();
            }
            if (model.ManufacturerIds.Count > 0)
            {
                ViewData["selectedManufacturers"] = model.ManufacturerIds.ToList();
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
                ViewData["SearchString"] = model.SearchString;
            }

            return View(catalogViewModel);
        }

        [HttpGet]
        [Route("/ComponentDetail/{id}")]
        public async Task<IActionResult> ComponentDetail([FromRoute] int id)
        {

            var product = await productCatalogService.GetProductById(id);

            var productReviews = await reviewService.GetProductReviews(id);

            if (product is null)
            {
                return RedirectToAction(nameof(Index));
            }

            var viewModel = new ComponentDetailViewModel
            {
                Product = product,
                ProductReviewViewModel = new ProductReviewViewModel 
                {
                    ReviewInputModel = new ReviewInputModel { ProductId = id },
                    ProductReviews = productReviews
                }
            };
            return View(viewModel);

        }
    }
}
