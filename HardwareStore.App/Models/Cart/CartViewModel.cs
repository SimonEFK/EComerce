namespace HardwareStore.App.Models.Cart
{
    using HardwareStore.App.Services.Models;

    public class CartViewModel
    {
        public ICollection<CartProductModel> CartProducts = new HashSet<CartProductModel>();
    }
}
