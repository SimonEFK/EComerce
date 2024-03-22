namespace HardwareStore.App.Services.Data.Products.Edit
{
    public class EditProductDTO
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string NameDetailed { get; set; }

        public int CategoryId { get; set; }

        public int ManufacturerId { get; set; }

        public List<EditImageDTO> Images { get; set; } = new List<EditImageDTO>();

        public IEnumerable<ProductSpecificationEdit> Specifications { get; set; } = new List<ProductSpecificationEdit>();


    }
}
