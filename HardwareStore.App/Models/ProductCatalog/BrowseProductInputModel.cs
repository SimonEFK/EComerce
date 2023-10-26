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
        public HashSet<int> SpecificationIds { get; set; } = new HashSet<int>();

    }
}
