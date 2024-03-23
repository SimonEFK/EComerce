namespace HardwareStore.App.ValidationAttributes
{
    using HardwareStore.App.Services.Validation;
    using System.ComponentModel.DataAnnotations;
    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Field | AttributeTargets.Parameter)]
    public class ValidManufacturerAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object? value, ValidationContext validationContext)
        {
            if (value is HashSet<int> manufacturerIds)
            {
                var validatorServce = (IValidatorService)validationContext.GetService(typeof(IValidatorService));
                var areValid = Task.Run(async () => await validatorServce.IsManufacturerValidAsync(manufacturerIds)).GetAwaiter().GetResult();

                if (!areValid)
                {
                    return new ValidationResult("Invalid Manufacturer");
                }

            }

            return ValidationResult.Success;
        }
    }
}
