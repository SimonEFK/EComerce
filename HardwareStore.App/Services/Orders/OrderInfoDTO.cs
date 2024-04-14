using Microsoft.EntityFrameworkCore;

namespace HardwareStore.App.Services.Orders
{
    public class OrderInfoDTO
    {
        public string Id { get; set; }

        public string ApplicationUserId { get; set; }

        public IEnumerable<OrderProductInfoDTO> OrderProducts { get; set; } = new List<OrderProductInfoDTO>();
        public string Status { get; set; }

        public decimal OrderSum { get; set; }

        public DateTime OrderDate { get; set; }

    }
}
