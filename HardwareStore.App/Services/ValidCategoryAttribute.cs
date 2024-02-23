namespace HardwareStore.App.Services
{
    using HardwareStore.App.Services.Data;
    using System.ComponentModel.DataAnnotations;
    using System.Text.RegularExpressions;

    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Field | AttributeTargets.Parameter)]
    public class ValidCategoryAttribute : ValidationAttribute
    {

        protected override ValidationResult IsValid(object? value, ValidationContext validationContext)
        {
            var category = value as string;
            if (category == null)
            {
                return ValidationResult.Success;
            }

            var categoryDataService = (ICategoryDataService)validationContext.GetService(typeof(ICategoryDataService));
            var categories = categoryDataService
                .GetCategoriesAsTupleCollectionAsync()
                .GetAwaiter()
                .GetResult()
                .Select(x => x.Name.ToLower()).ToList();

            if (!categories.Contains(category.ToLower()))
            {
                return new ValidationResult("Invalid Category");
            }

            return ValidationResult.Success;
        }
    }
}
