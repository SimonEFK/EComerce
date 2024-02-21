namespace HardwareStore.App.Areas.Administration.Models.CategoryManagment.Specifications
{
    using HardwareStore.App.Services.Models;

    public class SpecificationInfoViewModel
    {
        public SpecificationCreateInputModel SpecificationCreateInputModel { get; set; }

        public SpecificationValueCreateInputModel ValueCreateFormModel { get; set; }

        public SpecificationValueCreateInputModel ValueEditFormModel { get; set; }

        public List<SpecificationValueInfoDTO> Values { get; set; }
    }
}
