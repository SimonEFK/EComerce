namespace HardwareStore.App.Services.Orders
{
    public class OrderProductInfoDTO
    {
        public int ProductId { get; set; }

        public string ProductName { get; set; }

        public int Amount { get; set; }

        public decimal ProductPrice { get; set; }

        public decimal TotalPrice { get; set; }
    }
}
