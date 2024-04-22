namespace HardwareStore.App.Services.Orders
{
    using HardwareStore.App.Data.Models;
    using PayPal.Api;

    public interface IOrderProductService
    {
        Task ClearUserCartAsync(ApplicationUser applicationUser);
        Task<ServiceResultGeneric<string?>> CreateOrderAsync(ApplicationUser user, IEnumerable<CreateOrderItemDTO> orderItems);
        Task<Payment> CreatePayment(string orderId);
        Task ExecutePayment(string payerId, string paymentId);
        Task<IEnumerable<OrderInfoDTO>> GetOrdersAsync();
        Task<IEnumerable<OrderInfoDTO>> GetUserOrdersAsync(string userId);
        
    }
}
