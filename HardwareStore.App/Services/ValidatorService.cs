namespace HardwareStore.App.Services
{
    using HardwareStore.App.Data;
    using Microsoft.EntityFrameworkCore;

    public class ValidatorService : IValidatorService
    {
        private readonly ApplicationDbContext data;

        public ValidatorService(ApplicationDbContext data)
        {
            this.data = data;
        }

        public async Task<bool> IsProductValid(int productId)
        {
            return await data.Products.AnyAsync(x => x.Id == productId);
        }
    }
}
