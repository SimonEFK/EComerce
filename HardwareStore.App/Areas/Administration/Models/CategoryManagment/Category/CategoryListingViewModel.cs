namespace HardwareStore.App.Areas.Administration.Models.CategoryManagment.Category
{
    public class CategoryListingViewModel
    {
        public List<CategoryViewModel> Categories { get; set; } = new List<CategoryViewModel>();

        public CreateCategoryInputModel CreateCategoryInputModel { get; set; }
    }
}
