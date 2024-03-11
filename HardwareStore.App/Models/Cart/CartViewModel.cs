namespace HardwareStore.App.Models.Cart
{
    using HardwareStore.App.Services.Cart;

    public class CartViewModel
    {
        public ICollection<CartProductModel> CartProducts = new HashSet<CartProductModel>();
    }
}
