namespace HardwareStore.App.Models.ProductCatalog
{
    using Microsoft.AspNetCore.Mvc;

    public class BrowseProductInputModel
    {
        [FromRoute]
        public string Category { get; set; }

        [FromQuery]
        public int Page { get; set; } = 1;

        [BindProperty(Name = "s")]
        public string? SearchString { get; set; }


        [BindProperty(Name = "ss")]
        public Dictionary<int, HashSet<int>> SpecificationIds { get; set; } = new Dictionary<int, HashSet<int>>();


        [BindProperty(Name = "m")]
        public HashSet<int> ManufacturerIds { get; set; } = new HashSet<int>();


        [BindProperty(Name = "so")]
        public string SortOrder { get; set; } = "newest";

    }
}
