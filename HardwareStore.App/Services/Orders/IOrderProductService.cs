namespace HardwareStore.App.Services.Orders
{
    using HardwareStore.App.Data.Models;
    using PayPal.Api;

    public interface IOrderProductService
    {
        Task<ServiceResultGeneric<string?>> CreateOrderAsync(ApplicationUser user, IEnumerable<CreateOrderItemDTO> orderItems);
        Task<Payment> CreatePayment(string orderId);
        Task<IEnumerable<OrderInfoDTO>> GetOrdersAsync();
        Task<IEnumerable<OrderInfoDTO>> GetUserOrdersAsync(string userId);
        Task UpdateOrderStatus(string paymentId, string newStatus);
    }
}
