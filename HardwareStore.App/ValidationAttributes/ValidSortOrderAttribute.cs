namespace HardwareStore.App.ValidationAttributes
{
    using HardwareStore.App.Services.ProductFiltering;
    using HardwareStore.App.Services.Validation;
    using System.ComponentModel.DataAnnotations;
    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Field | AttributeTargets.Parameter)]
    public class ValidSortOrderAttribute : ValidationAttribute
    {

        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            if (value is string sortOrder)
            {
                var service = (IValidatorService)validationContext.GetService(typeof(IValidatorService));

                var isValid = service.IsSortOrderValueValid(sortOrder);

                if (!isValid)
                {
                    return new ValidationResult("Invalid SortOrder");
                }

            }
            return ValidationResult.Success;
        }
    }
}
