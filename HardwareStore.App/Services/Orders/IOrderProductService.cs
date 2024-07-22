namespace HardwareStore.App.Services.Orders
{
    using HardwareStore.App.Data.Models;
    using PayPal.Api;

    public interface IOrderProductService
    {
        Task ClearUserCartAsync(string userId);
        Task<ServiceResultGeneric<string?>> CreateOrderAsync(string userId, IEnumerable<CreateOrderItemDTO> orderItems);
        Task<Payment> CreatePayment(string orderId);
        Task ExecutePayment(string payerId, string paymentId);
        Task<IEnumerable<OrderInfoDTO>> GetOrdersAsync();
        Task<IEnumerable<OrderInfoDTO>> GetUserOrdersAsync(string userId);
        
    }
}
