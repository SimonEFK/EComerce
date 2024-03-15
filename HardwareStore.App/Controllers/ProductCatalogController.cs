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
    using HardwareStore.App.Services.ProductReview;
    using Microsoft.AspNetCore.Mvc;

    [Route("/Catalog")]
    public class ProductCatalogController : Controller
    {
        private ICatalogService productCatalogService;
        private IProductReviewService reviewService;
        private ICategoryDataService categoryDataService;

        public ProductCatalogController(ICatalogService productCatalogService, IProductReviewService reviewService, ICategoryDataService categoryDataService)
        {
            this.productCatalogService = productCatalogService;
            this.reviewService = reviewService;
            this.categoryDataService = categoryDataService;
        }

        public async Task<IActionResult> Index()
        {
            var categories = await categoryDataService.GetCategories<CategoryModel>();
            return View(categories.Where(x => x.ProductsCount > 0)
                .OrderByDescending(x => x.Name)
                .ToList());
        }

        [HttpGet]
        [Route("Products/{category?}")]
        public async Task<IActionResult> Products(BrowseProductInputModel model)
        {

            if (!ModelState.IsValid)
            {
                return RedirectToAction("Index");
            }

            var catalogModel = await productCatalogService
                .GetProducts(model.SearchString)
                .ByCategory(model.Category)
                .ByManufacturer(model.ManufacturerIds)
                .FilterBySpecification(model.SpecificationIds)
                .Order(model.SortOrder)
                .Pagination(model.Page)
                .ToCatalogModel();

            ViewData["sortOrder"] = model.SortOrder;
            if (model.Category is not null)
            {
                var category = ViewData["Category"] = model.Category;
            }
            if (model.SearchString is not null)
            {
                ViewData["SearchString"] = model.SearchString;
            }
            if (model.SpecificationIds.Count > 0)
            {
                ViewData["selectedSpecs"] = model.SpecificationIds.SelectMany(x => x.Value).ToList();
            }
            if (model.ManufacturerIds.Count > 0)
            {
                ViewData["selectedManufacturers"] = model.ManufacturerIds.ToList();
            }

            var filterModel = new FilterModel
            {
                Specifications = catalogModel.SpecificationFilters,
                Manufacturers = catalogModel.Manufacturers,
                SortOrder = catalogModel.SortOrder
            };           
            var paginationModel = new PaginationModel
            {
                Page = model.Page,
                PageSize = catalogModel.PageSize
            };
            var catalogViewModel = new ProductCatalogModel
            {
                Products = catalogModel.Products,
                Pagination = paginationModel,
                ProductFilters = filterModel
            };

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
            return PartialView("_SearchProductsPartial",products);
        }
    }
}
