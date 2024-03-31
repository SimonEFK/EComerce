namespace HardwareStore.App.Services.Cart
{
    public class CartProductModel
    {
        public int ProductId { get; set; }

        public int Amount { get; set; }

        public decimal? ProductPrice { get; set; }

        public string ProductName { get; set; }

        public string ProductNameDetailed { get; set; }

        public string Image { get; set; }

        public int ProductCategoryId { get; set; }
    }
}
