namespace HardwareStore.App.Data.Models
{
    using System.ComponentModel.DataAnnotations;
    using static Constants.ModelConstraints.ProductReview;

    public class ProductReview
    {
        public int Id { get; set; }

        public bool IsApproved { get; set; }

        public string ApplicationUserId { get; set; }

        public ApplicationUser ApplicationUser { get; set; }

        public int ProductId { get; set; }

        public Product Product { get; set; }

        [Required]
        [MaxLength(ReviewMaxLength)]
        public string Review { get; set; }

        [Range(1, RatingMaxValue)]
        public int? Rating { get; set; }

        public DateTime CreatedOn { get; set; }

        public DateTime? ModifiedOn { get; set; }

        public bool IsDeleted { get; set; } = false;
    }
}
