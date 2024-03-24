namespace HardwareStore.App.Models.ProductCatalog
{
    using HardwareStore.App.ValidationAttributes;
    using Microsoft.AspNetCore.Mvc;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class BrowseProductInputModel : IValidatableObject
    {
        [FromRoute]
        public int? Category { get; set; }

        [FromRoute]        
        public int Page { get; set; } = 1;

        [BindProperty(Name = "s")]        
        [StringLength(maximumLength: 100, MinimumLength = 2)]
        public string? SearchString { get; set; }

        [BindProperty(Name = "ss")]
        [ValidSpecificationValue]
        public Dictionary<int, HashSet<int>> SpecificationIds { get; set; } = new Dictionary<int, HashSet<int>>();

        [BindProperty(Name = "m")]
        [ValidManufacturer]
        public HashSet<int> ManufacturerIds { get; set; } = new HashSet<int>();

        [BindProperty(Name = "so")]        
        [ValidSortOrder]
        public string SortOrder { get; set; } = "newest";

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (this.Category == null && this.SearchString == null)
            {
                yield return new ValidationResult("Category and SearchString can't be both null");
            }
        }
    }
}
