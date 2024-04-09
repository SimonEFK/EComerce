using Microsoft.EntityFrameworkCore;

namespace HardwareStore.App.Services.Orders
{
    public class OrderInfoDTO
    {
        public int Id { get; set; }

        public string ApplicationUserId { get; set; }

        public IEnumerable<OrderProductInfoDTO> OrderProducts { get; set; } = new List<OrderProductInfoDTO>();

        public decimal OrderSum { get; set; }

        public DateTime OrderDate { get; set; }

    }
}
