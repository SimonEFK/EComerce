namespace HardwareStore.App.Services.Cart
{
    using HardwareStore.App.Data.Models;

    public interface ICartService
    {
        Task AddProductToCart(Cart cart, int productId);
        Task CreateCart(ApplicationUser applicationUser);
        Task<Cart> GetUserCart(ApplicationUser applicationUser);
    }
}
