namespace HardwareStore.App.Services.Data.Products.Edit
{
    using CommunityToolkit.Diagnostics;
    using HardwareStore.App.Data;
    using HardwareStore.App.Services.Validation;
    using Microsoft.EntityFrameworkCore;

    public class EditProductService : IEditProductService
    {
        private readonly IValidatorService validatorService;
        private readonly ApplicationDbContext dbContext;

        public EditProductService(IValidatorService validatorService, ApplicationDbContext dbContext)
        {
            this.validatorService = validatorService;
            this.dbContext = dbContext;
        }

        public async Task EditProduct(int id, string name, string? nameDetailed, int categoryId, int manufacturerId)
        {
            var isProductValid = await validatorService.IsProductValidAsync(id);
            if (!isProductValid)
            {
                throw new ArgumentException("Invalid Product");
            }
            var isCategoryValid = await validatorService.IsCategoryValidAsync(categoryId);
            if (!isCategoryValid)
            {
                throw new ArgumentException("Invalid Category");
            }
            var isManufacturerValid = await validatorService.IsManufacturerValidAsync(manufacturerId);
            if (!isManufacturerValid)
            {
                throw new ArgumentException("Invalid Manufacturer");
            }
            Guard.IsNotWhiteSpace(name);
            Guard.IsNotEmpty(name);
            if (nameDetailed != null)
            {
                Guard.IsNotEmpty(nameDetailed);
                Guard.IsNotWhiteSpace(nameDetailed);
            }

            var product = await dbContext.Products.FirstOrDefaultAsync(x => x.Id == id);
            product.Name = name;
            product.NameDetailed = nameDetailed;
            product.CategoryId = categoryId;
            product.ManufacturerId = manufacturerId;
            await dbContext.SaveChangesAsync();
        }
    }
}
