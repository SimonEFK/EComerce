namespace HardwareStore.App.Views.Shared.Components.CategoryMenu
{
    using HardwareStore.App.Models.Category;
    using HardwareStore.App.Services.Data.Category;
    using Microsoft.AspNetCore.Mvc;

    public class CategoryMenuViewComponent : ViewComponent
    {
        private ICategoryDataService categoryDataService;
        public CategoryMenuViewComponent(ICategoryDataService categoryDataService)
        {
            this.categoryDataService = categoryDataService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var categories = await categoryDataService.GetCategories<CategoryModel>();
            return View(categories.Where(x => x.ProductsCount > 0).ToList());
        }
    }
}
