namespace HardwareStore.App.Services.Cart
{
    using HardwareStore.App.Data.Models;
    using HardwareStore.App.Models.Product;
    using HardwareStore.App.Services.Models;
    using System.Collections.Generic;

    public interface ICartService
    {
        Task AddProductToCartAsync(Cart cart, int productId);
        Task CreateCartAsync(ApplicationUser applicationUser);
        Task<Cart> GetUserCartAsync(ApplicationUser applicationUser);
        Task<ICollection<CartProductModel>> GetUserCartProductsAsync(ApplicationUser applicationUser);
    }
}
