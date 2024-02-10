namespace HardwareStore.App.Areas.Administration.Models.CategoryManagment.Specifications
{
    public class SpecificationInfoModel
    {

        public int? CategoryId { get; set; }

        public int SpecificationId { get; set; }

        public string Name { get; set; }

        public bool Filter { get; set; }

        public string InfoLevel { get; set; }

        public ICollection<SpecificationValueInfoModel> Values { get; set; } = new List<SpecificationValueInfoModel>();
    }
}