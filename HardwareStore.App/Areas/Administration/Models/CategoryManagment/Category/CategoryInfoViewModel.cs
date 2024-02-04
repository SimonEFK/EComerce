namespace HardwareStore.App.Areas.Administration.Models.CategoryManagment.Category
{
    using HardwareStore.App.Areas.Administration.Models.CategoryManagment.Specifications;

    public class CategoryInfoViewModel
    {
        public CategoryEditModel CategoryFormModel { get; set; }

        public SpecificationCreateModel SpecificationCreateForm { get; set; }

        public CategoryInfoModel CategoryInfoModel { get; set; }
    }
}
