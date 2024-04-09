namespace HardwareStore.App.Services.Orders
{
    using HardwareStore.App.Data.Models;

    public interface IOrderProductService
    {
        Task<ServiceResult> CreateOrderAsync(ApplicationUser user, IEnumerable<CreateOrderItemDTO> orderItems);
        Task<IEnumerable<OrderInfoDTO>> GetOrdersAsync();
        Task<IEnumerable<OrderInfoDTO>> GetUserOrdersAsync(string userId);
    }
}
