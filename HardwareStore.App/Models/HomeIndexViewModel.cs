namespace HardwareStore.App.Models
{
    using HardwareStore.App.Models.Category;
    using HardwareStore.App.Models.Product;

    public class HomeIndexViewModel
    {
        public ICollection<CategoryModel> Categories { get; set; } = new List<CategoryModel>();

        public List<ProductSimplifiedModel> Products { get; set; } = new List<ProductSimplifiedModel>();
    }
}
