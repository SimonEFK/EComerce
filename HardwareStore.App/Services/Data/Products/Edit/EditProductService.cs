namespace HardwareStore.App.Services.Data.Products.Edit
{
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

            var product = await dbContext.Products.FirstOrDefaultAsync(x => x.Id == id);
            product.Name = name;
            product.NameDetailed = nameDetailed;
            product.CategoryId = categoryId;
            product.ManufacturerId = manufacturerId;
            await dbContext.SaveChangesAsync();
        }

        public async Task AddImage(int id, string url)
        {
            var product = dbContext.Products.FirstOrDefault(x => x.Id == id);
            var newImageId = Guid.NewGuid().ToString();
            var newImage = new App.Data.Models.Image
            {
                Id = newImageId,
                Url = url,
            };
            product.Images.Add(newImage);
            await dbContext.SaveChangesAsync();
        }

        public async Task RemoveImage(int id, string imageId) 
        {
            var product = dbContext.Products.Include(x=>x.Images).FirstOrDefault(x => x.Id == id);
            var imageToRemove = product.Images.FirstOrDefault(x => x.Id == imageId);
            product.Images.Remove(imageToRemove);
            await dbContext.SaveChangesAsync();
        }


    }
}
