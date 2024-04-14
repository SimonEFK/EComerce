namespace HardwareStore.App.Models.Cart
{
    using HardwareStore.App.Models.Orders;
    using HardwareStore.App.Services.Cart;

    public class CartViewModel
    {
        public List<CartProductModel> CartProducts = new List<CartProductModel>();

        public OrderInputModel OrderInputModel { get; set; } = new OrderInputModel();
    }
}
