namespace HardwareStore.App.ValidationAttributes
{
    using HardwareStore.App.Services.Validation;
    using System.ComponentModel.DataAnnotations;
    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Field | AttributeTargets.Parameter)]
    public class ValidSpecificationValueAttribute : ValidationAttribute
    {


        protected override ValidationResult IsValid(object? value, ValidationContext validationContext)
        {
            if (value is Dictionary<int, HashSet<int>> specifications)
            {
                var selectedIds = specifications.SelectMany(x => x.Value).ToHashSet();

                var validatorService = (IValidatorService)validationContext.GetService(typeof(IValidatorService));
                var areValid = Task.Run(async () => await validatorService.IsSpecificationValueValidAsync(selectedIds)).GetAwaiter().GetResult();

                if (!areValid)
                {
                    return new ValidationResult("Invalid Filters");
                }
            }
            return ValidationResult.Success;
        }
       
    }
}
