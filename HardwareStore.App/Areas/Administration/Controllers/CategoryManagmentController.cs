namespace HardwareStore.App.Areas.Administration.Controllers
{
    using HardwareStore.App.Areas.Administration.Models.CategoryManagment.Category;
    using HardwareStore.App.Areas.Administration.Models.CategoryManagment.Specifications;
    using HardwareStore.App.Services.Data;
    using Microsoft.AspNetCore.Components.Forms;
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

        [HttpGet]
        public async Task<IActionResult> SpecificationInfo(int id)
        {
            var specificationInfo = await _categoryDataService.SpecificationInfo(id);
            var editForm = new SpecificationEditModel
            {
                Id = specificationInfo.SpecificationId,
                Name = specificationInfo.Name,
                Filter = specificationInfo.Filter,
                Essential = specificationInfo.InfoLevel == "Essential" ? true : false

            };
            var valueForm = new SpecificationValueCreateModel()
            {
                SpecificationId = specificationInfo.SpecificationId,
            };
            var specificationViewModel = new SpecificationInfoViewModel
            {
                EditFormModel = editForm,
                Values = specificationInfo.Values.OrderBy(x => x.Value).ToList(),
                ValueCreateFormModel = valueForm
            };
            return View(specificationViewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateCategory(CategoryCreateModel categoryCreateModel)
        {
            var categories = await _categoryDataService.GetCategories<CategoryViewModel>();
            var categoryListViewModel = new CategoryListingViewModel()
            {
                Categories = categories.ToList(),
                CategoryFormModel = categoryCreateModel
            };

            if (!ModelState.IsValid)
            {
                ViewData["FormCollapse"] = "show";
                return View("CategoryList", categoryListViewModel);
            }
            var result = await _categoryDataService.CreateCategory(categoryCreateModel);

            if (!result.IsSucssessfull)
            {
                foreach (var item in result.Messages)
                {
                    ModelState.AddModelError("", item);
                }

                ViewData["FormCollapse"] = "show";
                return View("CategoryList", categoryListViewModel);
            }
            return Redirect("/Administration/CategoryManagment/CategoryList");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditCategory(int id, CategoryEditModel categoryEditModel)
        {
            if (!ModelState.IsValid)
            {
                return PartialView("_CategoryEditFormPartial", categoryEditModel);
            }
            await _categoryDataService.EditCategory(categoryEditModel.Id, categoryEditModel.Name, categoryEditModel.ImageUrl);
            return PartialView("_CategoryEditFormPartial", categoryEditModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateSpecification(SpecificationCreateModel specificationCreateModel)
        {
            var categoryInfoModel = await _categoryDataService.CategoryInfo(specificationCreateModel.CategoryId);
            var categoryEditModel = new CategoryEditModel
            {
                Id = categoryInfoModel.Id,
                Name = categoryInfoModel.CategoryName,
                ImageFilePath = categoryInfoModel.ImageFilePath,
                ImageUrl = categoryInfoModel.ImageUrl,
            };
            var specificationModel = new SpecificationCreateModel
            {
                CategoryId = categoryInfoModel.Id,
            };
            var categoryInfoViewModel = new CategoryInfoViewModel
            {
                CategoryFormModel = categoryEditModel,
                CategoryInfoModel = categoryInfoModel,
                SpecificationCreateForm = specificationCreateModel
            };

            if (!ModelState.IsValid)
            {
                ViewData["FormCollapse"] = "show";
                return View("CategoryInfo", categoryInfoViewModel);
            }
            var result = await _categoryDataService.CreateSpecification(specificationCreateModel);

            if (!result.IsSucssessfull)
            {
                foreach (var item in result.Messages)
                {
                    ModelState.AddModelError("", item);
                }

                ViewData["FormCollapse"] = "show";
                return View("CategoryInfo", categoryInfoViewModel);
            }
            return Redirect($"/Administration/CategoryManagment/CategoryInfo/{specificationCreateModel.CategoryId}");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditSpecification(SpecificationEditModel specificationEditModel)
        {
            var specificationInfo = await _categoryDataService.SpecificationInfo(specificationEditModel.Id);
            var specificationViewModel = new SpecificationInfoViewModel
            {
                EditFormModel = specificationEditModel,
                Values = specificationInfo.Values.OrderBy(x => x.Value).ToList()
            };
            if (!ModelState.IsValid)
            {
                return View("SpecificationInfo", specificationViewModel);
            }
            var result = await _categoryDataService.EditSpecification(specificationEditModel);
            return Redirect($"/Administration/CategoryManagment/SpecificationInfo/{specificationEditModel.Id}");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateSpecificationValue(SpecificationValueCreateModel valueCreateFormModel)
        {
            var specificationInfo = await _categoryDataService.SpecificationInfo(valueCreateFormModel.SpecificationId);
            var editForm = new SpecificationEditModel
            {
                Id = specificationInfo.SpecificationId,
                Name = specificationInfo.Name,
                Filter = specificationInfo.Filter,
                Essential = specificationInfo.InfoLevel == "Essential" ? true : false

            };
            var valueForm = valueCreateFormModel;
            var specificationViewModel = new SpecificationInfoViewModel
            {
                EditFormModel = editForm,
                Values = specificationInfo.Values.OrderBy(x => x.Value).ToList(),
                ValueCreateFormModel = valueCreateFormModel,
            };

            if (!ModelState.IsValid)
            {
                return View("SpecificationInfo", specificationViewModel);
            }
            var result = await _categoryDataService.CreateSpecificationValue(valueCreateFormModel);
            if (result.IsSucssessfull == false)
            {
                foreach (var message in result.Messages)
                {
                    ModelState.AddModelError("", message);
                    return View("SpecificationInfo", specificationViewModel);
                }
            }

            return Redirect($"/Administration/CategoryManagment/SpecificationInfo/{specificationInfo.SpecificationId}");
        }
    }
}
