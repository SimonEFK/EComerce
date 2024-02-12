namespace HardwareStore.App.Services
{
    using System.ComponentModel.DataAnnotations;
    using System.Text.RegularExpressions;

    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Field | AttributeTargets.Parameter)]
    public class CollectionRegexAttribute : ValidationAttribute
    {
        private string regexPattern;

        public CollectionRegexAttribute(string regexPattern)
        {
            this.regexPattern = regexPattern;
        }
        protected override ValidationResult IsValid(object? value, ValidationContext validationContext)
        {
            var collection = value as IEnumerable<string>;
            if (collection == null)
            {
                return ValidationResult.Success;
            }
            foreach (var item in collection)
            {
                var isMatch = Regex.IsMatch(item, regexPattern);
                if (isMatch != true)
                {
                    return new ValidationResult("Invalid Format");
                }
            }

            return ValidationResult.Success;
        }
    }
}
