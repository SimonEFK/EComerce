namespace HardwareStore.App.Data.Models
{
    using Microsoft.AspNetCore.Identity;

    public class ApplicationUser : IdentityUser
    {
        public ApplicationUser()
        {
            ProductReviews = new HashSet<ProductReview>();

        }
        public ICollection<ProductReview> ProductReviews { get; set; }
        
        public Cart Cart { get; set; }

    }
}
