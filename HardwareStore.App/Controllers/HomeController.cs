namespace HardwareStore.App.Controllers
{
    using HardwareStore.App.Models;
    using HardwareStore.App.Models.Category;
    using HardwareStore.App.Services;
    using HardwareStore.App.Services.Catalog;
    using HardwareStore.App.Services.Data;
    using Microsoft.AspNetCore.Mvc;
    using System.Diagnostics;

    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ICatalogService catalogService;
        private readonly ICategoryDataService categoryDataService;
        private readonly IProductDiscountService productDiscountService;


        public HomeController(ILogger<HomeController> logger, ICatalogService catalogService, ICategoryDataService categoryDataService, IProductDiscountService productDiscountService)
        {
            _logger = logger;
            this.catalogService = catalogService;
            this.categoryDataService = categoryDataService;
            this.productDiscountService = productDiscountService;
        }

        public async Task<IActionResult> Index()
        {
            //var result = productDiscountService.GetProductPrice(10).DecreaseByPercentage(10);
            var products = await catalogService.GetLatestProductsAsync(8);
            var categories = await categoryDataService.GetCategories<CategoryModel>();
            var homeIndexViewModel = new HomeIndexViewModel
            {
                Categories = categories,
                Products = products
            };
            return View(homeIndexViewModel);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}