namespace HardwareStore.App.Data.Models
{
    using HardwareStore.App.Services.Orders;

    public class Order
    {
        public int Id { get; set; }

        public ApplicationUser ApplicationUser { get; set; }

        public string ApplicationUserId { get; set; }

        public ICollection<OrderProduct> OrderProducts { get; set; } = new List<OrderProduct>();

        public decimal OrderSum { get; set; }

        public DateTime OrderDate { get; set; } = DateTime.UtcNow;

    }
}
