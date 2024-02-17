namespace HardwareStore.App.Areas.Administration.Controllers
{
    using HardwareStore.App.Areas.Administration.Models.CategoryManagment.Category;
    using HardwareStore.App.Areas.Administration.Models.CategoryManagment.Specifications;
    using HardwareStore.App.Services.Data;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    [Area("Administration")]
    [Authorize(Roles = "Admin")]

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
            var categoryEditModel = new CategoryEditInputModel
            {
                Id = categoryInfoModel.Id,
                Name = categoryInfoModel.CategoryName,
                ImageFilePath = categoryInfoModel.ImageFilePath,
                ImageUrl = categoryInfoModel.ImageUrl,
            };
            var specificationCreateModel = new SpecificationCreateInputModel
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
            var editForm = new SpecificationCreateInputModel
            {
                Name = specificationInfo.Name,
                Filter = specificationInfo.Filter,
                Essential = specificationInfo.InfoLevel == "Essential" ? true : false,
                CategoryId = specificationInfo.CategoryId,
                Id = specificationInfo.SpecificationId

            };
            var valueForm = new SpecificationValueCreateInputModel()
            {
                CategoryId = specificationInfo.CategoryId,
                SpecificationId = specificationInfo.SpecificationId,
            };
            var valueEditForm = new SpecificationValueCreateInputModel
            {
                SpecificationId = specificationInfo.SpecificationId,
                CategoryId = specificationInfo.CategoryId
            };
            var specificationViewModel = new SpecificationInfoViewModel
            {
                SpecificationCreateInputModel = editForm,
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
                return View("Index", categoryListViewModel);
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
                return View("Index", categoryListViewModel);
            }
            return Redirect("/Administration/CategoryManagment");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditCategory(CategoryEditInputModel categoryEditModel)
        {
            if (!ModelState.IsValid)
            {
                var categoryInfoModel = await _categoryDataService.CategoryInfo(categoryEditModel.Id);
                var specificationCreateModel = new SpecificationCreateInputModel
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
                var specificationCreateModel = new SpecificationCreateInputModel
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
        public async Task<IActionResult> CreateSpecification(SpecificationCreateInputModel specificationCreateModel)
        {

            if (!ModelState.IsValid)
            {
                var categoryInfoModel = await _categoryDataService.CategoryInfo(specificationCreateModel.CategoryId ?? 0);
                var categoryEditModel = new CategoryEditInputModel
                {
                    Id = categoryInfoModel.Id,
                    Name = categoryInfoModel.CategoryName,
                    ImageFilePath = categoryInfoModel.ImageFilePath,
                    ImageUrl = categoryInfoModel.ImageUrl
                };
                var categoryInfoViewModel = new CategoryInfoViewModel
                {
                    CategoryEditModel = categoryEditModel,
                    CategoryInfoModel = categoryInfoModel,
                    SpecificationCreateForm = specificationCreateModel
                };
                ViewData["FormCollapse"] = "show";
                return View("CategoryInfo", categoryInfoViewModel);
            }
            var result = await _categoryDataService.CreateSpecification(specificationCreateModel.CategoryId ?? 0, specificationCreateModel.Name, specificationCreateModel.Filter, specificationCreateModel.Essential);

            if (!result.Success)
            {
                foreach (var item in result.ErrorMessage)
                {
                    ModelState.AddModelError("", item);
                }
                ViewData["FormCollapse"] = "show";
                var categoryInfoModel = await _categoryDataService.CategoryInfo(specificationCreateModel.CategoryId ?? 0);
                var categoryEditModel = new CategoryEditInputModel
                {
                    Id = categoryInfoModel.Id,
                    Name = categoryInfoModel.CategoryName,
                    ImageFilePath = categoryInfoModel.ImageFilePath,
                    ImageUrl = categoryInfoModel.ImageUrl
                };
                var categoryInfoViewModel = new CategoryInfoViewModel
                {
                    CategoryEditModel = categoryEditModel,
                    CategoryInfoModel = categoryInfoModel,
                    SpecificationCreateForm = specificationCreateModel
                };
                return View("CategoryInfo", categoryInfoViewModel);
            }
            return Redirect($"/Administration/CategoryManagment/CategoryInfo/{specificationCreateModel.CategoryId}");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditSpecification(int id, SpecificationCreateInputModel specificationEditModel)
        {

            if (!ModelState.IsValid)
            {
                var specificationInfo = await _categoryDataService.SpecificationInfo(id);
                var specificationViewModel = new SpecificationInfoViewModel
                {
                    SpecificationCreateInputModel = specificationEditModel,
                    Values = specificationInfo.Values.OrderBy(x => x.Value).ToList()
                };
                return View("SpecificationInfo", specificationViewModel);
            }

            var result = await _categoryDataService
                .EditSpecification(specificationEditModel.CategoryId ?? 0, id, specificationEditModel.Name, specificationEditModel.Filter, specificationEditModel.Essential);
            if (!result.Success)
            {
                foreach (var message in result.ErrorMessage)
                {
                    ModelState.AddModelError("", message);
                }
                var specificationInfo = await _categoryDataService.SpecificationInfo(id);
                var specificationViewModel = new SpecificationInfoViewModel
                {
                    SpecificationCreateInputModel = specificationEditModel,
                    Values = specificationInfo.Values.OrderBy(x => x.Value).ToList()
                };
                return View("SpecificationInfo", specificationViewModel);

            }
            return Redirect($"/Administration/CategoryManagment/SpecificationInfo/{specificationEditModel.Id}");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateSpecificationValue(SpecificationValueCreateInputModel ValueCreateFormModel)
        {
            var specificationInfo = await _categoryDataService.SpecificationInfo(ValueCreateFormModel.SpecificationId);

            if (!ModelState.IsValid)
            {
                var valueEditModel = new SpecificationCreateInputModel
                {
                    Id = specificationInfo.SpecificationId,
                    Name = specificationInfo.Name,
                    Filter = specificationInfo.Filter,
                    Essential = specificationInfo.InfoLevel == "Essential" ? true : false

                };
                var valueCreateModel = ValueCreateFormModel;
                var specificationViewModel = new SpecificationInfoViewModel
                {
                    SpecificationCreateInputModel = valueEditModel,
                    Values = specificationInfo.Values.OrderBy(x => x.Value).ToList(),
                    ValueCreateFormModel = ValueCreateFormModel,
                };
                return View("SpecificationInfo", specificationViewModel);
            }
            var result = await _categoryDataService.CreateSpecificationValue(ValueCreateFormModel.CategoryId ?? 0, ValueCreateFormModel.SpecificationId, ValueCreateFormModel.Value, ValueCreateFormModel.Metric);
            if (result.Success == false)
            {
                var valueEditModel = new SpecificationCreateInputModel
                {
                    Id = specificationInfo.SpecificationId,
                    Name = specificationInfo.Name,
                    Filter = specificationInfo.Filter,
                    Essential = specificationInfo.InfoLevel == "Essential" ? true : false

                };
                var valueCreateModel = ValueCreateFormModel;
                var specificationViewModel = new SpecificationInfoViewModel
                {
                    SpecificationCreateInputModel = valueEditModel,
                    Values = specificationInfo.Values.OrderBy(x => x.Value).ToList(),
                    ValueCreateFormModel = ValueCreateFormModel,
                };
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
        public async Task<IActionResult> EditSpecificationValue(SpecificationValueCreateInputModel ValueEditFormModel)
        {

            var specificationInfo = await _categoryDataService.SpecificationInfo(ValueEditFormModel.SpecificationId);
            if (!ModelState.IsValid)
            {
                var editForm = new SpecificationCreateInputModel
                {
                    Id = specificationInfo.SpecificationId,
                    Name = specificationInfo.Name,
                    Filter = specificationInfo.Filter,
                    Essential = specificationInfo.InfoLevel == "Essential" ? true : false,
                    CategoryId = specificationInfo.CategoryId,

                };
                var valueForm = new SpecificationValueCreateInputModel()
                {
                    CategoryId = specificationInfo.CategoryId,
                    SpecificationId = specificationInfo.SpecificationId,
                };
                var valueEditForm = new SpecificationValueCreateInputModel
                {
                    SpecificationId = specificationInfo.SpecificationId
                };
                var specificationViewModel = new SpecificationInfoViewModel
                {
                    SpecificationCreateInputModel = editForm,
                    ValueEditFormModel = valueEditForm,
                    Values = specificationInfo.Values.OrderBy(x => x.Value).ToList(),
                    ValueCreateFormModel = valueForm
                };
                return View("SpcificationInfo", specificationViewModel);
            }
            var result = await _categoryDataService.EditSpecificationValue(ValueEditFormModel.CategoryId ?? 0, ValueEditFormModel.SpecificationId, ValueEditFormModel.ValueId, ValueEditFormModel.Value, ValueEditFormModel.Metric);
            if (!result.Success)
            {

                var editForm = new SpecificationCreateInputModel
                {
                    Id = specificationInfo.SpecificationId,
                    Name = specificationInfo.Name,
                    Filter = specificationInfo.Filter,
                    Essential = specificationInfo.InfoLevel == "Essential" ? true : false,
                    CategoryId = specificationInfo.CategoryId,

                };
                var valueForm = new SpecificationValueCreateInputModel()
                {
                    CategoryId = specificationInfo.CategoryId,
                    SpecificationId = specificationInfo.SpecificationId,
                };
                var valueEditForm = new SpecificationValueCreateInputModel
                {
                    SpecificationId = specificationInfo.SpecificationId
                };
                var specificationViewModel = new SpecificationInfoViewModel
                {
                    SpecificationCreateInputModel = editForm,
                    ValueEditFormModel = valueEditForm,
                    Values = specificationInfo.Values.OrderBy(x => x.Value).ToList(),
                    ValueCreateFormModel = valueForm
                };
                foreach (var message in result.ErrorMessage)
                {
                    ModelState.AddModelError("", message);
                }
                return View("SpecificationInfo", specificationViewModel);
            }
            return Redirect($"/Administration/CategoryManagment/SpecificationInfo/{ValueEditFormModel.SpecificationId}");

        }
    }
}
