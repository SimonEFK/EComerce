namespace HardwareStore.App.Models.ProductCatalog
{
    using HardwareStore.App.Models.Product;
    using HardwareStore.App.Models.Review;
    using HardwareStore.App.Services.Models;

    public class ComponentDetailViewModel
    {
        public ProductDetailedModel Product { get; set; }

        public ProductReviewViewModel ProductReviewViewModel { get; set; }
        
    }
}
