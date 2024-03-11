namespace HardwareStore.App.ValidationAttributes
{
    using HardwareStore.App.Services.Data.Category;
    using System.ComponentModel.DataAnnotations;

    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Field | AttributeTargets.Parameter)]
    public class ValidCategoryAttribute : ValidationAttribute
    {

        protected override ValidationResult IsValid(object? value, ValidationContext validationContext)
        {
            var category = value as int?;
            if (category == null)
            {
                return ValidationResult.Success;
            }

            var categoryDataService = (ICategoryDataService)validationContext.GetService(typeof(ICategoryDataService));
            var categories = categoryDataService
                .GetCategoriesAsTupleCollectionAsync()
                .GetAwaiter()
                .GetResult()
                .Select(x => x.Id).ToList();

            if (!categories.Contains((int)category))
            {
                return new ValidationResult("Invalid Category");
            }

            return ValidationResult.Success;
        }
    }
}
