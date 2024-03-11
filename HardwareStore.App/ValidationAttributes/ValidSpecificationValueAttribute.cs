namespace HardwareStore.App.ValidationAttributes
{
    using HardwareStore.App.Services.Data.Category;
    using System.ComponentModel.DataAnnotations;
    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Field | AttributeTargets.Parameter)]
    public class ValidSpecificationValueAttribute : ValidationAttribute
    {


        protected override ValidationResult IsValid(object? value, ValidationContext validationContext)
        {
            if (value is Dictionary<int, HashSet<int>> specifications)
            {
                var selectedIds = specifications.SelectMany(x => x.Value).ToHashSet();

                var categoryDataService = (ICategoryDataService)validationContext.GetService(typeof(ICategoryDataService));
                var validIds = categoryDataService.ValidSpecificationValuesIds().GetAwaiter().GetResult();

                if (selectedIds.Any(x => !validIds.Contains(x)))
                {
                    return new ValidationResult("Invalid Filters");
                }
            }
            return ValidationResult.Success;
        }
    }
}
