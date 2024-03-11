namespace HardwareStore.App.Services.Cart
{
    public class CartProductModel
    {
        public int Id { get; set; }

        public int Amount { get; set; }

        public decimal Price { get; set; }

        public string Name { get; set; }

        public string Image { get; set; }

        public int CategoryId { get; set; }
    }
}
