namespace HardwareStore.App.Services.Cart
{
    using HardwareStore.App.Data.Models;
    using HardwareStore.App.Services.Models;
    using System.Collections.Generic;

    public interface ICartService
    {
        Task AddProductToCartAsync(ApplicationUser user, int productId);

        Task CreateCartAsync(ApplicationUser applicationUser);    
        
        Task<ICollection<CartProductModel>> GetUserCartProductsAsync(ApplicationUser applicationUser);
        Task RemoveItem(ApplicationUser applicationUser, int productId);
    }
}
