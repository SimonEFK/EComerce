namespace HardwareStore.App.Services.Cart
{
    using HardwareStore.App.Data.Models;
    using System.Collections.Generic;

    public interface ICartService
    {
        Task AddProductToCartAsync(string applicationUserId, int productId);

        Task CreateCartAsync(string applicationUserId);

        Task<ICollection<CartProductModel>> GetUserCartProductsAsync(string applicationUserId);
        Task RemoveItem(string applicationUserId, int productId);
    }
}
