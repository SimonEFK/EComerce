namespace HardwareStore.App.Services.ProductDiscount
{
    public interface IProductDiscountService
    {
        decimal Price { get; }

        decimal DecreaseByAmount(decimal amount);
        decimal DecreaseByPercentage(int percentage);
        decimal IncreaseByAmount(decimal amount);
        decimal IncreaseByPercentage(int percentage);
        IProductDiscountService GetProductPrice(int productId);
    }
}