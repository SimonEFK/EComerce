namespace HardwareStore.App.ValidationAttributes
{
    using HardwareStore.App.Services.Data.Category;
    using HardwareStore.App.Services.Validation;
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

            var validatorService = (IValidatorService)validationContext.GetService(typeof(IValidatorService));
            var isValid = Task.Run(async () => await validatorService.IsCategoryValidAsync(category.Value)).GetAwaiter().GetResult();
            if (!isValid)
            {
                return new ValidationResult("Invalid Category");
            }

            return ValidationResult.Success;
        }
    }
}
