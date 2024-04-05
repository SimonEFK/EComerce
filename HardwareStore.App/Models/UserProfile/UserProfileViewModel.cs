namespace HardwareStore.App.Models.UserProfile
{
    using HardwareStore.App.Models.Review;
    using HardwareStore.App.Services.ProductReview;

    public class UserProfileViewModel
    {
        public IEnumerable<ProductReviewDTO> ProductReviews { get; set; } = new List<ProductReviewDTO>();

        public ReviewInputModel ReviewInputModel { get; set; }
    }
}
