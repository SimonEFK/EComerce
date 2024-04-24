namespace HardwareStore.App.Services.Validation
{
    using HardwareStore.App.Data;
    using HardwareStore.App.Services.ProductFiltering;
    using Microsoft.EntityFrameworkCore;

    public class ValidatorService : IValidatorService
    {
        private readonly ApplicationDbContext data;
        private readonly IGenerateProductFilterOptionService generateProductFilterOptionService;

        public ValidatorService(ApplicationDbContext data, IGenerateProductFilterOptionService generateProductFilterOptionService)
        {
            this.data = data;
            this.generateProductFilterOptionService = generateProductFilterOptionService;
        }

        public async Task<bool> IsProductValidAsync(int productId)
        {
            return await data.Products.AnyAsync(x => x.Id == productId);
        }

        public async Task<bool> IsCategoryValidAsync(int categoryId)
        {
            return await data.Categories.AnyAsync(x => x.Id == categoryId);

        }

        public async Task<bool> IsManufacturerValidAsync(int manufacturerId)
        {
            return await data.Manufacturers.AnyAsync(x => x.Id == manufacturerId);

        }

        public async Task<bool> IsManufacturerValidAsync(HashSet<int> manufacturerIds)
        {
            var manufacturers = await data.Manufacturers.Select(x => x.Id).ToListAsync();
            foreach (var id in manufacturerIds)
            {
                if (!manufacturers.Any(x => x == id))
                {
                    return false;
                }
            }
            return true;

        }

        public async Task<bool> IsSpecificationValidAsync(int specificationId)
        {
            return await data.Specifications.AnyAsync(x => x.Id == specificationId);
        }

        public async Task<bool> IsSpecificationValueValidAsync(int valueId)
        {
            return await data.SpecificationValues.AnyAsync(x => x.Id == valueId);
        }

        public async Task<bool> IsSpecificationValueValidAsync(HashSet<int> valueIds)
        {
            var values = await data.SpecificationValues.Select(x => x.Id).ToListAsync();
            foreach (var id in valueIds)
            {
                if (!values.Any(x => x == id))
                {
                    return false;
                }
            }
            return true;

        }

        public bool IsSortOrderValueValid(string sortOrder)
        {

            var validSortOrders = generateProductFilterOptionService.GenerateSortOrderOptions().Select(x => x.ToLower());

            if (!validSortOrders.Contains(sortOrder.ToLower()))
            {
                return false;
            }
            return true;
        }

        public async Task<bool> IsSpecificationValueValidForCategory(int productCategoryId, int valueId)
        {
            var isValid = await data
           .SpecificationValues
           .Where(x => x.Specification.CategoryId == productCategoryId)
           .Select(x => x.Id)
           .AnyAsync(x => valueId == x);

            return isValid;
        }
    }
}
