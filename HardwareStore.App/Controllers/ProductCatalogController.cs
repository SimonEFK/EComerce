namespace HardwareStore.App.Controllers
{
    using HardwareStore.App.Models.Product;
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
        [Route("{category}")]
        public async Task<IActionResult> Products(string category)
        {
            var products = await this.productDataService.GetProducts<ProductExtendedModel>(category);
            return View(products);
        }
    }
}
