namespace HardwareStore.App.Models.Cart
{
    using HardwareStore.App.Data.Models;
    using HardwareStore.App.Models.Product;
    using HardwareStore.App.Services.Models;

    public class CartViewModel
    {
        public ICollection<CartProductModel> CartProducts = new HashSet<CartProductModel>();
    }
}
