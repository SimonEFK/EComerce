namespace HardwareStore.App.Services.Models
{
    using System.ComponentModel.DataAnnotations;

    public class CategoryOutputModel
    {
        public int Id { get; set; }

        public string CategoryName { get; set; }

        public string ImageUrl { get; set; }

        public string ImageFilePath { get; set; }

        public ICollection<SpecificationOutputModel> Specifications { get; set; } = new List<SpecificationOutputModel>();
    }
}
