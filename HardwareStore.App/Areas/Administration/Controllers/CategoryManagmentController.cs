namespace HardwareStore.App.Areas.Administration.Controllers
{
    using HardwareStore.App.Areas.Administration.Models.CategoryManagment.Category;
    using HardwareStore.App.Areas.Administration.Models.CategoryManagment.Specifications;
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

        public async Task<IActionResult> Index()
        {
            var categories = await _categoryDataService.GetCategories<CategoryViewModel>();
            var createCategoryInputModel = new CreateCategoryInputModel();
            var categoryListViewModel = new CategoryListingViewModel()
            {
                Categories = categories.ToList(),
                CreateCategoryInputModel = createCategoryInputModel
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
                CategoryEditModel = categoryEditModel,
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
                Essential = specificationInfo.InfoLevel == "Essential" ? true : false,
                CategoryId = specificationInfo.CategoryId,

            };
            var valueForm = new SpecificationValueCreateModel()
            {
                CategoryId = specificationInfo.CategoryId,
                SpecificationId = specificationInfo.SpecificationId,
            };
            var valueEditForm = new SpecificationValueEditModel
            {
                SpecificationId = specificationInfo.SpecificationId,
                CategoryId = specificationInfo.CategoryId
            };
            var specificationViewModel = new SpecificationInfoViewModel
            {
                EditFormModel = editForm,
                ValueEditFormModel = valueEditForm,
                Values = specificationInfo.Values.OrderBy(x => x.Value).ToList(),
                ValueCreateFormModel = valueForm
            };
            return View(specificationViewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateCategory(CreateCategoryInputModel createCategoryInputModel)
        {

            if (!ModelState.IsValid)
            {
                ViewData["FormCollapse"] = "show";
                var categories = await _categoryDataService.GetCategories<CategoryViewModel>();
                var categoryListViewModel = new CategoryListingViewModel()
                {
                    Categories = categories.ToList(),
                    CreateCategoryInputModel = createCategoryInputModel
                };
                return View("CategoryList", categoryListViewModel);
            }
            var result = await _categoryDataService.CreateCategory(createCategoryInputModel.Name, createCategoryInputModel.Image);

            if (!result.Success)
            {
                foreach (var item in result.ErrorMessage)
                {
                    ModelState.AddModelError("", item);
                }
                ViewData["FormCollapse"] = "show";
                var categories = await _categoryDataService.GetCategories<CategoryViewModel>();
                var categoryListViewModel = new CategoryListingViewModel()
                {
                    Categories = categories.ToList(),
                    CreateCategoryInputModel = createCategoryInputModel
                };
                return View("CategoryList", categoryListViewModel);
            }
            return Redirect("/Administration/CategoryManagment");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditCategory(CategoryEditModel categoryEditModel)
        {
            if (!ModelState.IsValid)
            {
                var categoryInfoModel = await _categoryDataService.CategoryInfo(categoryEditModel.Id);
                var specificationCreateModel = new SpecificationCreateModel
                {
                    CategoryId = categoryInfoModel.Id,
                };
                var categoryInfoViewModel = new CategoryInfoViewModel
                {
                    CategoryEditModel = categoryEditModel,
                    CategoryInfoModel = categoryInfoModel,
                    SpecificationCreateForm = specificationCreateModel
                };
                return View("CategoryInfo", categoryInfoViewModel);
            }
            var result = await _categoryDataService.EditCategory(
                categoryEditModel.Id,
                categoryEditModel.Name,
                categoryEditModel.ImageUrl,
                categoryEditModel.ImageFilePath);

            if (!result.Success)
            {
                foreach (var message in result.ErrorMessage)
                {
                    ModelState.AddModelError("", message);

                }
                var categoryInfoModel = await _categoryDataService.CategoryInfo(categoryEditModel.Id);
                var specificationCreateModel = new SpecificationCreateModel
                {
                    CategoryId = categoryInfoModel.Id,
                };
                var categoryInfoViewModel = new CategoryInfoViewModel
                {
                    CategoryEditModel = categoryEditModel,
                    CategoryInfoModel = categoryInfoModel,
                    SpecificationCreateForm = specificationCreateModel
                };
                return View(categoryInfoViewModel);
            }
            return Redirect($"/Administration/CategoryManagment/CategoryInfo/{categoryEditModel.Id}");
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
            var categoryInfoViewModel = new CategoryInfoViewModel
            {
                CategoryEditModel = categoryEditModel,
                CategoryInfoModel = categoryInfoModel,
                SpecificationCreateForm = specificationCreateModel
            };

            if (!ModelState.IsValid)
            {
                ViewData["FormCollapse"] = "show";
                return View("CategoryInfo", categoryInfoViewModel);
            }
            var result = await _categoryDataService.CreateSpecification(specificationCreateModel);

            if (!result.Success)
            {
                foreach (var item in result.ErrorMessage)
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
            if (!result.Success)
            {
                foreach (var message in result.ErrorMessage)
                {
                    ModelState.AddModelError("", message);
                }
                return View("SpecificationInfo", specificationViewModel);

            }
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
            if (result.Success == false)
            {
                foreach (var message in result.ErrorMessage)
                {
                    ModelState.AddModelError("", message);
                    return View("SpecificationInfo", specificationViewModel);
                }
            }

            return Redirect($"/Administration/CategoryManagment/SpecificationInfo/{specificationInfo.SpecificationId}");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]

        public async Task<IActionResult> EditSpecificationValue(SpecificationValueEditModel valueEditFormModel)
        {
            var specificationInfo = await _categoryDataService.SpecificationInfo(valueEditFormModel.SpecificationId);
            var editForm = new SpecificationEditModel
            {
                Id = specificationInfo.SpecificationId,
                Name = specificationInfo.Name,
                Filter = specificationInfo.Filter,
                Essential = specificationInfo.InfoLevel == "Essential" ? true : false,
                CategoryId = specificationInfo.CategoryId,

            };
            var valueForm = new SpecificationValueCreateModel()
            {
                CategoryId = specificationInfo.CategoryId,
                SpecificationId = specificationInfo.SpecificationId,
            };
            var valueEditForm = new SpecificationValueEditModel
            {
                SpecificationId = specificationInfo.SpecificationId
            };
            var specificationViewModel = new SpecificationInfoViewModel
            {
                EditFormModel = editForm,
                ValueEditFormModel = valueEditForm,
                Values = specificationInfo.Values.OrderBy(x => x.Value).ToList(),
                ValueCreateFormModel = valueForm
            };

            if (!ModelState.IsValid)
            {
                return View("SpcificationInfo", specificationViewModel);
            }
            var result = await _categoryDataService.EditSpecificationValue(valueEditFormModel);
            if (!result.Success)
            {
                foreach (var message in result.ErrorMessage)
                {
                    ModelState.AddModelError("", message);
                }
                return View("SpecificationInfo", specificationViewModel);
            }
            return Redirect($"/Administration/CategoryManagment/SpecificationInfo/{valueEditFormModel.SpecificationId}");
        }
    }
}
