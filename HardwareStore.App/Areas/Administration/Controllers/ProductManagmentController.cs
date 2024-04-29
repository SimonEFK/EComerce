namespace HardwareStore.App.Areas.Administration.Controllers
{
    using AutoMapper;
    using HardwareStore.App.Areas.Administration.Models.ProductManagment;
    using HardwareStore.App.Models.Product;
    using HardwareStore.App.Services.Data;
    using HardwareStore.App.Services.Data.Category;
    using HardwareStore.App.Services.Data.Products;
    using HardwareStore.App.Services.Data.Products.Create;
    using HardwareStore.App.Services.Data.Products.Edit;
    using Microsoft.AspNetCore.Mvc;


    public class ProductManagmentController : AdminBaseController
    {
        private readonly ICategoryDataService _categoryDataService;
        private readonly IProductDataService _productDataService;
        private readonly IManufacturerDataService _manufacturerDataService;
        private readonly IMapper mapper;
        public ProductManagmentController(ICategoryDataService categoryDataService, IProductDataService productDataService, IManufacturerDataService manufacturerDataService, IMapper mapper)
        {
            _categoryDataService = categoryDataService;
            _productDataService = productDataService;
            _manufacturerDataService = manufacturerDataService;
            this.mapper = mapper;
        }

        public async Task<IActionResult> Index()
        {
            var products = await _productDataService.GetAll<ProductSimplifiedModel>();
            return View(products.ToList().OrderByDescending(x=>x.Id));
        }

        [HttpGet]
        public async Task<IActionResult> CreateProduct()
        {
            var model = new CreateProductInputModel();
            model.CategoryList = await _categoryDataService.GetCategoriesAsTupleCollectionAsync();
            model.ManufacturerList = await _manufacturerDataService.GetManufacturersAsTupleCollectionAsync();

            return View(model);
        }


        [ValidateAntiForgeryToken]
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
            var productStatus = await _productDataService.CreateProductAsync<ProductSimplifiedModel>(createProductDto);

            if (productStatus.Success == false)
            {
                return Redirect($"/Error/ErrorHandler?errormessage={productStatus.ErrorMessage}");
            }

            return Redirect($"/ComponentDetail/{productStatus.Data.Id}");
        }

        [HttpGet]
        public async Task<IActionResult> EditProduct(int id)
        {
            var product = await _productDataService.GetProductById<EditProductDTO>(id);
            var model = mapper.Map<EditProductInputModel>(product);
            model.CategoryList = await _categoryDataService.GetCategoriesAsTupleCollectionAsync();
            model.ManufacturerList = await _manufacturerDataService.GetManufacturersAsTupleCollectionAsync();
            return View(model);
        }

        [ValidateAntiForgeryToken]
        [HttpPost]
        public async Task<IActionResult> EditProduct(int id, EditProductInputModel model)
        {
            if (!ModelState.IsValid)
            {

                model.CategoryList = await _categoryDataService.GetCategoriesAsTupleCollectionAsync();
                model.ManufacturerList = await _manufacturerDataService.GetManufacturersAsTupleCollectionAsync();
                return View(model);

            }
            var editProductDto = mapper.Map<EditProductDTO>(model);
            var result = await _productDataService.EditProductAsync<ProductSimplifiedModel>(editProductDto);
            if (result.Success == false)
            {
                return Redirect($"/Error/ErrorHandler?errorMessage={result.ErrorMessage}");
            }
            return Redirect($"/Administration/ProductManagment/EditProduct/{id}");
        }

        [ValidateAntiForgeryToken]
        [HttpPost]
        public async Task<IActionResult> RemoveSpecification(int id, SpecificationValueInputModel model)
        {
            if (!ModelState.IsValid)
            {
                return Redirect($"/Administration/ProductManagment/EditProduct/{id}");

            }
            await _productDataService.RemoveSpecificationAsync(id, model.ValueId);
            return Redirect($"/Administration/ProductManagment/EditProduct/{id}");
        }

        [ValidateAntiForgeryToken]
        [HttpPost]
        public async Task<IActionResult> AddSpecification(int id, SpecificationValueInputModel model)
        {
            if (!ModelState.IsValid)
            {
                return Redirect($"/Error/ErrorHandler");

            }
            var result = await _productDataService.AddSpecificationAsync(id, model.ValueId);
            if (result.Success == false)
            {
                return Redirect($"/Error/ErrorHandler?errorMessage={result.ErrorMessage}");

            }
            return Redirect($"/Administration/ProductManagment/EditProduct/{id}");
        }

        [ValidateAntiForgeryToken]
        [HttpPost]
        public async Task<IActionResult> AddImage(int id, AddImageInputModel imageModel)
        {
            if (!ModelState.IsValid)
            {
                return Redirect($"/Administration/ProductManagment/EditProduct/{id}");

            }
            var result = await _productDataService.AddImageAsync(id, imageModel.ImageUrl);
            if (result.Success == false)
            {
                return Redirect($"/Error/ErrorHandler?errorMessage={result.ErrorMessage}");

            }
            return Redirect($"/Administration/ProductManagment/EditProduct/{id}");
        }

        [ValidateAntiForgeryToken]
        [HttpPost]
        public async Task<IActionResult> RemoveImage([FromRoute] int id, RemoveImageInputModel imageModel)
        {
            if (!ModelState.IsValid)
            {
                return Redirect($"/Error/ErrorHandler");

            }
            var result = await _productDataService.RemoveImageAsync(id, imageModel.ImageId);
            if (result.Success == false)
            {
                return Redirect($"/Error/ErrorHandler?errorMessage={result.ErrorMessage}");

            }
            return Redirect($"/Administration/ProductManagment/EditProduct/{id}");
        }
    }
}
