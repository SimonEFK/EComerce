namespace HardwareStore.App.Models.ProductCatalog
{
    using HardwareStore.App.Models.Review;
    using HardwareStore.App.Services.ProductReview;

    public class ProductReviewViewModel
    {
        public List<ProductReviewDTO> ProductReviews { get; set; } = new List<ProductReviewDTO>();

        public ReviewInputModel ReviewInputModel { get; set; }
    }
}