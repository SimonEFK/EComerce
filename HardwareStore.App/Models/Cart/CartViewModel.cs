namespace HardwareStore.App.Models.Cart
{
    using HardwareStore.App.Models.Orders;
    using HardwareStore.App.Services.Cart;

    public class CartViewModel
    {
        public ICollection<CartProductModel> CartProducts = new HashSet<CartProductModel>();

        public OrderInputModel OrderInputModel { get; set; } = new OrderInputModel();
    }
}
