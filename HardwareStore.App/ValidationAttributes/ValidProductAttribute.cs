namespace HardwareStore.App.ValidationAttributes
{
    using HardwareStore.App.Services.Validation;
    using System.ComponentModel.DataAnnotations;

    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Field | AttributeTargets.Parameter)]

    public class ValidProductAttribute : ValidationAttribute
    {
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            var productId = value as int? ?? 0;

            var service = validationContext.GetService<IValidatorService>();
            
            var isValid = Task.Run(async () => await service.IsProductValid(productId)).GetAwaiter().GetResult();

            if (!isValid)
            {
                return new ValidationResult($"Invalid Product Id:{productId}");
            }

            return ValidationResult.Success;
        }
    }

}
