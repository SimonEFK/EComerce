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
            var categoryEditModel = new CategoryEditModel
            {
                Id = categoryInfoModel.Id,
                Name = categoryInfoModel.CategoryName,
                ImageFilePath = categoryInfoModel.ImageFilePath,
                ImageUrl = categoryInfoModel.ImageUrl,
            };
            var specificationCreateModel = new SpecificationCreateModel
            {
                CategoryId = categoryInfoModel.Id,
            };
            var categoryInfoViewModel = new CategoryInfoViewModel
            {
                CategoryFormModel = categoryEditModel,
                CategoryInfoModel = categoryInfoModel,
                SpecificationCreateForm = specificationCreateModel
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
                ViewData["FormCollapse"] = "show";
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
                ViewData["FormCollapse"] = "show";
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


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateSpecification(SpecificationCreateModel model)
        {

            if (!ModelState.IsValid)
            {
                var categoryInfoModel = await _categoryDataService.CategoryInfo(model.CategoryId);
                var categoryEditModel = new CategoryEditModel
                {
                    Id = categoryInfoModel.Id,
                    Name = categoryInfoModel.CategoryName,
                    ImageFilePath = categoryInfoModel.ImageFilePath,
                    ImageUrl = categoryInfoModel.ImageUrl,
                };
                var specificationCreateModel = new SpecificationCreateModel
                {
                    CategoryId = categoryInfoModel.Id,
                };
                var categoryInfoViewModel = new CategoryInfoViewModel
                {
                    CategoryFormModel = categoryEditModel,
                    CategoryInfoModel = categoryInfoModel
                };
                ViewData["FormCollapse"] = "show";
                return View("CategoryInfo", categoryInfoViewModel);
            }
            var result = await _categoryDataService.CreateSpecification(model);

            if (!result.IsSucssessfull)
            {
                foreach (var item in result.Messages)
                {
                    ModelState.AddModelError("", item);
                }
                var categoryInfoModel = await _categoryDataService.CategoryInfo(model.CategoryId);
                var categoryEditModel = new CategoryEditModel
                {
                    Id = categoryInfoModel.Id,
                    Name = categoryInfoModel.CategoryName,
                    ImageFilePath = categoryInfoModel.ImageFilePath,
                    ImageUrl = categoryInfoModel.ImageUrl,
                };
                var specificationCreateModel = new SpecificationCreateModel
                {
                    CategoryId = categoryInfoModel.Id,
                };
                var categoryInfoViewModel = new CategoryInfoViewModel
                {
                    CategoryFormModel = categoryEditModel,
                    CategoryInfoModel = categoryInfoModel,
                    SpecificationCreateForm = specificationCreateModel
                };
                ViewData["FormCollapse"] = "show";
                return View("CategoryInfo", categoryInfoViewModel);
            }
            return Redirect($"/Administration/CategoryManagment/CategoryInfo/{model.CategoryId}");
        }
    }
}
