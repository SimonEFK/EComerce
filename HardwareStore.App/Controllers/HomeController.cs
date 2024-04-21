namespace HardwareStore.App.Controllers
{
    using HardwareStore.App.Models;
    using HardwareStore.App.Models.Category;
    using HardwareStore.App.Services.Catalog;
    using HardwareStore.App.Services.Data.Category;
    using Microsoft.AspNetCore.Mvc;
    using System.Diagnostics;

    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ICatalogService catalogService;
        private readonly ICategoryDataService categoryDataService;
        
        public HomeController(ILogger<HomeController> logger, ICatalogService catalogService, ICategoryDataService categoryDataService)
        {
            _logger = logger;
            this.catalogService = catalogService;
            this.categoryDataService = categoryDataService;           
        }

        public async Task<IActionResult> Index()
        {
            
            var products = await catalogService.GetLatestProductsAsync(8);
            var categories = await categoryDataService.GetCategoriesAsync<CategoryModel>();
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