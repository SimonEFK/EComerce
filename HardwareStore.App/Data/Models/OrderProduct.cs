namespace HardwareStore.App.Data.Models
{
    public class OrderProduct
    {
        public int Id { get; set; }

        public string OrderId { get; set; }

        public Order Order { get; set; }

        public int ProductId { get; set; }

        public Product Product { get; set; }

        public int Amount { get; set; }

        public decimal OriginalPrice { get; set; }
        
        public decimal TotalPrice { get; set; }

    }
}