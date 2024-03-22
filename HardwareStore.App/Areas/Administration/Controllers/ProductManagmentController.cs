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
    using HardwareStore.App.Services.Data.Products.ProductSpecifications;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    [Area("administration")]
    //[Authorize(Roles = "admin")]

    public class ProductManagmentController : Controller
    {
        private ICategoryDataService _categoryDataService;
        private IProductDataService _productDataService;
        private IManufacturerDataService _manufacturerDataService;
        private IProductSpecificationService _productSpecificationService;
        private IEditProductService _editProductService;
        private IMapper mapper;
        public ProductManagmentController(ICategoryDataService categoryDataService, IProductDataService productDataService, IManufacturerDataService manufacturerDataService, IMapper mapper, IProductSpecificationService productSpecificationService, IEditProductService editProductService)
        {
            _categoryDataService = categoryDataService;
            _productDataService = productDataService;
            _manufacturerDataService = manufacturerDataService;
            this.mapper = mapper;
            _productSpecificationService = productSpecificationService;
            _editProductService = editProductService;
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
                return BadRequest();
            }

            return Redirect($"/Catalog");
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

        [HttpPost]
        public async Task<IActionResult> EditProduct(int id, EditProductInputModel model)
        {
            if (!ModelState.IsValid)
            {
                if (ModelState.IsValid == false)
                {
                    model.CategoryList = await _categoryDataService.GetCategoriesAsTupleCollectionAsync();
                    model.ManufacturerList = await _manufacturerDataService.GetManufacturersAsTupleCollectionAsync();
                    return View(model);
                }

            }
            var editProductDto = mapper.Map<EditProductDTO>(model);
            var result = await _productDataService.EditProduct(editProductDto);
            if (result.Success == false)
            {
                return BadRequest();
            }
            return Redirect($"/Administration/ProductManagment/EditProduct/{id}");
        }

        [HttpPost]
        public async Task<IActionResult> RemoveSpecification(int id, SpecificationValueInputModel model)
        { 
            if (!ModelState.IsValid) 
            {
                return Redirect($"/Administration/ProductManagment/EditProduct/{id}");

            }
            await _productSpecificationService.RemoveSpecification(id, model.ValueId);
            return Redirect($"/Administration/ProductManagment/EditProduct/{id}");           
        }

        [HttpPost]
        public async Task<IActionResult> AddSpecification(int id, SpecificationValueInputModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();

            }
            await _productSpecificationService.AddSpecification(id, model.ValueId);
            return Redirect($"/Administration/ProductManagment/EditProduct/{id}");
        }

        [HttpPost]
        public async Task<IActionResult> AddImage(int id, AddImageInputModel imageModel)
        {
            if (!ModelState.IsValid)
            {
                return Redirect($"/Administration/ProductManagment/EditProduct/{id}");

            }
            await _editProductService.AddImage(id, imageModel.ImageUrl);
            return Redirect($"/Administration/ProductManagment/EditProduct/{id}");
        }
        [HttpPost]
        public async Task<IActionResult> RemoveImage([FromRoute]int id, RemoveImageInputModel imageModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();

            }
            await _editProductService.RemoveImage(id, imageModel.ImageId);
            return Redirect($"/Administration/ProductManagment/EditProduct/{id}");
        }
    }
}
