﻿namespace HardwareStore.App.Services.Data.Products.ProductSpecifications
{
    using HardwareStore.App.Data;
    using HardwareStore.App.Data.Models;
    using HardwareStore.App.Services.Validation;
    using Microsoft.EntityFrameworkCore;
    using static Constants.Constants;

    public class ProductSpecificationService : IProductSpecificationService
    {
        private IValidatorService validatorService;
        private ApplicationDbContext dbContext;

        public ProductSpecificationService(IValidatorService validatorService, ApplicationDbContext dbContext)
        {
            this.validatorService = validatorService;
            this.dbContext = dbContext;
        }

        public async Task<ServiceResult> AddSpecificationAsync(int productId, int valueId)
        {
            var result = new ServiceResult();
            var product = await dbContext.Products.Include(x => x.Specifications).FirstOrDefaultAsync(x => x.Id == productId);

            if (product is null)
            {
                result.Success = false;
                result.ErrorMessage = string.Format(ErrorMessages.InvalidProductId, productId);
                return result;
            }
            var isValueIdValid = await validatorService.IsSpecificationValueValidAsync(valueId);
            if (!isValueIdValid)
            {
                result.Success = false;
                result.ErrorMessage = string.Format(ErrorMessages.InvalidVlaueId, valueId);
                return result;
            }
            var alreadyHaveValue = dbContext.Products.Where(x => x.Id == productId).Any(x => x.Specifications.FirstOrDefault(x => x.SpecificationValueId == valueId) != null);
            if (!alreadyHaveValue)
            {
                var productSpecificationValue = new ProductSpecificationValues
                {
                    SpecificationValueId = valueId,
                };
                product.Specifications.Add(productSpecificationValue);

                await dbContext.SaveChangesAsync();
            }
           
            return result;
        }

        public async Task<ServiceResult> RemoveSpecificationAsync(int productId, int valueId)
        {
            var result = new ServiceResult();
            var product = await dbContext.Products.Include(x => x.Specifications).FirstOrDefaultAsync(x => x.Id == productId);

            if (product is null)
            {
                result.Success = false;
                result.ErrorMessage = string.Format(ErrorMessages.InvalidProductId, productId);
                return result;
            }
            var isValueIdValid = await validatorService.IsSpecificationValueValidAsync(valueId);
            if (!isValueIdValid)
            {
                result.Success = false;
                result.ErrorMessage = string.Format(ErrorMessages.InvalidVlaueId, valueId);
                return result;
            }
            foreach (var item in product.Specifications)
            {
                if (item.SpecificationValueId == valueId)
                {
                    product.Specifications.Remove(item);
                }
            }
            await dbContext.SaveChangesAsync();
            return result;
        }

    }
}
