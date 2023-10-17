namespace HardwareStore.App.Data.Models
{
    public class PartNumber
    {
        public int Id { get; set; }

        public int ProductId { get; set; }

        public Product Product { get; set; }

        public string Number { get; set; }

    }

}
