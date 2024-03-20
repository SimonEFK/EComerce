﻿namespace HardwareStore.App.Areas.Administration.Controllers
{
    using AutoMapper;
    using HardwareStore.App.Areas.Administration.Models.ProductManagment;
    using HardwareStore.App.Models.Product;
    using HardwareStore.App.Services.Data;
    using HardwareStore.App.Services.Data.Category;
    using HardwareStore.App.Services.Data.Products;
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
        private IMapper mapper;
        public ProductManagmentController(ICategoryDataService categoryDataService, IProductDataService productDataService, IManufacturerDataService manufacturerDataService, IMapper mapper, IProductSpecificationService productSpecificationService)
        {
            _categoryDataService = categoryDataService;
            _productDataService = productDataService;
            _manufacturerDataService = manufacturerDataService;
            this.mapper = mapper;
            _productSpecificationService = productSpecificationService;
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
            var model = new EditProductInputModel();
            model.Id = product.Id;
            model.Name = product.Name;
            model.NameDetailed = product.NameDetailed;
            model.CategoryId = product.CategoryId;
            model.ManufacturerId = product.ManufacturerId;
            model.Specifications = product.Specifications.ToList();
            model.CategoryList = await _categoryDataService.GetCategoriesAsTupleCollectionAsync();
            model.ManufacturerList = await _manufacturerDataService.GetManufacturersAsTupleCollectionAsync();
            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> RemoveSpecification(int id,int valueId)
        {
            await _productSpecificationService.RemoveSpecification(id, valueId);
            return Redirect($"/Administration/ProductManagment/EditProduct/{id}");
        }
        [HttpGet]
        public async Task<IActionResult> AddSpecification(int id, int valueId)
        {
            await _productSpecificationService.AddSpecification(id, valueId);
            return Redirect($"/Administration/ProductManagment/EditProduct/{id}");
        }
    }
}
