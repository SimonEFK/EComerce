namespace HardwareStore.App.Areas.Administration.Controllers
{
    using HardwareStore.App.Areas.Administration.Models;
    using HardwareStore.App.Services.Data;
    using Microsoft.AspNetCore.Mvc;

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
            await _categoryDataService.CreateCategory(categoryFormModel);
            return RedirectToAction(nameof(CategoryList));
        }
    }
}
