namespace HardwareStore.App.ValidationAttributes
{
    using HardwareStore.App.Services.ProductFiltering;
    using System.ComponentModel.DataAnnotations;
    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Field | AttributeTargets.Parameter)]
    public class ValidSortOrderAttribute : ValidationAttribute
    {

        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            if (value is string sortOrder)
            {
                var service = (IGenerateProductFilterOptionService)validationContext.GetService(typeof(IGenerateProductFilterOptionService));

                var validSortOrders = service.GenerateSortOrderOptions().Select(x => x.ToLower());

                if (!validSortOrders.Contains(sortOrder.ToLower()))
                {
                    return new ValidationResult("Invalid SortOrder");
                }

            }
            return ValidationResult.Success;
        }
    }
}
