namespace HardwareStore.App.Services.PriceManager
{
    using System.Collections.Generic;

    public interface IPriceManagerService
    {

        Task DecreasePrice(int productId, decimal amount);
        Task DecreasePrice(HashSet<int> productIds, decimal amount);
        Task DecreasePriceByPercentage(int productId, int percentage);
        Task DecreasePriceByPercentage(HashSet<int> productIds, int percentage);
        Task IncreasePrice(int productId, decimal amount);
        Task IncreasePrice(HashSet<int> productIds, decimal amount);
        Task IncreasePriceByPercentage(int productId, int percentage);
        Task IncreasePriceByPercentage(HashSet<int> productIds, int percentage);
        Task SetPrice(int productId, decimal price);
        Task SetPrice(HashSet<int> productIds, decimal price);
    }
}