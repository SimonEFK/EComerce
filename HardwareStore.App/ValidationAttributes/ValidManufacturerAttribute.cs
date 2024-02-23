namespace HardwareStore.App.ValidationAttributes
{
    using HardwareStore.App.Services.Data;
    using System.ComponentModel.DataAnnotations;
    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Field | AttributeTargets.Parameter)]
    public class ValidManufacturerAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object? value, ValidationContext validationContext)
        {
            if (value is HashSet<int> manufacturerIds)
            {
                var manufacturerDataService = (IManufacturerDataService)validationContext.GetService(typeof(IManufacturerDataService));
                var manufacturers = manufacturerDataService
                    .GetManufacturersAsTupleCollectionAsync()
                    .GetAwaiter()
                    .GetResult()
                    .Select(x => x.Id).ToList();

                if (manufacturerIds.Any(x => !manufacturers.Contains(x)))
                {
                    return new ValidationResult("Invalid Manufacturer");
                }

            }

            return ValidationResult.Success;
        }
    }
}
