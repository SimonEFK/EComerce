﻿namespace HardwareStore.App.Services.ProductReview
{
    using HardwareStore.App.Data.Models;
    using System.Threading.Tasks;

    public interface IProductReviewService
    {
        Task CreateReview(ApplicationUser user, string content, int? rating, int productId);
        Task GetProductReview(int productId);
    }
}