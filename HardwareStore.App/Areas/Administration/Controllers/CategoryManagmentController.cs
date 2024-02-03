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
