﻿namespace HardwareStore.App.Areas.Administration.Controllers
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
            var reviews = await productReviewService.GetAllAsync(true);
            var viewModel = new ProductReviewViewModel
            {
                ProductReviews = reviews.ToList()
            };
            return View(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> ChangeReviewStatus(int reviewId, bool isApproved)
        {
            var result = await productReviewService.ChangeReviewStatusAsync(reviewId, isApproved);

            if (result.Success == false)
            {
                return Redirect($"/Error/ErrorHandler?errorMessage={result.ErrorMessage}");
            }
            return Ok();
        }

        [HttpPost]
        public async Task<IActionResult> DeleteReview(int reviewId)
        {
            var result = await productReviewService.DeleteReviewAsync(reviewId, true);

            if (result.Success == false)
            {
                return Redirect($"/Error/ErrorHandler?errorMessage={result.ErrorMessage}");
            }
            return Ok();
        }
    }
}
