namespace HardwareStore.App.Areas.Administration.Models.CategoryManagment.Specifications
{
    public class SpecificationInfoViewModel
    {
        public SpecificationCreateInputModel SpecificationCreateInputModel { get; set; }

        public SpecificationValueCreateInputModel ValueCreateFormModel { get; set; }

        public SpecificationValueCreateInputModel ValueEditFormModel { get; set; }

        public List<SpecificationValueInfoModel> Values { get; set; }
    }
}
