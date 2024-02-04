namespace HardwareStore.App.Areas.Administration.Models.CategoryManagment.Category
{
    using System.ComponentModel.DataAnnotations;

    public class CategoryViewModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Image { get; set; }
    }
}
