namespace HardwareStore.App.Services.ProductDiscount
{
    using HardwareStore.App.Data;

    public class ProductDiscountService : IProductDiscountService
    {
        private decimal price;
        private ApplicationDbContext context;

        public decimal Price { get => price; private set => price = value; }
        public ProductDiscountService(ApplicationDbContext context)
        {
            this.context = context;
        }

        public IProductDiscountService GetProductPrice(int productId)
        {
            var productPrice = context.Products.FirstOrDefault(x => x.Id == productId).Price;
            price = productPrice;
            return this;
        }

        public decimal IncreaseByAmount(decimal amount)
        {
            return Price += amount;
        }
        public decimal IncreaseByPercentage(int percentage)
        {
            return Price += Price * (percentage / 100.00m);
        }
        public decimal DecreaseByAmount(decimal amount)
        {
            return Price -= amount;
        }
        public decimal DecreaseByPercentage(int percentage)
        {
            return Price -= Price * (percentage / 100.00m);
        }

    }
}
