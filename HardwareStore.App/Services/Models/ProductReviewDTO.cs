namespace HardwareStore.App.Services.Models
{
    using HardwareStore.App.Data.Models;

    public class ProductReviewDTO
    {
        public int Id { get; set; }

        public string ApplicationUserId { get; set; }

        public int ProductId { get; set; }
        
        public string Review { get; set; }

        public int? Rating { get; set; }

        public DateTime CreatedOn { get; set; }

        public DateTime? ModifiedOn { get; set; }

    }
}
