namespace HardwareStore.App.Controllers
{
    using HardwareStore.App.Extension;
    using HardwareStore.App.Models.Review;
    using HardwareStore.App.Models.UserProfile;
    using HardwareStore.App.Services.ProductReview;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    [Authorize]
    public class UserProfileController : Controller
    {
        private readonly IProductReviewService _productReviewService;

        public UserProfileController(IProductReviewService productReviewService)
        {
            _productReviewService = productReviewService;

        }

        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> UserReviews()
        {
            var userId = this.HttpContext.User.Id();
            if (userId == null)
            {
                return Redirect($"/Error/ErrorHandler");
            }
            var userReviews = await _productReviewService.GetUserReviewsAsync(userId, true);

            var viewModel = new UserProfileViewModel { ProductReviews = userReviews };
            return View(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> EditReview(ReviewInputModel model)
        {
            if (!ModelState.IsValid)
            {
                return Redirect("/UserProfile/UserReviews");
            }
            var userId = this.HttpContext.User.Id();

            var result = await _productReviewService
                .EditReviewAsync(
                userId,
                model.ReviewId.Value,
                model.Content,
                model.Rating.Value);

            if (result.Success == false)
            {
                return Redirect($"/Error/ErrorHandler?errorMessage={result.ErrorMessage}");
            }
            return Redirect("/UserProfile/UserReviews");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> RemoveReview(int reviewId)
        {
            var result = await _productReviewService.DeleteReviewAsync(reviewId);
            if (result.Success == false)
            {
                return Redirect($"/Error/ErrorHandler?errorMessage={result.ErrorMessage}");
            }

            return Redirect("/UserProfile/UserReviews");
        }


        [HttpGet]
        public IActionResult AddAddress()
        {
            var viewModel = new CreateAddressViewModel();
            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult AddAddress(CreateAddressViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            return Ok();
        }

    }
}
