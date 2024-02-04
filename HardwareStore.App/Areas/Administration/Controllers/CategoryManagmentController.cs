namespace HardwareStore.App.Areas.Administration.Controllers
{
    using HardwareStore.App.Areas.Administration.Models.CategoryManagment.Category;
    using HardwareStore.App.Areas.Administration.Models.CategoryManagment.Specifications;
    using HardwareStore.App.Data.Models;
    using HardwareStore.App.Services.Data;
    using Microsoft.AspNetCore.Mvc;
    using Newtonsoft.Json;
    using System.Text.Json;
    using System.Text.Json.Serialization;

    [Area("Administration")]
    public class CategoryManagmentController : Controller
    {
        private readonly ICategoryDataService _categoryDataService;

        public CategoryManagmentController(ICategoryDataService categoryDataService)
        {
            _categoryDataService = categoryDataService;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> CategoryList()
        {
            var categories = await _categoryDataService.GetCategories<CategoryViewModel>();
            var categoryCreateModel = new CategoryCreateModel();
            var categoryListViewModel = new CategoryListingViewModel()
            {
                Categories = categories.ToList(),
                CategoryFormModel = categoryCreateModel
            };
            return View(categoryListViewModel);
        }

        [HttpGet]
        public async Task<IActionResult> CategoryInfo(int Id)
        {
            var categoryInfoModel = await _categoryDataService.CategoryInfo(Id);
            var categoryFormModel = new CategoryEditModel
            {
                Id = categoryInfoModel.Id,
                Name = categoryInfoModel.CategoryName,
                ImageFilePath = categoryInfoModel.ImageFilePath,
                ImageUrl = categoryInfoModel.ImageUrl,
            };
            var categoryInfoViewModel = new CategoryInfoViewModel
            {
                CategoryFormModel = categoryFormModel,
                CategoryInfoModel = categoryInfoModel
            };
            return View(categoryInfoViewModel);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateCategory(CategoryCreateModel model)
        {
            if (!ModelState.IsValid)
            {
                var categories = await _categoryDataService.GetCategories<CategoryViewModel>();
                var categoryListViewModel = new CategoryListingViewModel()
                {
                    Categories = categories.ToList(),
                    CategoryFormModel = model
                };
                return View("CategoryList", categoryListViewModel);
            }
            var result = await _categoryDataService.CreateCategory(model);

            if (!result.IsSucssessfull)
            {
                foreach (var item in result.Messages)
                {
                    ModelState.AddModelError("", item);
                }
                var categories = await _categoryDataService.GetCategories<CategoryViewModel>();
                var categoryListViewModel = new CategoryListingViewModel()
                {
                    Categories = categories.ToList(),
                    CategoryFormModel = model
                };
                return View("CategoryList", categoryListViewModel);
            }
            return Redirect("/Administration/CategoryManagment/CategoryList");
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditCategory(int id, CategoryEditModel model)
        {
            if (!ModelState.IsValid)
            {
                return PartialView("_CategoryEditPartial", model);
            }
            await _categoryDataService.EditCategory(model.Id, model.Name, model.ImageUrl);
            return PartialView("_CategoryEditPartial", model);
        }

        [HttpGet]
        public IActionResult CreateSpecification()
        {
            var model = new SpecificationCreateModel();
            return PartialView("_CreateSpecificationForm", model);
        }
        [HttpPost]
        public async Task<IActionResult> CreateSpecification(int Id, SpecificationCreateModel model)
        {

            if (!ModelState.IsValid)
            {
                return PartialView("_CreateSpecificationForm", model);
            }
            var result = await _categoryDataService.CreateSpecification(Id, model);

            if (!result.IsSucssessfull)
            {

                ;
            }
            return Ok();
        }
    }
}
