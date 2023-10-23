namespace HardwareStore.App.Controllers
{
    using HardwareStore.App.Models;
    using HardwareStore.App.Models.Product;
    using HardwareStore.App.Models.ProductCatalog;
    using HardwareStore.App.Services.Data.Products;
    using Microsoft.AspNetCore.Mvc;
    [Route("catalog/{action=index}")]
    public class ProductCatalogController : Controller
    {
        private IProductDataService productDataService;

        public ProductCatalogController(IProductDataService productDataService)
        {
            this.productDataService = productDataService;
        }

        public IActionResult Index()
        {
            ;
            return View();
        }


        [HttpGet]
        [Route("{category}/{page?}")]
        public async Task<IActionResult> Products(string? category, int page = 1)
        {
            var products = await this.productDataService.GetProducts<ProductExtendedModel>(category, page);
            var paginationModel = new PaginationModel
            {
                Page = page,
                PageSize = this.productDataService.PageSize
            };
            var catalogModel = new ProductCatalogModel
            {
                Products = products,
                Pagination = paginationModel
            };
            return View(catalogModel);
        }
    }
}
