namespace HardwareStore.App.Models.ProductCatalog
{
    using Microsoft.AspNetCore.Mvc;
    using System.ComponentModel.DataAnnotations;

    public class BrowseProductInputModel
    {

        public string Category { get; set; }

        [FromQuery]
        public int Page { get; set; } = 1;

        [BindProperty(Name = "s")]
        [StringLength(maximumLength: 100, MinimumLength = 3)]
        public string? SearchString { get; set; }


        [BindProperty(Name = "ss")]
        public Dictionary<int, HashSet<int>> SpecificationIds { get; set; } = new Dictionary<int, HashSet<int>>();


        [BindProperty(Name = "m")]
        public HashSet<int> ManufacturerIds { get; set; } = new HashSet<int>();


        [BindProperty(Name = "so")]
        public string SortOrder { get; set; } = "newest";

    }
}
