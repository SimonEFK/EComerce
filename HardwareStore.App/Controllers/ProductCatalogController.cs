namespace HardwareStore.App.Controllers
{
    using HardwareStore.App.Models;
    using HardwareStore.App.Models.Category;
    using HardwareStore.App.Models.Product;
    using HardwareStore.App.Models.ProductCatalog;
    using HardwareStore.App.Models.ProductFilter;
    using HardwareStore.App.Models.Review;
    using HardwareStore.App.Services.Catalog;
    using HardwareStore.App.Services.Data.Category;
    using HardwareStore.App.Services.ProductFiltering;
    using HardwareStore.App.Services.ProductReview;
    using Microsoft.AspNetCore.Mvc;

    [Route("/Catalog")]
    public class ProductCatalogController : Controller
    {
        private ICatalogService productCatalogService;
        private IProductReviewService reviewService;
        private ICategoryDataService categoryDataService;
        private IGenerateProductFilterOptionService generateFilters;

        public ProductCatalogController(ICatalogService productCatalogService, IProductReviewService reviewService, ICategoryDataService categoryDataService, IGenerateProductFilterOptionService generateFilters)
        {
            this.productCatalogService = productCatalogService;
            this.reviewService = reviewService;
            this.categoryDataService = categoryDataService;
            this.generateFilters = generateFilters;
        }

        public async Task<IActionResult> Index()
        {
            var categories = await categoryDataService.GetCategories<CategoryModel>();
            return View(categories.Where(x => x.ProductsCount > 0)
                .OrderByDescending(x => x.Name)
                .ToList());
        }

        [HttpGet]
        [Route("Products/{page?}/{category?}")]
        public async Task<IActionResult> Products(int? category, string? s)
        {
            if (category is null && s is null)
            {
                return RedirectToAction(nameof(Index));
            }

            if (category is not null)
            {
                ViewData["Category"] = category;
            }
            if (s is not null)
            {
                ViewData["SearchString"] = s;
            }

            var specificationFilters = await generateFilters.GenerateSpecificationOptions(category, s);

            if (specificationFilters.Count == 0)
            {
                return RedirectToAction(nameof(Index));

            }
            var manufacturerFilters = await generateFilters.GenerateManufacturerOptions(category, s);
            var sortOrderOptions = generateFilters.GenerateSortOrderOptions();

            var filterModel = new FilterModel
            {
                Specifications = specificationFilters,
                Manufacturers = manufacturerFilters,
                SortOrder = sortOrderOptions
            };

            return View(filterModel);
        }

        [HttpPost]
        [Route("Products/{page?}/{category?}")]
        public async Task<IActionResult> Products(BrowseProductInputModel model)
        {
            if (!ModelState.IsValid)
            {
                return RedirectToAction(nameof(Index));
            }

            var products = await productCatalogService
                .GetProducts(model.SearchString)
                .ByCategory(model.Category)
                .ByManufacturer(model.ManufacturerIds)
                .FilterBySpecification(model.SpecificationIds)
                .Order(model.SortOrder)
                .Pagination(model.Page)
                .ToList<ProductExtendedModel>();
            
            foreach (var product in products)
            {
                product.Specifications = product.Specifications.DistinctBy(x => x.Name).ToList();
            }

            var paginationModel = new PaginationModel
            {
                Page = model.Page,
                PageSize = this.productCatalogService.PageCount
            };
            var productListingViewModel = new ProductListViewModel()
            {
                Products = products,
                Pagination = paginationModel,
            };

            return PartialView("_CatalogProductsListing", productListingViewModel);
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

            var productReviews = await reviewService.GetProductReviews(id);
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

        [HttpGet]
        [Route("/SearchProductsPartial")]
        public async Task<IActionResult> SearchProductsPartial(string searchString)
        {

            var products = await productCatalogService.GetProducts(searchString).ToList<ProductSimplifiedModel>();
            return PartialView("_SearchProductsPartial", products);
        }
    }
}
