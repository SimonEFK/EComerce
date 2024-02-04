namespace HardwareStore.App.Areas.Administration.Models.CategoryManagment.Category
{
    using System.ComponentModel.DataAnnotations;
    using HardwareStore.App.Areas.Administration.Models.CategoryManagment.Specifications;

    public class CategoryInfoModel
    {
        public int Id { get; set; }

        public string CategoryName { get; set; }

        public string ImageUrl { get; set; }

        public string ImageFilePath { get; set; }

        public ICollection<SpecificationInfoModel> Specifications { get; set; } = new List<SpecificationInfoModel>();
    }
}
