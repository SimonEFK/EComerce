namespace HardwareStore.App.Data.Models
{
    public class ProductSpecificationValues
    {
        public int Id { get; set; }

        public int ProductId { get; set; }

        public Product Product { get; set; }

        public int SpecificationValueId { get; set; }

        public SpecificationValue SpecificationValue { get; set; }

    }

}
