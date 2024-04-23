namespace HardwareStore.App.Services.PriceManager
{
    using HardwareStore.App.Data;
    using Microsoft.EntityFrameworkCore;

    public class PriceManagerService : IPriceManagerService
    {
        private readonly ApplicationDbContext dbContext;

        private decimal? price;

        public decimal? Price { get => price; private set => price = value; }

        public PriceManagerService(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
            Price = price;
        }

        public async Task SetPrice(int productId, decimal price)
        {

            var product = await dbContext.Products.FirstOrDefaultAsync(x => x.Id == productId);
            if (product != null)
            {
                product.Price = price;
            }
            await dbContext.SaveChangesAsync();
        }
        public async Task SetPrice(HashSet<int> productIds, decimal price)
        {
            var products = await dbContext.Products.Where(x => productIds.Contains(x.Id)).ToListAsync();

            foreach (var product in products)
            {
                product.Price = price;
            }
            await dbContext.SaveChangesAsync();
        }
        public async Task IncreasePrice(int productId, decimal amount)
        {
            var product = await dbContext.Products.FirstOrDefaultAsync(x => x.Id == productId);
            if (product != null)
            {
                product.Price += amount;
            }
            await dbContext.SaveChangesAsync();
        }
        public async Task IncreasePrice(HashSet<int> productIds, decimal amount)
        {
            var products = await dbContext.Products.Where(x => productIds.Contains(x.Id)).ToListAsync();

            foreach (var product in products)
            {
                product.Price += amount;
            }
            await dbContext.SaveChangesAsync();
        }
        public async Task IncreasePriceByPercentage(int productId, int percentage)
        {
            var product = await dbContext.Products.FirstOrDefaultAsync(x => x.Id == productId);
            if (product != null)
            {
                product.Price += product.Price * (percentage / 100.00m);
            }
            await dbContext.SaveChangesAsync();
        }
        public async Task IncreasePriceByPercentage(HashSet<int> productIds, int percentage)
        {
            var products = await dbContext.Products.Where(x => productIds.Contains(x.Id)).ToListAsync();
            foreach (var product in products)
            {
                product.Price += product.Price * (percentage / 100.00m);
            }

            await dbContext.SaveChangesAsync();
        }
        public async Task DecreasePrice(int productId, decimal amount)
        {
            var product = await dbContext.Products.FirstOrDefaultAsync(x => x.Id == productId);
            if (product != null)
            {
                product.Price -= amount;
            }
            await dbContext.SaveChangesAsync();
        }
        public async Task DecreasePrice(HashSet<int> productIds, decimal amount)
        {
            var products = await dbContext.Products.Where(x => productIds.Contains(x.Id)).ToListAsync();

            foreach (var product in products)
            {
                product.Price -= amount;
            }
            await dbContext.SaveChangesAsync();
        }
        public async Task DecreasePriceByPercentage(int productId, int percentage)
        {
            var product = await dbContext.Products.FirstOrDefaultAsync(x => x.Id == productId);
            if (product != null)
            {
                product.Price -= product.Price * (percentage / 100.00m);
            }
            await dbContext.SaveChangesAsync();
        }
        public async Task DecreasePriceByPercentage(HashSet<int> productIds, int percentage)
        {
            var products = await dbContext.Products.Where(x => productIds.Contains(x.Id)).ToListAsync();
            foreach (var product in products)
            {
                product.Price -= product.Price * (percentage / 100.00m);
            }

            await dbContext.SaveChangesAsync();
        }

    }
}
