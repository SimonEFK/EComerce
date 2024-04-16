namespace HardwareStore.App.Areas.Administration.Controllers
{
    using HardwareStore.App.Models.ProductCatalog;
    using HardwareStore.App.Services.ProductReview;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using static HardwareStore.App.Constants.Constants;

    
    public class ReviewManagmentController : AdminBaseController
    {
        private IProductReviewService productReviewService;

        public ReviewManagmentController(IProductReviewService productReviewService)
        {
            this.productReviewService = productReviewService;
        }

        public async Task<IActionResult> Index()
        {
            var reviews = await productReviewService.GetAll(true);
            var viewModel = new ProductReviewViewModel
            {
                ProductReviews = reviews.ToList()
            };
            return View(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> ChangeReviewStatus(int reviewId, bool isApproved)
        {
            var result = await productReviewService.ChangeReviewStatus(reviewId, isApproved);

            if (result.Success == false)
            {
                return BadRequest(result);
            }
            return Ok();
        }

        [HttpPost]
        public async Task<IActionResult> DeleteReview(int reviewId)
        {
            var result = await productReviewService.DeleteReview(reviewId, true);

            if (result.Success == false)
            {
                return BadRequest(result);
            }
            return Ok();
        }
    }
}
