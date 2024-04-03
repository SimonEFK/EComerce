namespace HardwareStore.App.Areas.Administration.Models.ReviewManagment
{
    using HardwareStore.App.Models.Review;
    using HardwareStore.App.Services.ProductReview;

    public class ReviewViewModel
    {
        public List<ProductReviewDTO> Reviews { get; set; }

        public ReviewInputModel InputModel { get; set; }
    }
}
