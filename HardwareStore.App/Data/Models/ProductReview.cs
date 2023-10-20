﻿namespace HardwareStore.App.Data.Models
{
    public class ProductReview
    {
        public int Id { get; set; }

        public string UserName { get; set; }

        public string ApplicationUserId { get; set; }

        public ApplicationUser ApplicationUser { get; set; }

        public int ProductId { get; set; }

        public Product Product { get; set; }

        public string Review { get; set; }

        public DateTime CreatedOn { get; set; }

        public DateTime? ModifiedOn { get; set; }
    }
}