namespace HardwareStore.App.Areas.Administration.Controllers
{
    using HardwareStore.App.Areas.Administration.Models.ProductManagment;
    using HardwareStore.App.Services.Data;
    using HardwareStore.App.Services.Data.Products;
    using Microsoft.AspNetCore.Mvc;
    using Newtonsoft.Json;

    [Area("Administration")]
    public class ProductManagmentController : Controller
    {
        private ICategoryDataService _categoryDataService;
        private IProductDataService _productDataService;
        private IManufacturerDataService _manufacturerDataService;
        public ProductManagmentController(ICategoryDataService categoryDataService, IProductDataService productDataService, IManufacturerDataService manufacturerDataService)
        {
            _categoryDataService = categoryDataService;
            _productDataService = productDataService;
            _manufacturerDataService = manufacturerDataService;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> CreateProduct()
        {
            var model = new CreateProductViewModel();
            model.CategoryList = _categoryDataService.GetCategoriesAsTupleCollection();
            model.ManufacturerList = await _manufacturerDataService.GetManufacturersAsTupleCollectionAsync();


            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> CreateProduct(CreateProductViewModel model)
        {
            if (!ModelState.IsValid)
            {
                model.CategoryList = _categoryDataService.GetCategoriesAsTupleCollection();
                model.ManufacturerList = await _manufacturerDataService.GetManufacturersAsTupleCollectionAsync();
                return View(model);
            }
            var productStatus = await _productDataService.CreateProduct(model.ProductFormModel);
            if (productStatus.IsSucssessfull == false)
            {
                foreach (var message in productStatus.Messages)
                {
                    ModelState.AddModelError("", message);

                }
                model.CategoryList = _categoryDataService.GetCategoriesAsTupleCollection();
                model.ManufacturerList = await _manufacturerDataService.GetManufacturersAsTupleCollectionAsync();
                return View(model);
            }
            return Redirect($"/ComponentDetail/{productStatus.Id}");
        }
    }
}
