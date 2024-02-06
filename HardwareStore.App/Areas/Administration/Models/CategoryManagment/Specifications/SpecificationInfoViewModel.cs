namespace HardwareStore.App.Areas.Administration.Models.CategoryManagment.Specifications
{
    public class SpecificationInfoViewModel
    {
        public SpecificationEditModel EditFormModel { get; set; }

        public SpecificationValueCreateModel ValueCreateFormModel { get; set; }

        public List<SpecificationValueInfoModel> Values { get; set; }
    }
}
