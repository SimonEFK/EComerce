namespace HardwareStore.App.Areas.Administration.Controllers
{
    using HardwareStore.App.Areas.Administration.Models;
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
            return View(categories.ToList());
        }

        [HttpGet]
        public IActionResult CreateCategory()
        {
            var categoryFormModel = new CategoryFormModel();

            return PartialView("_CreateCategoryPartial", categoryFormModel);
        }

        [HttpPost]

        public async Task<IActionResult> CreateCategory(CategoryFormModel categoryFormModel)
        {
            if (!ModelState.IsValid)
            {
                return View("CategoryList.cshtml", categoryFormModel);
            }
            var status = await _categoryDataService.CreateCategory(categoryFormModel);
            if (!status.IsSucssessfull)
            {
                var categories = await _categoryDataService.GetCategories<CategoryViewModel>();
                ViewData["ErrorMessages"] = status.Messages;
                return View("CategoryList", categories);

            }
            return Redirect("categorylist");
        }

        [HttpGet]
        public async Task<IActionResult> CategoryInfo(int Id)
        {
            var categoryInfoModel = await _categoryDataService.CategoryInfo(Id);
            var categoryFormModel = new CategoryEditModel();
            var categoryInfoViewModel = new CategoryInfoViewModel
            {
                CategoryFormModel = categoryFormModel,
                CategoryInfoModel = categoryInfoModel
            };
            return View(categoryInfoViewModel);
        }

        [HttpPost]
        public async Task<IActionResult> EditCategory(int id, CategoryEditModel model)
        {
            if (!ModelState.IsValid)
            {
                var categoryInfoModel = await _categoryDataService.CategoryInfo(id);
                var categoryFormModel = model;
                var categoryInfoViewModel = new CategoryInfoViewModel
                {
                    CategoryFormModel = categoryFormModel,
                    CategoryInfoModel = categoryInfoModel
                };
                return View(categoryInfoViewModel);
            }
            await _categoryDataService.EditCategory(id, model.Name, model.ImageUrl);
            return Redirect($"/Administration/CategoryManagment/CategoryInfo/{id}");
        }
    }
}
