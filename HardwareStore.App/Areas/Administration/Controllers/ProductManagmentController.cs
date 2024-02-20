namespace HardwareStore.App.Areas.Administration.Controllers
{
    using AutoMapper;
    using HardwareStore.App.Areas.Administration.Models.ProductManagment;
    using HardwareStore.App.Services.Data;
    using HardwareStore.App.Services.Data.Products;
    using HardwareStore.App.Services.Models;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using Newtonsoft.Json;

    [Area("Administration")]
    [Authorize(Roles = "admin")]

    public class ProductManagmentController : Controller
    {
        private ICategoryDataService _categoryDataService;
        private IProductDataService _productDataService;
        private IManufacturerDataService _manufacturerDataService;
        private IMapper mapper;
        public ProductManagmentController(ICategoryDataService categoryDataService, IProductDataService productDataService, IManufacturerDataService manufacturerDataService, IMapper mapper)
        {
            _categoryDataService = categoryDataService;
            _productDataService = productDataService;
            _manufacturerDataService = manufacturerDataService;
            this.mapper = mapper;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> CreateProduct()
        {
            var model = new CreateProductInputModel();
            model.CategoryList = await _categoryDataService.GetCategoriesAsTupleCollectionAsync();
            model.ManufacturerList = await _manufacturerDataService.GetManufacturersAsTupleCollectionAsync();

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> CreateProduct(CreateProductInputModel createProductInputModel)
        {
            if (ModelState.IsValid == false)
            {
                createProductInputModel.CategoryList = await _categoryDataService.GetCategoriesAsTupleCollectionAsync();
                createProductInputModel.ManufacturerList = await _manufacturerDataService.GetManufacturersAsTupleCollectionAsync();
                return View(createProductInputModel);
            }

            var createProductDto = mapper.Map<CreateProductDTO>(createProductInputModel);
            var productStatus = await _productDataService.CreateProduct(createProductDto);
            if (productStatus.Success == false)
            {
                foreach (var message in productStatus.ErrorMessage)
                {
                    ModelState.AddModelError("", message);

                }
                createProductInputModel.CategoryList = await _categoryDataService.GetCategoriesAsTupleCollectionAsync();
                createProductInputModel.ManufacturerList = await _manufacturerDataService.GetManufacturersAsTupleCollectionAsync();
                return View(createProductInputModel);
            }
            return Redirect($"/Catalog");
        }
    }
}
