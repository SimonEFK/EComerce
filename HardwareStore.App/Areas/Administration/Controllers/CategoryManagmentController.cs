namespace HardwareStore.App.Areas.Administration.Controllers
{
    using AutoMapper;
    using HardwareStore.App.Areas.Administration.Models.CategoryManagment.Category;
    using HardwareStore.App.Areas.Administration.Models.CategoryManagment.Specifications;
    using HardwareStore.App.Services.Data.Category;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;



    public class CategoryManagmentController : AdminBaseController
    {
        private readonly ICategoryDataService _categoryDataService;
        private readonly IMapper mapper;

        public CategoryManagmentController(ICategoryDataService categoryDataService, IMapper mapper)
        {
            _categoryDataService = categoryDataService;
            this.mapper = mapper;
        }

        public async Task<IActionResult> Index()
        {
            var categories = await _categoryDataService.GetCategoriesAsync<CategoryViewModel>();
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
            var categoryInfoModel = await _categoryDataService.CategoryInfoAsync(Id);
            var categoryEditModel = mapper.Map<CategoryEditInputModel>(categoryInfoModel);
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
            var specificationInfo = await _categoryDataService.SpecificationInfoAsync(id);
            var editForm = mapper.Map<SpecificationCreateInputModel>(specificationInfo);
            var valueForm = new SpecificationValueCreateInputModel()
            {
                CategoryId = specificationInfo.CategoryId,
                SpecificationId = specificationInfo.Id,
            };
            var valueEditForm = new SpecificationValueCreateInputModel
            {
                SpecificationId = specificationInfo.Id,
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
                var categories = await _categoryDataService.GetCategoriesAsync<CategoryViewModel>();
                var categoryListViewModel = new CategoryListingViewModel()
                {
                    Categories = categories.ToList(),
                    CreateCategoryInputModel = createCategoryInputModel
                };
                return View("Index", categoryListViewModel);
            }
            var result = await _categoryDataService.CreateCategoryAsync(createCategoryInputModel.Name, createCategoryInputModel.Image);

            if (!result.Success)
            {
                return Redirect($"/Error/BadRequest?errorMessage={result.ErrorMessage}");
            }
            return Redirect("/Administration/CategoryManagment");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditCategory(CategoryEditInputModel categoryEditModel)
        {
            if (!ModelState.IsValid)
            {
                var categoryInfoModel = await _categoryDataService.CategoryInfoAsync(categoryEditModel.Id);
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
            var result = await _categoryDataService.EditCategoryAsync(
                categoryEditModel.Id,
                categoryEditModel.Name,
                categoryEditModel.Url,
                categoryEditModel.FilePath);

            if (!result.Success)
            {
                return Redirect($"/Error/BadRequest?errorMessage={result.ErrorMessage}");
            }
            return Redirect($"/Administration/CategoryManagment/CategoryInfo/{categoryEditModel.Id}");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateSpecification(SpecificationCreateInputModel specificationCreateModel)
        {

            if (!ModelState.IsValid)
            {
                var categoryInfoModel = await _categoryDataService.CategoryInfoAsync(specificationCreateModel.CategoryId ?? 0);
                var categoryEditModel = mapper.Map<CategoryEditInputModel>(categoryInfoModel);
                var categoryInfoViewModel = new CategoryInfoViewModel
                {
                    CategoryEditModel = categoryEditModel,
                    CategoryInfoModel = categoryInfoModel,
                    SpecificationCreateForm = specificationCreateModel
                };
                ViewData["FormCollapse"] = "show";
                return View("CategoryInfo", categoryInfoViewModel);
            }
            var result = await _categoryDataService.CreateSpecificationAsync(specificationCreateModel.CategoryId ?? 0, specificationCreateModel.Name, specificationCreateModel.Filter, specificationCreateModel.Essential);

            if (!result.Success)
            {

                return Redirect($"/Error/BadRequest?errorMessage={result.ErrorMessage}");

            }
            return Redirect($"/Administration/CategoryManagment/CategoryInfo/{specificationCreateModel.CategoryId}");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditSpecification(int id, SpecificationCreateInputModel specificationEditModel)
        {

            if (!ModelState.IsValid)
            {
                var specificationInfo = await _categoryDataService.SpecificationInfoAsync(id);
                var specificationViewModel = new SpecificationInfoViewModel
                {
                    SpecificationCreateInputModel = specificationEditModel,
                    Values = specificationInfo.Values.OrderBy(x => x.Value).ToList()
                };
                return View("SpecificationInfo", specificationViewModel);
            }

            var result = await _categoryDataService
                .EditSpecificationAsync(specificationEditModel.CategoryId ?? 0, id, specificationEditModel.Name, specificationEditModel.Filter, specificationEditModel.Essential);
            if (!result.Success)
            {

                return Redirect($"/Error/BadRequest?errorMessage={result.ErrorMessage}");

            }
            return Redirect($"/Administration/CategoryManagment/SpecificationInfo/{specificationEditModel.Id}");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateSpecificationValue(SpecificationValueCreateInputModel ValueCreateFormModel)
        {
            var specificationInfo = await _categoryDataService.SpecificationInfoAsync(ValueCreateFormModel.SpecificationId);

            if (!ModelState.IsValid)
            {
                var valueEditModel = mapper.Map<SpecificationCreateInputModel>(specificationInfo);
                var valueCreateModel = ValueCreateFormModel;
                var specificationViewModel = new SpecificationInfoViewModel
                {
                    SpecificationCreateInputModel = valueEditModel,
                    Values = specificationInfo.Values.OrderBy(x => x.Value).ToList(),
                    ValueCreateFormModel = ValueCreateFormModel,
                };
                return View("SpecificationInfo", specificationViewModel);
            }
            var result = await _categoryDataService.CreateSpecificationValueAsync(ValueCreateFormModel.CategoryId ?? 0, ValueCreateFormModel.SpecificationId, ValueCreateFormModel.Value, ValueCreateFormModel.Metric);
            if (result.Success == false)
            {
                return Redirect($"/Error/BadRequest?errorMessage={result.ErrorMessage}");

            }

            return Redirect($"/Administration/CategoryManagment/SpecificationInfo/{specificationInfo.Id}");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditSpecificationValue(SpecificationValueCreateInputModel ValueEditFormModel)
        {

            var specificationInfo = await _categoryDataService.SpecificationInfoAsync(ValueEditFormModel.SpecificationId);
            if (!ModelState.IsValid)
            {
                var editForm = mapper.Map<SpecificationCreateInputModel>(specificationInfo);

                var valueForm = new SpecificationValueCreateInputModel()
                {
                    CategoryId = specificationInfo.CategoryId,
                    SpecificationId = specificationInfo.Id,
                };
                var valueEditForm = new SpecificationValueCreateInputModel
                {
                    SpecificationId = specificationInfo.Id
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
            var result = await _categoryDataService.EditSpecificationValueAsync(ValueEditFormModel.CategoryId ?? 0, ValueEditFormModel.SpecificationId, ValueEditFormModel.ValueId, ValueEditFormModel.Value, ValueEditFormModel.Metric);
            if (!result.Success)
            {

                return Redirect($"/Error/BadRequest?errorMessage={result.ErrorMessage}");
            }
            return Redirect($"/Administration/CategoryManagment/SpecificationInfo/{ValueEditFormModel.SpecificationId}");

        }

        [HttpGet]
        public async Task<IActionResult> CategoryInfoJson(int categoryId)
        {
            var result = await _categoryDataService.CategoryInfoAsync(categoryId);
            return Json(result);
        }
    }
}
