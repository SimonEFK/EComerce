namespace HardwareStore.App.Areas.Administration.Models
{
    public class CreateProductViewModel
    {
        public CreateProductFormModel ProductFormModel { get; set; }

        public ICollection<(string Name, int Id)> CategoryList { get; set; } = new List<(string Name, int Id)>();
        public ICollection<(string Name, int Id)> ManufacturerList { get; set; } = new List<(string Name, int Id)>();
    }
}
